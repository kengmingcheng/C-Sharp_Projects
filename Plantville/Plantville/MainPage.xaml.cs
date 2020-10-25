using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Plantville
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private Dictionary<string, object> dict;
        private string savedFile;
        protected Player player;
        public int money = 100;
        public int land_plot = 15;
        private bool booth = false; // Does player already set up a booth

        private string url;

        List<Plant> garden = new List<Plant>();
        List<Plant> inventory = new List<Plant>();
        Dictionary<string, int[]> invent_dict = new Dictionary<string, int[]>();
        Dictionary<string, string> chat;
        Dictionary<string, string> trade;

        public List<Seed> seed_inventory = new List<Seed>()
        {
            new Seed("Strawberry", 2, 8, new TimeSpan(0, 0, 30)),
            new Seed("Spinach", 5, 21, new TimeSpan(0, 1, 0)),
            new Seed("Pear", 2, 20, new TimeSpan(0, 3, 0))
        };
        public MainPage()
        {
            InitializeComponent();
            lbl_user.Content = LogIn.getUName() + " :";
            
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_chat);
            grid_listbox.Children.Add(btn_send);
            grid_listbox.Children.Add(txb_chat);
            grid_listbox.Children.Add(lbl_user);

            

            Dictionary<string, object> dict;
            if (System.IO.File.Exists(@"save.txt"))
            {
                using (var reader = new StreamReader(@"save.txt"))
                {
                    while (!reader.EndOfStream)
                    {
                        var text_data = reader.ReadLine();
                        var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(text_data);

                        garden = JsonConvert.DeserializeObject<List<Plant>>(data["garden"].ToString());
                        invent_dict = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(data["inventory"].ToString());
                        money = Convert.ToInt32(data["money"]);
                        //land_plot = Convert.ToInt32(data["land"]);
                    }
                }
            }
            player = new Player(LogIn.getUName(), 100);
            lbl_gold.Content = "Gold: $" + money;
            lbl_lands.Content = "Land:  " + land_plot;

            updateSeedList();
            // upate chat history
            ChatAsync();
            TradesAsync();
        }

        // POST
        private async Task chatPostAsync(Dictionary<string, object> chatPost)
        {
            HttpClient client = new HttpClient();
            // parameters for POSTing data to url
            string post_url = "http://plantville.herokuapp.com/";
            Dictionary<string, object> chatUpload = chatPost;

            var user = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("username", chatUpload["username"].ToString()),
               new KeyValuePair<string, string>("message", chatUpload["message"].ToString()),
            });

            // POST to URL
            HttpResponseMessage response = await client.PostAsync(post_url, user);

            // Read response
            string json_data = await response.Content.ReadAsStringAsync();
        }

        private async Task tradePostAsync(Dictionary<string, object> tradePost)
        {
            HttpClient client = new HttpClient();
            // parameters for POSTing data to url
            string post_url = "http://plantville.herokuapp.com/trades";
            Dictionary<string, object> tradeUpload = tradePost;
            var user = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("author", tradeUpload["author"].ToString()),
               new KeyValuePair<string, string>("price", tradeUpload["price"].ToString()),
               new KeyValuePair<string, string>("plant", tradeUpload["plant"].ToString()),
               new KeyValuePair<string, string>("quantity", tradeUpload["quantity"].ToString())
            });

            // POST to URL
            HttpResponseMessage response = await client.PostAsync(post_url, user);

            // Read response
            string json_data = await response.Content.ReadAsStringAsync();
        }

        private async Task acceptedPostAsync(Dictionary<string, object> acceptedTrade)
        {
            HttpClient client = new HttpClient();
            // parameters for POSTing data to url
            //string post_url = "https://postman-echo.com/post";
            string post_url = "https://plantville.herokuapp.com/accept_trade";
            Dictionary<string, object> acceptedTradeUpload = acceptedTrade;
            var user = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("trade_id", acceptedTradeUpload["trade_id"].ToString()),
               new KeyValuePair<string, string>("accepted_by", acceptedTradeUpload["accepted_by"].ToString())
            });

            // POST to URL
            HttpResponseMessage response = await client.PostAsync(post_url, user);

            // Read response
            string json_data = await response.Content.ReadAsStringAsync();
            MessageBox.Show(json_data);

        }

        // upate chat history
        private async Task ChatAsync()
        {
            lbx_chat.Items.Clear();
            HttpClient client = new HttpClient();
            string url = "http://plantville.herokuapp.com/";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // print JSON response
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var chatData = JsonConvert.DeserializeObject<List<object>>(jsonString);
                chatData.Reverse();
                foreach (object data in chatData)
                {
                    Dictionary<string, object> record = JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
                    chat = JsonConvert.DeserializeObject<Dictionary<string, string>>(record["fields"].ToString());
                    lbx_chat.Items.Add(chat["username"] + " : " + chat["message"]);
                }
                lbx_chat.ScrollIntoView(lbx_chat.Items[lbx_chat.Items.Count - 1]);
            }
        }

        // Update trade history
        private async Task TradesAsync()
        {
            lbx_market.Items.Clear();
            HttpClient client = new HttpClient();
            url = "http://plantville.herokuapp.com/trades";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // print JSON response
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var tradeData = JsonConvert.DeserializeObject<List<object>>(jsonString);
                foreach (object data in tradeData)
                {
                    Dictionary<string, object> record = JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
                    trade = JsonConvert.DeserializeObject<Dictionary<string, string>>(record["fields"].ToString());
                    int id = Convert.ToInt32(record["pk"]);
                    bool state = trade["state"] == "open";
                    float price = Convert.ToInt32(trade["price"]);
                    int quantity = Convert.ToInt32(trade["quantity"]);
                    lbx_market.Items.Add(new Trade(id, trade["author"], trade["accepted_by"], price, state, trade["plant"], quantity));
                }
            }
        }

        // update status
        private void update()
        {
            lbl_gold.Content = "Gold: $" + money;
            lbl_lands.Content = "Land:   " + land_plot;
            lbx_garden.Items.Clear();
            if (garden.Count > 0)
            {
                bool allHarvest = true;
                foreach (Plant plant in garden)
                {
                    lbx_garden.Items.Add(plant.type.name + " [" + plant.getHarvestTime() + "]");
                    allHarvest = allHarvest && plant.harvest();
                }
                if (allHarvest)
                {
                    btn_harvest.Visibility = Visibility.Visible;
                }
            }
        }

        private void updateSeedList()
        {
            foreach (Seed s in seed_inventory)
            {
                lbx_seed.Items.Add(s.name);
            }
        }

        // hide button in every action
        private void hideButton()
        {
            btn_market.Visibility = Visibility.Hidden;
            btn_harvest.Visibility = Visibility.Hidden;
            lbl_boothFee.Visibility = Visibility.Hidden;
        }
        // create a list of seeds

        private void Btn_garden_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_garden);
            grid_listbox.Children.Add(btn_harvest);
            lbl_title.Content = "Garden";
            hideButton();
            bool allHarvest = true;
            lbx_garden.Items.Clear();
            if (garden.Count > 0)
            {
                foreach (Plant plant in garden)
                {
                    lbx_garden.Items.Add(plant.type.name + " [" + plant.getHarvestTime() + "]");
                    allHarvest = allHarvest && plant.harvest();
                }
                if (allHarvest)
                {
                    btn_harvest.Visibility = Visibility.Visible;
                }
            }
            else
            {
                MessageBox.Show("No plants in garden");
            }
        }

        private void Btn_seedEmporium_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_seed);
            lbl_title.Content = "Seeds Emporium";
            hideButton();
        }

        private void Btn_inventory_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_inventory);
            grid_listbox.Children.Add(btn_market);
            grid_listbox.Children.Add(lbl_boothFee);
            lbl_title.Content = "Inventory";
            hideButton();
            btn_market.Visibility = Visibility.Visible;
            lbl_boothFee.Visibility = Visibility.Visible;
            lbx_inventory.Items.Clear();
            foreach (KeyValuePair<string, int[]> entry in invent_dict)
            {
                string item = entry.Key + " [" + entry.Value[0].ToString() + "] $" + entry.Value[1].ToString();
                lbx_inventory.Items.Add(item);
            }
        }

        private void Lbx_trade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_market1_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_market);
        }

        private void Btn_trade_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbl_plant);
            grid_listbox.Children.Add(lbl_quantity);
            grid_listbox.Children.Add(lbl_price);
            grid_listbox.Children.Add(cbb_plant);
            grid_listbox.Children.Add(txb_quantity);
            grid_listbox.Children.Add(txb_price);
            grid_listbox.Children.Add(btn_submit);
        }

        private void Btn_chat_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_chat);
            grid_listbox.Children.Add(btn_send);
            grid_listbox.Children.Add(txb_chat);
            grid_listbox.Children.Add(lbl_user);
        }

        private void Lbx_garden_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (garden.Count() > 0)
            {
                Plant selectedPlant = garden[lbx_garden.SelectedIndex];
                if (selectedPlant.harvest())
                {
                    //inventory.Add(selectedPlant);
                    if (invent_dict.ContainsKey(selectedPlant.type.name))
                    {
                        invent_dict[selectedPlant.type.name][0] += 1;
                    }
                    else
                    {
                        invent_dict[selectedPlant.type.name] = new int[2] { 1, selectedPlant.type.sellingPrice };
                    }
                    garden.RemoveAt(lbx_garden.SelectedIndex);
                    lbx_garden.Items.Remove(lbx_garden.SelectedItem);
                    land_plot += 1;
                }
                else if (selectedPlant.timeToHarvest > new TimeSpan(0, 0, 0))
                {
                    MessageBox.Show("Not yet ready!");
                }
                else if (selectedPlant.timeToHarvest < new TimeSpan(0, -15, 0))
                {
                    MessageBox.Show("The plant spoiled");
                    garden.RemoveAt(lbx_garden.SelectedIndex);
                    lbx_garden.Items.Remove(lbx_garden.SelectedItem);
                    land_plot += 1;
                }
            }
            update();
        }

        private void Lbx_seed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // check if player has enough lands and gold to grow a plant.
            if (garden.Count() < 15 && money >= seed_inventory[lbx_seed.SelectedIndex].purchasePrice)
            {
                garden.Add(new Plant(seed_inventory[lbx_seed.SelectedIndex]));
                money -= seed_inventory[lbx_seed.SelectedIndex].purchasePrice;
                land_plot -= 1;
            }
            else if (garden.Count() >= 15)
            {
                MessageBox.Show("You can only grow 15 plants at one time");
            }
            else if (money < seed_inventory[lbx_seed.SelectedIndex].purchasePrice)
            {
                MessageBox.Show("You don't have enought gold to purchase the item");
            }
            update();
        }

        private void Lbx_inventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (booth && invent_dict.Count > 0)
            {
                money += invent_dict.ElementAt(lbx_inventory.SelectedIndex).Value[0] * invent_dict.ElementAt(lbx_inventory.SelectedIndex).Value[1];
                invent_dict.Remove(invent_dict.ElementAt(lbx_inventory.SelectedIndex).Key);
                lbx_inventory.Items.Remove(lbx_inventory.SelectedItem);
            }
            else if (!booth)
            {
                MessageBox.Show("You haven't set up a booth");
            }
            update();
        }

        private async void Lbx_market_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Trade trade = (Trade)lbx_market.SelectedItem;

            

            Dictionary<string, object> acceptedTradeText = new Dictionary<string, object>()
            {
                {"trade_id", trade.id},
                {"accepted_by", player.name },
            };

            if (trade.state)
            {
                trade.trade_item();
                await acceptedPostAsync(acceptedTradeText);
                await TradesAsync();
            }
            else
            {
                MessageBox.Show("This trade already completed!");
            }
        }

        // set up booth
        private void Btn_market_Click(object sender, RoutedEventArgs e)
        {
            if (invent_dict.Count > 0)
            {
                // check if player has enough gold to set a booth
                if (money >= 10)
                {
                    money -= 10;
                    booth = true;
                }
                else
                {
                    MessageBox.Show("You don't have enough gold to set up a booth!");
                }
            }
            // if there is no plant in the inventory, show message
            else
            {
                MessageBox.Show("No product in inventory");
            }

            lbl_gold.Content = "Gold: $ " + money;
        }

        // harvest all plants
        private void Btn_harvest_Click(object sender, RoutedEventArgs e)
        {
            foreach (Plant plant in garden)
            {
                if (invent_dict.ContainsKey(plant.type.name))
                {
                    invent_dict[plant.type.name][0] += 1;
                }
                else
                {
                    invent_dict[plant.type.name] = new int[2] { 1, plant.type.sellingPrice };
                }
            }
            garden.Clear();
            lbx_garden.Items.Clear();
            land_plot = 15;
            lbl_lands.Content = "Land:   " + land_plot;
        }

        private void saveData()
        {
            // create dictionary of noteworthy variables. 
            var json = new Dictionary<string, object>()
            {
                {"garden", garden},
                {"inventory", invent_dict },
                {"money", money },
            };
            string serializedJson = JsonConvert.SerializeObject(json);
            //Console.WriteLine(serializedJson);
            File.WriteAllText(@"save.txt", serializedJson);
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
            saveData();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            // Save game progress while closing window
            saveData();
        }

        private async void Btn_send_Click(object sender, RoutedEventArgs e)
        {
            Dictionary<string, object> chatText = new Dictionary<string, object>()
            {
                {"username", player.name },
                {"message", txb_chat.Text },
            };
            txb_chat.Text = "";
            await chatPostAsync(chatText);
            await ChatAsync();
            lbx_chat.ScrollIntoView(lbx_chat.Items[lbx_chat.Items.Count - 1]);
        }

        private async void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            if (Int32.Parse(txb_quantity.Text) * Int32.Parse(txb_price.Text) > money)
            {
                MessageBox.Show("You don't have enough money");
            }
            else
            {
                //lbx_market.Items.Insert(0,"[open] " + player.name + " wants to buy " + txb_quantity.Text + " " + cbb_plant.Text + " for $" + txb_price.Text);

                Dictionary<string, object> tradeText = new Dictionary<string, object>()
                {
                    {"author", player.name},
                    {"price", txb_price.Text },
                    {"plant", cbb_plant.Text},
                    {"quantity", txb_quantity.Text },
                };
                txb_quantity.Text = "";
                txb_price.Text = "";
                string tradePost = JsonConvert.SerializeObject(tradeText);
                await tradePostAsync(tradeText);
                await TradesAsync();
            }
        }

        private void lbx_trade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = lbx_trade.SelectedIndex;
            MessageBox.Show("Test");
        }
    }
}

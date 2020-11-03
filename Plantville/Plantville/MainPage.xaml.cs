using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
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
        private bool booth = false; // Does player already set up a booth

        private string url;

        List<Plant> inventory = new List<Plant>();
        Dictionary<string, int[]> invent_dict = new Dictionary<string, int[]>();
        Dictionary<string, string> chat;
        Dictionary<string, string> trade;
        private int chatPk = -1;

        public List<Seed> seed_inventory = new List<Seed>()
        {
            new Seed("strawberry", 2, 8, new TimeSpan(0, 0, 30)),
            new Seed("spinach", 5, 21, new TimeSpan(0, 1, 0)),
            new Seed("pear", 2, 20, new TimeSpan(0, 3, 0))
        };
        public MainPage()
        {
            InitializeComponent();
            // get server url
            url = LogIn.getUrl();

            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_chat);
            grid_listbox.Children.Add(btn_send);
            grid_listbox.Children.Add(txb_chat);
            grid_listbox.Children.Add(lbl_user);
            // upate chat history
            updateChat();

            player = new Player(LogIn.getUName(), 100);
            lbl_user.Content = LogIn.getUName() + " :";
            // load init data
            load_save();
            updateSeedList();
        }

        private async void load_save()
        {
            // Load save from local
            if (url.Contains("herokuapp"))
            {
                if (System.IO.File.Exists(@"save.txt"))
                {
                    using (var reader = new StreamReader(@"save.txt"))
                    {
                        while (!reader.EndOfStream)
                        {
                            var text_data = reader.ReadLine();
                            var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(text_data);

                            player.garden = JsonConvert.DeserializeObject<List<Plant>>(data["garden"].ToString());
                            invent_dict = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(data["inventory"].ToString());
                            player.gold = Convert.ToInt32(data["money"]);
                        }
                    }
                }
            }
            // Load save from server
            else if (url.Contains("plantville/api"))
            {
                await saveAsync();
            }
            lbl_gold.Content = "Gold: $" + player.gold;
            lbl_lands.Content = "Land:  " + player.getLand();
        }

        // POST
        private async Task chatPostAsync(Dictionary<string, object> chatPost)
        {
            HttpClient client = new HttpClient();
            // parameters for POSTing data to url
            string post_url = url;
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
            string post_url = url + "trades";
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
            string post_url = url + "accept_trade";
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
        }
        
        private async Task savePostAsync(string save)
        {
            HttpClient client = new HttpClient();
            string post_url = url + "save/" + player.name;
            var user = new StringContent(save, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(post_url, user);
            string json_data = await response.Content.ReadAsStringAsync();
        }
        
        // upate chat history
        private async Task ChatAsync()
        {
            HttpClient client = new HttpClient();
            string get_url = url;
            HttpResponseMessage response = await client.GetAsync(get_url);
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
                    int pk = Convert.ToInt32(record["pk"]);
                    if (pk <= chatPk)
                    {
                        continue;
                    }
                    else
                    {
                        chat = JsonConvert.DeserializeObject<Dictionary<string, string>>(record["fields"].ToString());
                        //lbx_chat.Items.Add(new Chat(Convert.ToInt32(record["pk"]), chat["username"], chat["message"]));
                        lbx_chat.Items.Add(chat["username"] + " : " + chat["message"]);
                        chatPk = pk;
                    }
                }
            }
        }

        // Update trade history
        private async Task TradesAsync()
        {
            lbx_market.Items.Clear();
            HttpClient client = new HttpClient();
            string get_url = url + "trades";
            HttpResponseMessage response = await client.GetAsync(get_url);
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
                    int price = Convert.ToInt32(trade["price"]);
                    int quantity = Convert.ToInt32(trade["quantity"]);
                    lbx_market.Items.Add(new Trade(id, trade["author"], trade["accepted_by"], price, state, trade["plant"], quantity));
                }
            }
        }

        private async Task saveAsync()
        {
            HttpClient client = new HttpClient();
            string get_url = url + "save/" + LogIn.getUName();
            HttpResponseMessage response = await client.GetAsync(get_url);
            if (response.IsSuccessStatusCode)
            {
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());
                if (jsonString.ToString().Length > 0)
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonString);

                    player.garden = JsonConvert.DeserializeObject<List<Plant>>(data["garden"].ToString());
                    invent_dict = JsonConvert.DeserializeObject<Dictionary<string, int[]>>(data["inventory"].ToString());
                    player.gold = Convert.ToInt32(data["money"]);
                }
            }
        }

        private async void updateChat()
        {
            try
            {
                bool scrollToBottom = true;
                do
                {
                    await ChatAsync();
                    if (scrollToBottom)
                    {
                        lbx_chat.ScrollIntoView(lbx_chat.Items[lbx_chat.Items.Count - 1]);
                        scrollToBottom = false;
                    }
                    await Task.Delay(5000);
                } while ((grid_listbox.Children.Contains(btn_send)));
            }
            catch
            {
                Console.WriteLine("Some error occured!");
            }
        }

        private async void updateTrade()
        {
            await TradesAsync();
        }

        // update status
        private void update()
        {
            lbl_gold.Content = "Gold: $" + player.gold;
            lbl_lands.Content = "Land:   " + player.getLand();
            lbx_garden.Items.Clear();
            if (player.garden.Count > 0)
            {
                bool allHarvest = true;
                foreach (Plant plant in player.garden)
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

        // create a list of seeds
        private void updateSeedList()
        {
            foreach (Seed s in seed_inventory)
            {
                lbx_seed.Items.Add(s);
            }
        }

        // hide button in every action
        private void hideButton()
        {
            btn_market.Visibility = Visibility.Hidden;
            btn_harvest.Visibility = Visibility.Hidden;
            lbl_boothFee.Visibility = Visibility.Hidden;
        }

        private void Btn_garden_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_garden);
            grid_listbox.Children.Add(btn_harvest);
            lbl_title.Content = "Garden";
            hideButton();
            bool allHarvest = true;
            lbx_garden.Items.Clear();
            if (player.garden.Count > 0)
            {
                foreach (Plant plant in player.garden)
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
                lbx_garden.Items.Add("No plant in garden");
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
            if (lbx_inventory.Items.Count == 0)
            {
                lbx_inventory.Items.Add("No fruit or vegetable harvested");
            }
        }

        private void Lbx_trade_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Btn_market1_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_market);
            lbl_title.Content = "Market";
            updateTrade();
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
            lbl_title.Content = "Trade";
        }

        private void Btn_chat_Click(object sender, RoutedEventArgs e)
        {
            grid_listbox.Children.Clear();
            grid_listbox.Children.Add(lbx_chat);
            grid_listbox.Children.Add(btn_send);
            grid_listbox.Children.Add(txb_chat);
            grid_listbox.Children.Add(lbl_user);
            lbl_title.Content = "Chatroom";
            updateChat();
        }

        private void Lbx_garden_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (player.garden.Count() > 0)
            {
                Plant selectedPlant = player.garden[lbx_garden.SelectedIndex];
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
                    player.garden.RemoveAt(lbx_garden.SelectedIndex);
                    lbx_garden.Items.Remove(lbx_garden.SelectedItem);
                }
                else if (selectedPlant.timeToHarvest > new TimeSpan(0, 0, 0))
                {
                    MessageBox.Show("Not yet ready!");
                }
                else if (selectedPlant.timeToHarvest < new TimeSpan(0, -15, 0))
                {
                    MessageBox.Show("The plant spoiled");
                    player.garden.RemoveAt(lbx_garden.SelectedIndex);
                    lbx_garden.Items.Remove(lbx_garden.SelectedItem);
                }
            }
            update();
        }

        private void Lbx_seed_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            // check if player has enough lands and gold to grow a plant.
            if (player.garden.Count() < 15 && player.gold >= seed_inventory[lbx_seed.SelectedIndex].purchasePrice)
            {
                player.garden.Add(new Plant(seed_inventory[lbx_seed.SelectedIndex]));
                player.gold -= seed_inventory[lbx_seed.SelectedIndex].purchasePrice;
            }
            else if (player.garden.Count() >= 15)
            {
                MessageBox.Show("You can only grow 15 plants at one time");
            }
            else if (player.gold < seed_inventory[lbx_seed.SelectedIndex].purchasePrice)
            {
                MessageBox.Show("You don't have enought gold to purchase the item");
            }
            update();
        }

        private void Lbx_inventory_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (booth && invent_dict.Count > 0)
            {
                player.gold += invent_dict.ElementAt(lbx_inventory.SelectedIndex).Value[0] * invent_dict.ElementAt(lbx_inventory.SelectedIndex).Value[1];
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

            if (trade.state)
            {
                if (invent_dict[trade.plant][0] >= trade.quantity)
                {
                    Dictionary<string, object> acceptedTradeText = new Dictionary<string, object>()
                    {
                        {"trade_id", trade.id},
                        {"accepted_by", player.name },
                    };

                    invent_dict[trade.plant][0] -= trade.quantity;
                    player.gold += trade.price * trade.quantity;
                    await acceptedPostAsync(acceptedTradeText);
                    updateTrade();
                }
                else
                {
                    MessageBox.Show("You don't have enough fruit/vegetable in your inventory");
                }
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
                if (player.gold >= 10)
                {
                    player.gold -= 10;
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

            lbl_gold.Content = "Gold: $ " + player.gold;
        }

        // harvest all plants
        private void Btn_harvest_Click(object sender, RoutedEventArgs e)
        {
            foreach (Plant plant in player.garden)
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
            player.garden.Clear();
            lbx_garden.Items.Clear();
            lbl_lands.Content = "Land:   " + player.getLand();
        }

        public async void saveData()
        {
            // create dictionary of noteworthy variables. 
            var json = new Dictionary<string, object>()
            {
                {"garden", player.garden},
                {"inventory", invent_dict },
                {"money", player.gold },
            };
            string serializedJson = JsonConvert.SerializeObject(json);
            //Console.WriteLine(serializedJson);
            File.WriteAllText(@"save.txt", serializedJson);
            if (MainWindow.server.Contains("plantville/api"))
            {
                await savePostAsync(serializedJson);
            }
        }

        private void Btn_save_Click(object sender, RoutedEventArgs e)
        {
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
            updateChat();
        }

        private async void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            int totalAmount = Int32.Parse(txb_quantity.Text) * Int32.Parse(txb_price.Text);
            if (totalAmount > player.gold)
            {
                MessageBox.Show("You don't have enough gold");
            }
            else
            {
                Dictionary<string, object> tradeText = new Dictionary<string, object>()
                {
                    {"author", player.name},
                    {"price", txb_price.Text },
                    {"plant", cbb_plant.Text},
                    {"quantity", txb_quantity.Text },
                };
                player.gold -= totalAmount;
                txb_quantity.Text = "";
                txb_price.Text = "";
                await tradePostAsync(tradeText);
                updateTrade();
            }
        }

        private void lbx_trade_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            int index = lbx_trade.SelectedIndex;
            MessageBox.Show("Test");
        }
    }
}

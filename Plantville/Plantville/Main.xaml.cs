using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private Dictionary<string, object> dict;
        private string savedFile;
        protected Player player;
        public int money = 100;
        public int land_plot = 15;
        private bool booth = false; // Does player already set up a booth
        private string user = "User";

        List<Plant> garden = new List<Plant>();
        List<Plant> inventory = new List<Plant>();
        Dictionary<string, int[]> invent_dict = new Dictionary<string, int[]>();

        public List<Seed> seed_inventory = new List<Seed>()
        {
            new Seed("Strawberry", 2, 8, new TimeSpan(0, 0, 30)),
            new Seed("Spinach", 5, 21, new TimeSpan(0, 1, 0)),
            new Seed("Pear", 2, 20, new TimeSpan(0, 3, 0))
        };

        public MainWindow()
        {
            InitializeComponent();

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
            player = new Player(100);           
            lbl_gold.Content = "Gold: $" + money;
            lbl_lands.Content = "Land:   " + land_plot;

            updateSeedList();
            // upate chat history
            HistoryAsync();


        }

        // POST
        private async Task postAsync()
        {
            HttpClient client = new HttpClient();
            // parameters for POSTing data to url
            var user = new FormUrlEncodedContent(new[]
            {
               new KeyValuePair<string, string>("name", "Karl"),
               new KeyValuePair<string, string>("country", "Australia")
            });

            // POST to URL
            HttpResponseMessage response = await client.PostAsync("https://jsonplaceholder.typicode.com/users", user);

            // Read response
            string json_data = await response.Content.ReadAsStringAsync();
        }

        // upate chat history
        private async Task HistoryAsync()
        {
            HttpClient client = new HttpClient();
            string url = "http://plantville.herokuapp.com/";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // print JSON response
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var chatData = JsonConvert.DeserializeObject<List<object>>(jsonString);
                foreach(object data in chatData)
                {
                    Dictionary<string, object> record = JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
                    Dictionary<string, string> chat = JsonConvert.DeserializeObject<Dictionary<string, string>>(record["fields"].ToString());
                    lbx_chat.Items.Add(chat["username"] + ": " + chat["message"]);
                }
            }

            url = "http://plantville.herokuapp.com/trades";
            response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                // print JSON response
                var jsonString = await response.Content.ReadAsStringAsync();
                //Console.WriteLine(await response.Content.ReadAsStringAsync());

                var tradeData = JsonConvert.DeserializeObject<List<object>>(jsonString);
                foreach (object data in tradeData)
                {
                    Dictionary<string, object> record = JsonConvert.DeserializeObject<Dictionary<string, object>>(data.ToString());
                    Dictionary<string, string> trade = JsonConvert.DeserializeObject<Dictionary<string, string>>(record["fields"].ToString());

                    if (trade["state"].Equals("open"))
                    {
                        lbx_market.Items.Add("[open] " + trade["author"] + " wants to buy " + trade["quantity"].ToString() + " " + trade["plant"] + " for $" + trade["price"].ToString());
                        
                    }
                    else if (trade["state"].Equals("closed"))
                    {
                        lbx_market.Items.Add("[closed] " + trade["author"] + " bought " + trade["quantity"].ToString() + " " + trade["plant"] + " for $" + trade["price"].ToString() + " from " + trade["accepted_by"]);
                    }
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
            lbl_title.Content = "Inventory";
            hideButton();
            btn_market.Visibility = Visibility.Visible;
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

        private void Lbx_market_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

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
            saveData();
        }

        private void Btn_send_Click(object sender, RoutedEventArgs e)
        {
            lbx_chat.Items.Add(user + ": " + txb_chat.Text);
            txb_chat.Text = "";
        }

        private void Btn_submit_Click(object sender, RoutedEventArgs e)
        {
            lbx_market.Items.Add("[open] " + user + " wants to buy " + txb_quantity.Text + " " + cbb_plant.Text + " for $" + txb_price.Text);
            txb_quantity.Text = "";
            txb_price.Text = "";
        }
    }
}

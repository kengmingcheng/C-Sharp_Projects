using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Plantville
{
    class Trade
    {
        public int id { get; set; }
        public string author { get; set; }
        public string accepted_by { get; set; }
        public int price { get; set; }
        public bool state { get; set; }
        public string plant { get; set; }
        public int quantity { get; set; }

        public Trade(int id,string author, string accepted_by, int price, bool state, string plant, int quantity)
        {
            this.id = id;
            this.author = author;
            this.accepted_by = accepted_by;
            this.price = price;
            this.state = state;
            this.plant = plant;
            this.quantity = quantity;
        }

        public void trade_item()
        {
            state = !state;
        }

        public override string ToString()
        {
            if (state)
            {
                return "[open] " + author + " wants to buy " + quantity.ToString() + " " + plant + " for $" + price.ToString();

            }
            else
            {
                return "[closed] " + author + " wants to buy " + quantity.ToString() + " " + plant + " for $" + price.ToString();
            }
        }
    }
}

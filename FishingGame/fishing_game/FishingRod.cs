using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    class FishingRod
    {
        public string name { get; set; }
        public int price { get; set; }
        public int buff { get; set; }

        public FishingRod(string name, int price, int buff)
        {
            this.name = name;
            this.price = price;
            this.buff = buff;
        }
    }
}

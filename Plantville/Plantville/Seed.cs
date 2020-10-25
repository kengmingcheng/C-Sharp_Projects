using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantville
{
    public class Seed
    {
        public string name { get; set; }
        public int purchasePrice { get; set; }
        public int sellingPrice { get; set; }
        public TimeSpan harvestTime { get; set; }

        public Seed(string name, int p_price, int s_price, TimeSpan harvestTime)
        {
            this.name = name;
            purchasePrice = p_price;
            sellingPrice = s_price;
            this.harvestTime = harvestTime;
        }

        public TimeSpan getHarvestTime()
        {
            return harvestTime;
        }
    }
}

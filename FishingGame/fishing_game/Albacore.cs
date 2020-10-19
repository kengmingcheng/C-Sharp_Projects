using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    class Albacore : Fish
    {
        public Albacore(int probability) : base(probability)
        {
            MarketPrice = 50;
            Name = "albacore";
        }

        internal override bool IsCaught(string input)
        {
            if (input == "2")
            {
                return true;
            }
            return false;
        }
    }
}

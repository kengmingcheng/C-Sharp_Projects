using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    class YellowTail : Fish
    {
        public YellowTail(int probability) : base(probability)
        {
            MarketPrice = 100;
            Name = "yellowtail";
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

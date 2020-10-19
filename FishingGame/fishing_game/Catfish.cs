using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    class Catfish : Fish
    {
        public Catfish(int probability) : base(probability)
        {
            MarketPrice = 10;
            Name = "catfish";
        }

    }
}

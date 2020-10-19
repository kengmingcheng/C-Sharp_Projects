using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    class Lake
    {
        public string Name { get; set; }
        public List<Fish> fishList { get; set; }

        public Lake(string name, List<Fish> fishList)
        {
            this.Name = name;
            this.fishList = fishList;
        }

    }
}

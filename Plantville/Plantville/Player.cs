using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantville
{
    public class Player
    {
        public string name { get; set; }
        public int gold { get; set; }
        private const int max_land = 15;
        public List<Plant> garden { get; set; }
        public List<Plant> plant_inventory { get; set; }
        public Dictionary<string, int[]> plant_dic { get; set; }

        public Player(string name, int gold)
        {
            this.name = name;
            this.gold = gold;
            garden = new List<Plant>();
            plant_inventory = new List<Plant>();
            plant_dic = new Dictionary<string, int[]>();
        }

        public int getLand()
        {
            return max_land - garden.Count;
        }
    }
}

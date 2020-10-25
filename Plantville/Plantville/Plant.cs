using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plantville
{
    public class Plant
    {
        public Seed type { get; set; }
        public DateTime purchaseTime { get; set; }
        public TimeSpan harvestTime { get; set; }
        public TimeSpan timeToHarvest { get; set; }

        public Plant(Seed seed)
        {
            type = seed;
            purchaseTime = DateTime.Now;
        }
        public bool harvest()
        {
            timeToHarvest = type.getHarvestTime() - (DateTime.Now - purchaseTime);
            return timeToHarvest <= new TimeSpan(0, 0, 0) && timeToHarvest >= new TimeSpan(0, -15, 0);
        }

        public string getHarvestTime()
        {
            harvestTime = type.harvestTime;
            timeToHarvest = harvestTime - (DateTime.Now - purchaseTime);
            string timeString;
            if (timeToHarvest >= new TimeSpan(0, 1, 0))
            {
                timeString = timeToHarvest.ToString("%m") + " minute(s) to harvest";
            }
            else if (timeToHarvest >= new TimeSpan(0, 0, 0))
            {
                timeString = timeToHarvest.ToString("%s") + " second(s) to harvest";
            }
            else if (timeToHarvest >= new TimeSpan(0, -15, 0))
            {
                timeString = "Ready to harvest";
            }
            else
            {
                timeString = "Spoiled";
            }
            return timeString;
        }
    }
}

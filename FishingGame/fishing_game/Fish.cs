using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fishing_game
{
    /// <summary>
    /// Base fish class
    /// </summary>
    class Fish
    {

        public string Name { get; set; }
        public int MarketPrice { get; set; }
        public int BiteProbability { get; set; }

        public Fish(int probability)
        {
            BiteProbability = probability;
        }

        /// <summary>
        /// Random chance at fish biting bait
        /// </summary>
        /// <returns><c>true</c>, if bait was bitten, <c>false</c> otherwise.</returns>
        internal bool BitesBait(int chance)
        {
            if (chance < BiteProbability + Game.rodBuff)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Each fish needs to be caught using the proper technique. 
        /// </summary>
        /// <returns><c>true</c>, if fish was caught, <c>false</c> otherwise.</returns>
        /// <param name="input">Input.</param>
        internal virtual bool IsCaught(string input)
        {
            if (input == "1")
            {
                return true;
            }
            return false;
        }
    }
}
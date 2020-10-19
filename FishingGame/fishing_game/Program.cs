using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace fishing_game
{
    class Game
    {
        internal static int Money = 0;
        internal static List<Fish> container = new List<Fish>();
        internal static int rodBuff = 0;

        static void Main(string[] args)
        {
            /* KEEP THIS START */

            // list of lakes
            List<Lake> all_lakes = new List<Lake>()
            {
                // each lake takes in a list of fish that's available in the lake
                new Lake("Lake Tahoe", new List<Fish>()
                {
                    // each fish takes in the probability they bite the bait. So catfish has 35% chance of biting
                    new Catfish(35),

                    // albacore has 20% chance of biting
                    new Albacore(20),

                    // bluefin has 5% chance of biting
                    new Bluefin(5)

                }),
                // each lake takes in a list of fish that's available in the lake
                new Lake("Big Bear lake", new List<Fish>()
                {
                    // catfish less prolific in big bear, only 30% chance of biting.
                    new Catfish(30),

                    // albacore has 35% chance of biting
                    new Albacore(35),

                    // yellowtail has 15% chance of biting
                    new YellowTail(15),

                })
            };

            // list of all fishing rods available at the store
            List<FishingRod> all_rods = new List<FishingRod>()
            {
                // each fishing rod passes in the name, price, and buff added to probability.
                new FishingRod("Swift Model E", 50, 2),
                new FishingRod("Perry Water Eye Gouger", 200, 6),
                new FishingRod("The Senator", 400, 10),
                new FishingRod("Ocean Depleter", 1000, 20),

            };
            /* KEEP THIS END */

            while (true)
            {
                Console.WriteLine("Welcome to deep sea fishing!");
                Console.WriteLine("---------");

                Console.WriteLine("1. Go fishing");
                Console.WriteLine("2. Bass pro shop");
                Console.WriteLine("3. Sell fish");
                Console.WriteLine("What would you like to do?");

                string input = Console.ReadLine();

                if (input.Equals("1"))
                {
                    Console.WriteLine("What lake you want to go to?");
                    for (int i = 0; i < all_lakes.Count; i++)
                    {
                        Console.WriteLine("{0}. {1}", (i+1), all_lakes[i].Name);
                    }

                    int chooseLake = Convert.ToInt32(Console.ReadLine()) - 1;
                    go_fishing(all_lakes[chooseLake].fishList);
                }
                else if (input.Equals("2"))
                {
                    go_shop(all_rods);
                }
                else if (input.Equals("3"))
                {
                    sell_fish();
                }
            }
        }

        private static void go_fishing(List<Fish> availableFishes)
        {
            int full_container = 4;
            Random rand = new Random();

            // list of fishes in our container

            Console.WriteLine(string.Format("Our container holds {0} fish. Keep the ones you love.", full_container));
            Console.WriteLine("Let's fish!");

            // while we have space in our container...
            while (container.Count < full_container)
            {

                // a random fish comes near our bait
                int random_fish_index = rand.Next(availableFishes.Count);

                // generate random number to see if fish bites bait
                int fish_bites_chance = rand.Next(100);

                // random chance if fish decides to bite the bait
                if (availableFishes[random_fish_index].BitesBait(fish_bites_chance))
                {

                    // Fishing techniques
                    Console.WriteLine("\nA fish bit your bait! What do you want to do?");
                    Console.WriteLine("1. Reel in fish");
                    Console.WriteLine("2. Use net\n");

                    string input = Console.ReadLine();

                    // if the user properly caught the fish...
                    if (availableFishes[random_fish_index].IsCaught(input))
                    {
                        Console.WriteLine("\nGot it! Let's see what we caught.");

                        // print the name of the fish
                        Console.WriteLine(availableFishes[random_fish_index].Name);
                        Console.WriteLine("");

                        // add fish to container
                        container.Add(availableFishes[random_fish_index]);
                    }
                    else
                    {
                        Console.WriteLine("Oh no! The fish got away. Keep trying!\n\n");
                    }
                }
                else
                {
                    Console.WriteLine("One minute went by...");
                    Thread.Sleep(500);
                }
            }

            Console.WriteLine("We're full! Let's look at what we caught.");

            // print all fish
            foreach(Fish fish in container){
                Console.WriteLine(fish.Name);
            }

            Console.WriteLine("\n\n\n");
        }

        private static void go_shop(List<FishingRod> all_rods)
        {
            Console.WriteLine("You have $ {0}. Would you like to buy something?", Money);
            int i = 1;
            foreach (FishingRod rod in all_rods)
            {
                Console.WriteLine("{0}. {1}", i++, rod.name);
            }
            int input = -1;
            while (input < 0 || input >= all_rods.Count)
            {
                input = Convert.ToInt32(Console.ReadLine()) - 1;
                if (input >= 0 && input < all_rods.Count && all_rods[input].price > Money)
                {
                    input = -1;
                    Console.WriteLine("\nYou don't have enough money, try another one.");
                    continue;
                }
            }
            Money -= all_rods[input].price;
            rodBuff = all_rods[input].buff;
            Console.WriteLine("\nWonderful, You've bought a {0}. You have $ {1} remaining. Hope to see you again soon.\n", all_rods[input].name, Money);
        }

        private static void sell_fish()
        {
            if (container.Count == 0)
            {
                Console.WriteLine("\nYou didn't catch any fish. Please come back when you have fish.\n", Money);
            }
            else
            {
                for (int i = 0 ; i <　container.Count ; i++)
                {
                    Money += container[i].MarketPrice;
                }
                container.Clear();
                Console.WriteLine("\nNow you have $ {0}. Thank you. Hope to see you again soon.\n", Money);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightingGame_KMC
{
    class Program
    {
        static void Main(string[] args)
        {
            // User selects character
            int user_character = 0;

            while(user_character < 1 || user_character > 3)
            {
                Console.WriteLine("Choose your character:");
                Console.WriteLine("1) Mage");
                Console.WriteLine("2) Rogue");
                Console.WriteLine("3) Tank");
                user_character = Convert.ToInt32(Console.ReadLine());
            }
            characters user = determine_character(user_character);


            // Computer randomly chooses a character.
            Random rand = new Random();
            int computer_character = rand.Next(1, 4);

            characters computer = determine_character(computer_character);


            // Announce computer character
            if (computer_character == 1)
            {
                Console.WriteLine("Computer chose Mage!");
            }
            else if (computer_character == 2)
            {
                Console.WriteLine("Computer chose Rogue!");
            }
            else
            {
                Console.WriteLine("Computer chose Tank!");
            }

            Console.WriteLine("Fight!!");


            // Main gameplay
            while (true)
            {
                // User chooses action. Depending on character, user has different actions
                Console.WriteLine("Choose your action: ");

                Console.WriteLine("1) Block");
                Console.WriteLine("2) Melee attack");
                if (user_character == 1)
                {
                    if (user.get_spec_num() > 0)
                        Console.WriteLine(string.Format("3) Magic attack ({0} left)", user.get_spec_num()));
                }

                int user_action = Convert.ToInt32(Console.ReadLine());
                int computer_action = computer.get_spec_num() > 0 ? rand.Next(1, 4) : rand.Next(1, 3);

                if (user_action == 1 || computer_action == 1)
                {
                    Console.WriteLine("Attack blocked. No damage!!");
                    continue;
                }
                // invalid input
                else if (user_action > 3 || user_action < 1)
                {
                    Console.WriteLine("You can't do that!!");
                    continue;
                }

                // user's turn
                fight(user, computer, user_action);

                // computer's turn
                fight(computer, user, computer_action);

                // who win the game
                if (computer.health_change(0) <= 0)
                {
                    Console.WriteLine("Computer died. You win!");
                    return;
                }

                if (user.health_change(0) <= 0)
                {
                    Console.WriteLine("You died. You lose!");
                    return;
                }

                Console.WriteLine(string.Format("User health: {0}", user.health_change(0)));
                Console.WriteLine(string.Format("Computer health: {0}", computer.health_change(0)));
            }



            // mage: 2 special attacks, weak melee
            // rogue: strong melee + random special attack
            // tank: if blocks special attack, reverses on them

            // block and attack
        }

        // determine which character they selected
        private static characters determine_character(int charac)
        {
            if (charac == 1)
            {
                return new mega();
            }
            // Set user's stats for Rogue
            else if (charac == 2)
            {
                return new rogue();
            }
            // Set user's stats for Tank
            else
            {
                return new tank();
            }
        }

        // fight function
        public static void fight(characters attacker, characters defender, int action)
        {
            int damage = 0;
            if (action == 2)
            {
                damage = attacker.melee_attack();
                Random rand = new Random();
                int critical_hit = rand.Next(1, 6);
                if (attacker is rogue && critical_hit == 1) damage += attacker.special_attack(); // special attack for rogue
            }
            else if (attacker is mega && action == 3) damage = attacker.special_attack(); // special attack for mega
            
            // if defender is tank, they immune some attack and reflect back to opponent
            if (defender is tank)
            {
                if (damage == attacker.melee_attack())
                {
                    defender.health_change(damage - defender.get_armor());
                }
                // if damage is greater than basic melee damage, it will be considered as special attack
                else
                {
                    attacker.health_change(damage);
                    Console.WriteLine(string.Format("Tank special armor rebounds attack. {0} damage against opponent.", damage));
                }
            }
            else defender.health_change(damage);
        }
    }

    // define characters
    public class characters
    {
        protected int user_special_attacks_left = 0;
        protected int health = 100;
        protected int melee_damage = 0;
        protected int special_damage = 0;
        protected int armor = 0;

        public int melee_attack()
        {
            return melee_damage;
        }

        public int special_attack()
        {
            user_special_attacks_left -= 1;
            return special_damage;
        }

        public int health_change(int damage)
        {
            health -= damage;
            return health;
        }

        public int get_spec_num()
        {
            return user_special_attacks_left;
        }

        public int get_armor()
        {
            return armor;
        }
    }

    public class mega : characters
    {
        public mega()
        {
            user_special_attacks_left = 2;
            melee_damage = 7;
            special_damage = 25;
        }
    }

    public class rogue : characters
    {
        public rogue()
        {
            melee_damage = 15;
            special_damage = 20;
        }
    }

    public class tank : characters
    {
        public tank()
        {
            melee_damage = 10;
            armor = 5;
        }
    }
}

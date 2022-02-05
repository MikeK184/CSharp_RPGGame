using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_Game
{
    internal class Player : Character
    {
        public Player(string name, int health, ConsoleColor color)
            : base(name, health, color, AsciAssets.Player)
        {

        }
        // Internal functions
        private void ThrowDirtAt (Character otherCharacter)
        {
            Write("You throw a clump of dirt ");
            int randNum = RandGenerator.Next(1, 100);
            if (randNum <= 90)
            {
                WriteLine("and it hits!");
                otherCharacter.TakeDamage(2);
            }
            else
            {
                WriteLine("and it misses...");
            }
        }
        // Internal functions
        private void SwingAt(Character otherCharacter)
        {
            Write("You take swing with stickity stick");
            int randNum = RandGenerator.Next(1, 100);
            if (randNum <= 50)
            {
                WriteLine("and it hits!");
                otherCharacter.TakeDamage(5);
            }
            else
            {
                WriteLine("and it misses...");
            }
        }
        public override void Fight(Character otherCharacter)
        {
            // WriteLine($"Player {Name} attacks {otherCharacter.Name}");
            ForegroundColor = Color;
            WriteLine($@"You are facing {otherCharacter.Name}. What would you like to do?

1) Pick up a clump of dirt and throw it (90% change to do 2 damage).
2) Take a swing with a stickity stick (50% change to do 5 damage).
");
            ConsoleKeyInfo keyInfo = ReadKey(true);
            if (keyInfo.Key == ConsoleKey.D1)
            {
                ThrowDirtAt(otherCharacter);
            } else if (keyInfo.Key == ConsoleKey.D2)
            {
                SwingAt(otherCharacter);
            } else
            {
                WriteLine("That's not a valid move, try again.!");
                Fight(otherCharacter);
                return;
            }
            ResetColor();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_Game
{
    internal class Bee : Character
    {
        private bool IsPoisneous;
        public Bee(string name, int health, ConsoleColor color, bool hasPoison)
            : base (name, health, color, AsciAssets.Bee)
        {
            IsPoisneous = hasPoison;
        }

        public void Fly()
        {
            Write($" {Name} ");
            WriteLine("Flies forawrd and deals 4 damage");
            
        }

        public void Sting()
        {
            Write($"{Name} ");
            if (IsPoisneous)
            {
                WriteLine("poisenous sting thing deals 6 damage");
            }
            else
            {
                WriteLine("sharp sting thingy deals 6 damage");
            }

        }

        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;

            int randNum = RandGenerator.Next(1, 100);
            if (randNum <= 25)
            {
                Fly();
                otherCharacter.TakeDamage(4);
            }
            else if (randNum > 25 && randNum <= 50)
            {
                Sting();
                otherCharacter.TakeDamage(6);
            }
            else
            {
                WriteLine($"{Name} misses...");
            }
            ResetColor();
        }
    }
}

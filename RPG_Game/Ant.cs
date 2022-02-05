using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_Game
{
    internal class Ant : Character
    {
        private int ChargingDistance;
        private Item CurrentItem;

        public Ant(string name, int health, ConsoleColor color, int chargingDistance)
            : base(name, health, color, AsciAssets.Ant)
        {

            ChargingDistance = chargingDistance;
        }

        public void PickUpItem(Item item)
        {
            CurrentItem = item;
        }
  
        public void Charge()
        {
            WriteLine($"{Name} charged forward {ChargingDistance} meters.");


            if (CurrentItem != null)
            {
                WriteLine($"It's carrying a {CurrentItem.Name} so it deals additional damage");
            }
            
        }

        public void Bite()
        {
            WriteLine($"{Name} bites and deals 4 damage!");
        }

        public override void Fight(Character otherCharacter)
        {
            ForegroundColor = Color;
            int randNum = RandGenerator.Next(1, 100);
            if (randNum <= 25)
            {
                Bite();
                otherCharacter.TakeDamage(4);
            } else if (randNum > 25 && randNum <= 50)
            {
                Charge();
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

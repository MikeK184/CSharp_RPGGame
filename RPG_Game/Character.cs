using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace RPG_Game
{
    internal class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int MaxHealth { get; protected set; }
        public ConsoleColor Color { get; protected set; }
        public string AsciArt { get; protected set; }
        // Kinda like an if check whenever we retrieve "isDead"
        public bool isDead { get => Health <= 0; }
        public bool isAlive { get => Health > 0; }


        // For randomised attacks
        public Random RandGenerator { get; protected set; }



        public Character(string name, int health, ConsoleColor color, string asciArt)
        {
            Name = name;
            Health = health;
            MaxHealth = health;
            Color = color;
            AsciArt = asciArt;
            RandGenerator = new Random();
        }

        // Just displays some info about our Ant
        public void DisplayInfo()
        {
            BackgroundColor = Color;
            Write($"--- {Name}  ---");
            ResetColor();

            ForegroundColor = Color;
            WriteLine($"\n--- {AsciArt}  ---\n");
            WriteLine($"Health: {Health}  ---");
            ResetColor();
        }

        // So child classes can override it
        public virtual void Fight(Character otherCharacter)
        {
            WriteLine("Enemy is fighting!");
        }

        public void TakeDamage(int damageAmount)
        {
            Health -= damageAmount;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void DisplayHealthBar()
        {
            ForegroundColor = Color;
            WriteLine($"{Name}'s Health:");
            ResetColor();
            Write("[");
            // Draw "Hleath" hit points that are filled in:
            BackgroundColor = ConsoleColor.Green;
            for (int i = 0; i < Health; i++)
            {
                Write(" ");
            }
            BackgroundColor = ConsoleColor.Gray;
            for (int i = Health; i < MaxHealth; i++)
            {
                Write(" ");
            }
            ResetColor();
            WriteLine($"] ({Health}/{MaxHealth})");

        }
    }
}

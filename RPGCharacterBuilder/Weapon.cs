using System;

namespace RPGCharacterBuilder
{
    public class Weapon : Item
    {
        private const string Type = "Weapon";

        public int Damage { get; }

        /// <summary>
        /// Create a weapon of specified name, description, and damage
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="damage"></param>
        public Weapon(string name, string description, int damage)
            : base(Type, name, description)
        {
            Damage = damage;
        }

        /// <summary>
        /// Print weapon details. This calls the generic printItem() method and then prints the weapon damage to the console
        /// </summary>
        public void PrintWeapon()
        {
            base.PrintItem();
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("------------------------------");
        }
    }
}

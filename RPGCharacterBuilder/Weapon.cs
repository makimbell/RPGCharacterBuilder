using System;

namespace RPGCharacterBuilder
{
    public class Weapon : Item
    {
        private const string Type = "Weapon";

        public int Damage { get; }

        public Weapon(string name, string description, int damage)
            : base(Type, name, description)
        {
            Damage = damage;
        }

        public void PrintWeapon()
        {
            base.PrintItem();
            Console.WriteLine("Damage: " + Damage);
            Console.WriteLine("------------------------------");
        }
    }
}

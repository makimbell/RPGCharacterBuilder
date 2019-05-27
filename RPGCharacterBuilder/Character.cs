using System;
using System.Collections.Generic;
using System.Text;

namespace RPGCharacterBuilder
{
    // This class shouldn't be created. You should only create instances of its subclasses
    class Character
    {
        private readonly string _name;

        // Level starts at 1. The other fields are determined by the character class
        private int _level;
        private int _healthMultiplier, _strengthMultiplier, _defenseMultiplier;

        public Character(string name, int healthMultiplier, int strengthMultiplier, int defenseMultiplier)
        {
            _name = name;
            _healthMultiplier = healthMultiplier;
            _strengthMultiplier = strengthMultiplier;
            _defenseMultiplier = defenseMultiplier;
            _level = 1;
        }

        // Calculated properties: TotalHealth, Strength, Defense
        // TODO: Incorporate item modifiers here as well. Also come up with a better formula
        public int TotalHealth => _level * _healthMultiplier;
        public int Strength => _level * _strengthMultiplier;
        public int Defense => _level * _defenseMultiplier;

        // Name getter (no setter -- cannot change name)
        public string Name { get => _name; }

        // Prints character summary
        public void PrintCharacter(string characterClass)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Character name: " + _name);
            Console.WriteLine("Level " + _level + " " + characterClass);
            Console.WriteLine("Total Health: " + TotalHealth);
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Defense: " + Defense);
        }

        // Level up one level
        public void LevelUp()
        {
            _level++;
        }

        // Level up a specified number of levels
        public void LevelUp(int levels)
        {
            _level += levels;
        }

        //Equip a weapon, armor, or special item
        // TODO: Complete
        // TODO: Override methods so that you can pass in Weapon, Armor, or SpecialItem
        public void Equip()
        {
            // TODO: Show what is currently equipped and ask to confirm
            Console.WriteLine("Equipping _____");
        }
    }
}

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
        private double _healthMultiplier, _strengthMultiplier, _defenseMultiplier;

        // Constructor with no level specified
        public Character(string name, double healthMultiplier, double strengthMultiplier, double defenseMultiplier)
        {
            _name = name;
            _healthMultiplier = healthMultiplier;
            _strengthMultiplier = strengthMultiplier;
            _defenseMultiplier = defenseMultiplier;
            _level = 1;
        }

        // Constructor with level specified
        public Character(string name, double healthMultiplier, double strengthMultiplier, double defenseMultiplier, int level)
        {
            _name = name;
            _healthMultiplier = healthMultiplier;
            _strengthMultiplier = strengthMultiplier;
            _defenseMultiplier = defenseMultiplier;
            _level = level;
        }

        // Calculated properties: TotalHealth, Strength, Defense
        // TODO: Incorporate item modifiers here as well. Also come up with a better formula and possibly get rid of casting
        public int TotalHealth => (int)(_level * _healthMultiplier);
        public int Strength => (int)(_level * _strengthMultiplier);
        public int Defense => (int)(_level * _defenseMultiplier);

        // Name getter (no setter -- cannot change name)
        public string Name { get => _name; }

        /// <summary>
        /// Prints character summary
        /// </summary>
        /// <param name="characterClass"></param>
        public void PrintCharacter(string characterClass)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Character name: " + _name);
            Console.WriteLine("Level " + _level + " " + characterClass);
            Console.WriteLine("Total Health: " + TotalHealth);
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Defense: " + Defense);
        }

        /// <summary>
        /// Levels up one level unless already at max level (99)
        /// </summary>
        public void LevelUp()
        {
            if (_level != 99)
            {
                _level++;
            }
        }

        /// <summary>
        /// Levels up a specified number of levels. If going over max level, new level will equal max level (99)
        /// </summary>
        /// <param name="levels"></param>
        public void LevelUp(int levels)
        {
            if (levels <= 0)
            {
                // Do nothing
            }
            else if (_level + levels > 99)
            {
                _level = 99;
            }
            else
            {
                _level = levels;
            }
        }

        /// <summary>
        /// Equips a weapon, armor, or special item
        /// </summary>
        public void Equip()
        {
            // TODO: Complete
            // TODO: Override methods so that you can pass in Weapon, Armor, or SpecialItem
            // TODO: Show what is currently equipped and ask to confirm
            Console.WriteLine("Equipping _____");
        }
    }
}

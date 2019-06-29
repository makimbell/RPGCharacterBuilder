using System;
using System.Collections.Generic;

namespace RPGCharacterBuilder
{
    public abstract class Character
    {
        private readonly string _name, _characterClass;
        private int _level;
        private readonly double _healthMultiplier, _strengthMultiplier, _defenseMultiplier, _dexterityMultiplier;
        private Weapon _equippedWeapon;
        private int _healthFromItems, _strengthFromItems, _defenseFromItems, _dexterityFromItems;

        private const int LevelCap = 99;

        /// <summary>
        /// Constructor for creating a Character of the specified level.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="healthMultiplier"></param>
        /// <param name="strengthMultiplier"></param>
        /// <param name="defenseMultiplier"></param>
        /// <param name="dexterityMultiplier"></param>
        /// <param name="level"></param>
        public Character(string name, string characterClass, double healthMultiplier, double strengthMultiplier, 
                        double defenseMultiplier, double dexterityMultiplier, int level)
        {
            _name = name;
            _characterClass = characterClass;
            _healthMultiplier = healthMultiplier;
            _strengthMultiplier = strengthMultiplier;
            _defenseMultiplier = defenseMultiplier;
            _dexterityMultiplier = dexterityMultiplier;

            // Limit level to LevelCap
            _level = level > LevelCap ? LevelCap : level;
        }

        // Calculated properties: TotalHealth, Strength, Defense, Dexterity
        public int TotalHealth => (int)(_level * _healthMultiplier) + _healthFromItems;
        public int Strength => (int)(_level * _strengthMultiplier) + _strengthFromItems;
        public int Defense => (int)(_level * _defenseMultiplier) + _defenseFromItems;
        public int Dexterity => (int)(_level * _dexterityMultiplier) + _dexterityFromItems;
        public string Name { get => _name; }
        public int Level { get => _level; }
        public string CharacterClass { get => _characterClass; }

        /// <summary>
        /// Prints character summary
        /// </summary>
        /// <param name="characterClass"></param>
        /// 
        public void PrintCharacter(bool detail)
        {
            // TODO: Print what items the character has
            // TODO: Add colors if desired (Strength is red, dex is green, etc.)
            // Console.WriteLine("------------------------------");
            Console.WriteLine(_name);
            Console.WriteLine("Level " + _level + " " + _characterClass);
            if (detail)
            {
                Console.WriteLine("Total Health: " + TotalHealth);
                Console.WriteLine("Strength: " + Strength);
                Console.WriteLine("Defense: " + Defense);
                Console.WriteLine("Dexterity: " + Dexterity);
            }
        }

        /// <summary>
        /// Levels up one level unless already at max level
        /// </summary>
        public void LevelUp()
        {
            if (_level != LevelCap)
            {
                _level++;
            }
        }

        /// <summary>
        /// Levels up a specified number of levels. If going over max level, new level will equal max level
        /// </summary>
        /// <param name="levels"></param>
        public void LevelUp(int levels)
        {
            if (levels <= 0)
            {
                // Do nothing
            }
            else if (_level + levels > LevelCap)
            {
                _level = LevelCap;
            }
            else
            {
                _level += levels;
            }
        }

        /// <summary>
        /// Equips a weapon, armor, or special item
        /// </summary>
        public void Equip(Item item)
        {
            if (_equippedWeapon == null)
            {
                if (item is Weapon)
                {
                    _equippedWeapon = (Weapon)item;
                }
            }
            RecalculateStatsFromItems();
        }
        public void Unequip()
        {
            // TODO: Ask whether you want to Unequip weapon, armor, or special item, then do it
        }
        /// <summary>
        /// Recalculates the _xFromItems fields for use in calculating stat properties. This is called after changing (equipping or unequipping) any items
        /// </summary>
        private void RecalculateStatsFromItems()
        {
            // TODO: Incorporate other items' modifiers
            _healthFromItems = _equippedWeapon.HealthModifier; // + other items'
            _strengthFromItems = _equippedWeapon.StrengthModifier; // + other items'
            _defenseFromItems = _equippedWeapon.DefenseModifier; // + other items'
            _dexterityFromItems = _equippedWeapon.DexterityModifier; // + other items'
        }
    }
}

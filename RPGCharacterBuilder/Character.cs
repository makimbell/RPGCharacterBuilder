﻿using System;
using System.Collections.Generic;

namespace RPGCharacterBuilder
{
    public abstract class Character
    {
        private readonly string _name, _characterClass;
        private int _level;
        private readonly double _healthMultiplier, _strengthMultiplier, _defenseMultiplier, _dexterityMultiplier;
        private Weapon _equippedWeapon;

        private const int LevelCap = 99;

        /// <summary>
        /// Constructor for creating a Character of the specified level
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

        // Calculated and auto properties
        public int TotalHealth => (int)(_level * _healthMultiplier);
        public int Strength => (int)(_level * _strengthMultiplier);
        public int Defense => (int)(_level * _defenseMultiplier);
        public int Dexterity => (int)(_level * _dexterityMultiplier);
        public string Name { get => _name; }
        public int Level { get => _level; }
        public bool WeaponEquipped { get => _equippedWeapon != null; }
        public Weapon Weapon { get => _equippedWeapon; }
        public string CharacterClass { get => _characterClass; }

        /// <summary>
        /// Prints character summary
        /// </summary>
        /// <param name="characterClass"></param>
        /// 
        public void PrintCharacter()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Level " + _level + " " + _characterClass);
            if (WeaponEquipped)
            {
                Console.WriteLine("Weapon equipped");
            }
        }

        /// <summary>
        /// Prints character summary with detail
        /// </summary>
        public void PrintCharacterDetail()
        {
            Console.WriteLine(_name);
            Console.WriteLine("Level " + _level + " " + _characterClass);
            Console.WriteLine("Total Health: " + TotalHealth);
            Console.WriteLine("Strength: " + Strength);
            Console.WriteLine("Defense: " + Defense);
            Console.WriteLine("Dexterity: " + Dexterity);
            if (WeaponEquipped)
            {
                _equippedWeapon.PrintWeapon();
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
        /// Equips a weapon
        /// </summary>
        public void Equip(Item item)
        {
            bool confirmed = true;

            if (item is Weapon)
            {
                if (_equippedWeapon != null)
                {
                    Console.Write("Overwrite currently equipped weapon? (y/n): ");
                    string yesno = Console.ReadLine().ToUpper();
                    confirmed = (yesno == "Y") ?  true : false;
                }

                if (confirmed)
                {
                    _equippedWeapon = (Weapon)item;
                }
            }

            RecalculateStatsFromItems();
        }

        /// <summary>
        /// Unequip currently equipped weapon
        /// </summary>
        public void Unequip()
        {
            _equippedWeapon = null;
            RecalculateStatsFromItems();
        }

        /// <summary>
        /// Recalculates the _xFromItems fields for use in calculating stat properties. This is called after changing (equipping or unequipping) any items
        /// </summary>
        private void RecalculateStatsFromItems()
        {
            // TODO: This doesn't do anything yet
        }
    }
}

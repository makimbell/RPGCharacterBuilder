﻿using System;

namespace RPGCharacterBuilder
{
    public abstract class Item
    {
        private readonly string _name, _description, _itemType;
        private readonly int _healthModifier, _strengthModifier, _defenseModifier, _dexterityModifier;

        public Item(string itemType, string name, string description, int healthMod, int strengthMod, int defenseMod, int dexterityMod)
        {
            _itemType = itemType;
            _name = name;
            _description = description;
            _healthModifier = healthMod;
            _strengthModifier = strengthMod;
            _defenseModifier = defenseMod;
            _dexterityModifier = dexterityMod;
        }

        public string Description { get => _description; }
        public int HealthModifier { get => _healthModifier; }
        public int StrengthModifier { get => _strengthModifier; }
        public int DefenseModifier { get => _defenseModifier; }
        public int DexterityModifier { get => _dexterityModifier; }
        public string Name { get => _name; }
        public string ItemType { get => _itemType; }

        public void PrintItem()
        {
            // TODO: Add colors if desired (Strength is red, dex is green, etc.)
            Console.WriteLine("------------------------------");
            Console.WriteLine("Item name: " + _name);
            if(_description != null) Console.WriteLine("Description: " + _description);
            if(_healthModifier > 0) Console.WriteLine("Health modifier: " + _healthModifier);
            if (_strengthModifier > 0) Console.WriteLine("Strength modifier: " + _strengthModifier);
            if (_defenseModifier > 0) Console.WriteLine("Defense modifier: " + _defenseModifier);
            if (_dexterityModifier > 0) Console.WriteLine("Dexterity modifier: " + _dexterityModifier);
        }
    }
}
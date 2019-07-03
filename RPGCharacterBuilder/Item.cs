using System;

namespace RPGCharacterBuilder
{
    public abstract class Item
    {
        private readonly string _name, _description, _itemType;
        private readonly int _healthModifier, _strengthModifier, _defenseModifier, _dexterityModifier;

        public Item(string itemType, string name, string description)
        {
            _itemType = itemType;
            _name = name;
            _description = description;
        }

        public string Description { get => _description; }
        public string Name { get => _name; }
        public string ItemType { get => _itemType; }

        public void PrintItem()
        {
            // TODO: Add colors if desired (Strength is red, dex is green, etc.)
            Console.WriteLine("------------------------------");
            Console.WriteLine("Item name: " + _name);
            if(_description != null) Console.WriteLine("Description: " + _description);
        }
    }
}

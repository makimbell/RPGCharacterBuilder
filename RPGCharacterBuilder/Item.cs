using System;

namespace RPGCharacterBuilder
{
    public abstract class Item
    {
        private readonly string _name, _description, _itemType;
        private readonly int _healthModifier, _strengthModifier, _defenseModifier, _dexterityModifier;

        /// <summary>
        /// Creates an item of the specified type, with the given name and description
        /// </summary>
        /// <param name="itemType"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Item(string itemType, string name, string description)
        {
            _itemType = itemType;
            _name = name;
            _description = description;
        }

        public string Description { get => _description; }
        public string Name { get => _name; }
        public string ItemType { get => _itemType; }

        /// <summary>
        /// Print the item details
        /// </summary>
        public void PrintItem()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("Item name: " + _name);
            if(_description != null) Console.WriteLine("Description: " + _description);
        }
    }
}

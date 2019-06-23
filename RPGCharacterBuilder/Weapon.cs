namespace RPGCharacterBuilder
{
    class Weapon : Item
    {
        private const string Type = "Weapon";

        public Weapon(string name, string description, int healthMod, int strengthMod, int defenseMod, int dexterityMod)
            : base(Type,
                  name,
                  description,
                  healthMod,
                  strengthMod,
                  defenseMod,
                  dexterityMod)
        {
        }
    }
}

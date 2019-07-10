namespace RPGCharacterBuilder
{
    public class Paladin : Character
    {
        // Paladin type string
        private const string CharacterClassString = "Paladin";

        // Paladin class constants
        private const double HealthMultiplier = 6.5;
        private const double StrengthMultiplier = 3.5;
        private const double DefenseMultiplier = 7.0;
        private const double DexterityMultiplier = 3.0;

        /// <summary>
        /// Constructor for creating a Paladin of the specified level. If no level is given, the default of 1 will be used.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Paladin(string name, int level = 1)
            : base(name,
                  CharacterClassString,
                  HealthMultiplier,
                  StrengthMultiplier,
                  DefenseMultiplier,
                  DexterityMultiplier,
                  level)
        {
        }
    }
}

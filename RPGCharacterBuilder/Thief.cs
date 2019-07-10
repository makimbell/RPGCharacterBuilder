namespace RPGCharacterBuilder
{
    public class Thief : Character
    {
        // Thief type string
        private const string CharacterClassString = "Thief";

        // Thief class constants
        private const double HealthMultiplier = 4.5;
        private const double StrengthMultiplier = 3.0;
        private const double DefenseMultiplier = 3.5;
        private const double DexterityMultiplier = 9.0;

        /// <summary>
        /// Constructor for creating a Thief of the specified level. If no level is given, the default of 1 will be used.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Thief(string name, int level = 1)
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

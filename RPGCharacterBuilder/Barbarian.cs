namespace RPGCharacterBuilder
{
    public class Barbarian : Character
    {
        private const string CharacterClassString = "Barbarian";

        private const double HealthMultiplier = 5.5;
        private const double StrengthMultiplier = 7.0;
        private const double DefenseMultiplier = 5.0;
        private const double DexterityMultiplier = 2.5;

        /// <summary>
        /// Constructor for creating a Barbarian of the specified level. If no level is given, the default of 1 will be used.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Barbarian(string name, int level = 1) 
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

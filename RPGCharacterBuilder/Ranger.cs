namespace RPGCharacterBuilder
{
    public class Ranger : Character
    {
        private const string CharacterClass = "Barbarian";

        private const double HealthMultiplier = 4.0;
        private const double StrengthMultiplier = 4.5;
        private const double DefenseMultiplier = 4.5;
        private const double DexterityMultiplier = 7.0;

        /// <summary>
        /// Constructor for creating a Ranger with no specified level. This will create a level 1 Ranger.
        /// </summary>
        /// <param name="name"></param>
        public Ranger(string name)
            : base(name,
                  CharacterClass,
                  HealthMultiplier,
                  StrengthMultiplier,
                  DefenseMultiplier,
                  DexterityMultiplier)
        {
        }

        /// <summary>
        /// Constructor for creating a Ranger of the specified level.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Ranger(string name, int level)
            : base(name,
                  CharacterClass,
                  HealthMultiplier,
                  StrengthMultiplier,
                  DefenseMultiplier,
                  DexterityMultiplier,
                  level)
        {
        }
    }
}

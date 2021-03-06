﻿namespace RPGCharacterBuilder
{
    public class Ranger : Character
    {
        // Ranger type string
        private const string CharacterClassString = "Ranger";

        // Ranger class constants
        private const double HealthMultiplier = 4.0;
        private const double StrengthMultiplier = 4.5;
        private const double DefenseMultiplier = 4.5;
        private const double DexterityMultiplier = 7.0;

        /// <summary>
        /// Constructor for creating a Ranger of the specified level. If no level is given, the default of 1 will be used.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Ranger(string name, int level = 1)
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

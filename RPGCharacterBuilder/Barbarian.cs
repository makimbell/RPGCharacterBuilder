﻿namespace RPGCharacterBuilder
{
    class Barbarian : Character
    {
        // These should add up to 20 for character balance
        private const double HealthMultiplier = 5.5;
        private const double StrengthMultiplier = 7.0;
        private const double DefenseMultiplier = 5.0;
        private const double DexterityMultiplier = 2.5;

        /// <summary>
        /// Constructor for creating a Barbarian with no specified level. This will create a level 1 Barbarian.
        /// </summary>
        /// <param name="name"></param>
        public Barbarian(string name) 
            : base(name, 
                  "Barbarian",
                  HealthMultiplier,
                  StrengthMultiplier,
                  DefenseMultiplier,
                  DexterityMultiplier)
        {
        }

        /// <summary>
        /// Constructor for creating a Barbarian of the specified level.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="level"></param>
        public Barbarian(string name, int level) 
            : base(name,
                  "Barbarian",
                  HealthMultiplier,
                  StrengthMultiplier,
                  DefenseMultiplier,
                  DexterityMultiplier,
                  level)
            // TODO: This will allow you to create a character over level 99. Lol. Fix this before creating more classes.
            //  Or should this be fixed during input? If user enters a level over 99, then throw exception?
        {
        }
    }
}
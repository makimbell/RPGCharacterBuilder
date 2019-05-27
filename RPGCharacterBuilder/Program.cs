using System;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Character characterOspov = new Character("Ospov", 1.5, 2.2, 3.1);
            characterOspov.PrintCharacter("Barbarian");

            characterOspov.LevelUp(50);
            characterOspov.PrintCharacter("Barbarian");

            Console.ReadLine();

        }
    }
}

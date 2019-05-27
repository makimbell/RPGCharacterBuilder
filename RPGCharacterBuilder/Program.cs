using System;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Character characterOspov = new Character("Ospov", 1, 2, 3);
            characterOspov.PrintCharacter("Barbarian");

            characterOspov.LevelUp(50);
            characterOspov.PrintCharacter("Barbarian");

            Console.ReadLine();
        }
    }
}

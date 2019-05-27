using System;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Character characterOspov = new Character("Ospov", "Barbarian", 6.5, 2.2, 3.1, 2);
            characterOspov.PrintCharacter();

            Console.ReadLine();

            characterOspov.LevelUp(50);
            characterOspov.PrintCharacter();

            Console.ReadLine();

            Character character = new Character("Bob", "Boy", 1, 2, 3, 5, 50);
            character.PrintCharacter();
            Console.ReadLine();
        }
    }
}

using System;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Barbarian barbarian = new Barbarian("Bob");
            barbarian.PrintCharacter();

            Console.ReadLine();
            
            barbarian.LevelUp(50);
            barbarian.PrintCharacter();

            Console.ReadLine();
        }
    }
}

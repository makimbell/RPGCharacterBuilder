using System;
using System.IO;
using System.Reflection;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main()
        {
            // TODO: Make blank arrays of each character type to be populated by the Read function

            //Barbarian barbarian = new Barbarian("Bob");
            //barbarian.PrintCharacter();

            //Console.ReadLine();
            
            //barbarian.LevelUp(50);
            //barbarian.PrintCharacter();

            // TEST CODE

            // Read each line of the file into a string array. Each element
            // of the array is one line of the file.
            string[] lines = File.ReadAllLines("..\\..\\..\\TestFile.txt");

            // Display the file contents by using a foreach loop.
            Console.WriteLine("Characters read from TestFile.txt = ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.

                // TODO: Use currentData[0] to determine 
                var currentData = line.Split(' ');
                Barbarian barbarian1 = new Barbarian(currentData[1], Int32.Parse(currentData[2]));
                barbarian1.PrintCharacter();
            }

            // /TEST CODE

            Console.ReadLine();
        }
    }
}

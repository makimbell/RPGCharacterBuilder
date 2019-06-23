using System;
using System.Collections.Generic;
using System.IO;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main()
        {
            List<Character> characters = new List<Character>();

            ReadCharactersFromFile(characters);

            var cmd = Console.ReadLine();
            while (cmd != "")
            {
                if (cmd == "print")
                {
                    Console.Clear();
                    foreach (Character character in characters)
                    {
                        character.PrintCharacter(false);
                    }
                }
                else if (cmd == "print detail")
                {
                    Console.Clear();
                    foreach (Character character in characters)
                    {
                        character.PrintCharacter(true);
                    }
                }
                cmd = Console.ReadLine();
            }

        }

        private static void ReadCharactersFromFile(List<Character> characters)
        {
            // Read each line of the file into a string array. Each element of the array is one line of the file.
            string[] lines = File.ReadAllLines("..\\..\\..\\CharacterData.txt");
            // Read in the contents of CharacterData.txt. Each line represents an object (character or item)
            foreach (string line in lines)
            {
                var currentData = line.Split(',');

                // Character type, Name, Level
                // Sample data: ["Barbarian","Andy",40]
                switch (currentData[0])
                {
                    case "Barbarian":
                        characters.Add(new Barbarian(currentData[1], Int32.Parse(currentData[2])));
                        break;
                    case "Ranger":
                        characters.Add(new Ranger(currentData[1], Int32.Parse(currentData[2])));
                        break;
                }
            }
        }
    }
}

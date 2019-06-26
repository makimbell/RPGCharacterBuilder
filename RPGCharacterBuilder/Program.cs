using System;
using System.Collections.Generic;
using System.IO;

namespace RPGCharacterBuilder
{
    class Program
    {
        private static List<Character> characters = new List<Character>();
        static void Main()
        {
            ReadCharactersFromFile();

            // Start interactive menu
            string userInput;
            do
            {
                userInput = HomeMenu();
            } while (userInput != "0");
        }
        private static void ReadCharactersFromFile()
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
        private static string HomeMenu()
        {
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Main menu");
            Console.WriteLine("===========================");
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Show list of characters");
            Console.WriteLine("2. Show character detail");
            Console.WriteLine("0. Quit");
            Console.WriteLine("");
            Console.Write("Choice: ");
            var userInput = Console.ReadLine();
            {
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        foreach (Character character in characters)
                        {
                            character.PrintCharacter(false);
                        }
                        EnterToReturnHome();
                        break;

                    case "2":
                        Console.Clear();
                        foreach (Character character in characters)
                        {
                            character.PrintCharacter(true);
                        }

                        EnterToReturnHome();
                        break;
                }
                return userInput;
            }
        }
        private static void EnterToReturnHome()
        {
            Console.WriteLine("");
            Console.WriteLine("==============================");
            Console.WriteLine("Press enter to return to menu");
            Console.ReadLine();
        }
    }
}

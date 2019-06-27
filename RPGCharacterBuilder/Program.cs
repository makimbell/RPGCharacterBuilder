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

            // Start interactive menu. Loop until user enters 0 in main menu
            string userInput;
            do
            {
                userInput = HomeMenu();
            } while (userInput != "0");

            // TODO: WriteCharactersToFile();
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
            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Main menu");
            Console.WriteLine("===========================");
            Console.WriteLine("");

            // Show options
            Console.WriteLine("1. Show character list");
            Console.WriteLine("0. Quit");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get input
            var userInput = Console.ReadLine();

            // If user enters 1, show character list
            if (userInput == "1")
            {
                ShowCharacterList();
            }

            // Return value to main
            return userInput;
        }

        private static void ShowCharacterList()
        {
            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Character list");
            Console.WriteLine("===========================");

            // Show content
            int index = 1;
            foreach (Character character in characters)
            {
                Console.Write("[{0}] - ", index);
                character.PrintCharacter(false);
                Console.WriteLine("");
                index++;
            }

            // Show options
            Console.WriteLine("1-{0}. View character detail", characters.Count);
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get input
            var userInput = Console.ReadLine();

            // If the user enters the (1-based) index of a character, display that character's detail. Return to character list when done
            try
            {
                if (Int32.Parse(userInput) > 0 && Int32.Parse(userInput) <= characters.Count)
                {
                    ShowCharacterDetail(Int32.Parse(userInput));
                    ShowCharacterList();
                }
            }
            catch
            {
                // Do nothing. This will return to the menu that called the ShowCharacterList() method
            }
        }

        private static void ShowCharacterDetail(int index)
        {
            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Character detail");
            Console.WriteLine("===========================");
            Console.WriteLine("");

            // Show content
            characters[index - 1].PrintCharacter(true);

            // Show options
            Console.WriteLine("");
            Console.WriteLine("1. Level character up");
            Console.WriteLine("0. Return to character list");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get input
            var userInput = Console.ReadLine();

            // If user enters 1, level up by one
            if (userInput == "1")
            {
                characters[index - 1].LevelUp();
            }
        }
    }
}

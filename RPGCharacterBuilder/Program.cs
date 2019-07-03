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
            // File path for character data file
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var filePath = Path.Combine(directory.FullName, "CharacterData.csv");

            // Try to read characters from file and populate characters list. If file is not found, create default character list
            if (File.Exists(filePath))
            {
                ReadCharactersFromFile(filePath);
            }
            else
            {
                AddCharacterToList("Barbarian", "Andy", 50);
                AddCharacterToList("Ranger", "Kristine", 50);
            }

            // Start interactive menu. Loop until user enters 0 in main menu
            string userInput;
            do
            {
                userInput = MainMenu();
            } while (userInput != "0");

            WriteCharactersToFile(filePath);
        }

        private static void ReadCharactersFromFile(string filePath)
        {
            // Read each line of the file into a string array. Each element of the array is one line of the file.
            string[] lines = File.ReadAllLines(filePath);
            // Read in the contents of the character data file. Each line represents an object (character or item)
            foreach (string line in lines)
            {
                var currentData = line.Split(',');
                
                // [0]-Class, [1]-Name, [2]-Level
                AddCharacterToList(currentData[0], currentData[1], Int32.Parse(currentData[2]));
            }
        }

        private static void AddCharacterToList(string characterClass, string characterName, int characterLevel)
        {
            switch (characterClass)
            {
                case "Barbarian":
                    characters.Add(new Barbarian(characterName, characterLevel));
                    break;
                case "Ranger":
                    characters.Add(new Ranger(characterName, characterLevel));
                    break;
            }
        }

        private static void WriteCharactersToFile(string filePath)
        {
            List<string> lines = new List<string>();

            // For every Character in characters list, write that line to the file
            foreach (Character character in characters)
            {
                lines.Add(character.CharacterClass + "," + character.Name + "," + character.Level);
            }

            // TODO: Make this compatible with Mac
            File.WriteAllLines(filePath, lines);
        }

        private static string MainMenu()
        {
            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Main menu");
            Console.WriteLine("===========================");
            Console.WriteLine("");

            // Show options
            Console.WriteLine("1. Show character list");
            Console.WriteLine("2. Create a new character");
            Console.WriteLine("0. Quit");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get input
            var userInput = Console.ReadLine();

            // If user enters 1, show character list
            if (userInput == "1")
            {
                CharacterListMenu();
            }
            else if (userInput == "2")
            {
                CreateCharacterMenu();
            }

            // Return value to main
            return userInput;
        }

        private static void CharacterListMenu()
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
                character.PrintCharacter();
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
                    CharacterDetailMenu(Int32.Parse(userInput));
                    CharacterListMenu();
                }
            }
            catch
            {
                // Returns to MainMenu
            }
        }

        private static void CreateCharacterMenu()
        {
            string characterClass, name;
            int level;

            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Create a character");
            Console.WriteLine("===========================");

            // Show options
            Console.WriteLine("1. Create a barbarian");
            Console.WriteLine("2. Create a ranger");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get user input for character class
            var userInput = Console.ReadLine();

            if (userInput == "1")
            {
                characterClass = "Barbarian";
            }
            else if (userInput == "2")
            {
                characterClass = "Ranger";
            }
            else
            {
                characterClass = "Barbarian"; // Default in case the user doesn't choose a valid option
            }

            // Get input for character name
            Console.WriteLine("");
            Console.Write("Character name: ");
            name = Console.ReadLine();

            // Get user input for level
            Console.WriteLine("");
            Console.Write("Character level: ");
            level = Int32.Parse(Console.ReadLine());

            // Create character
            AddCharacterToList(characterClass, name, level);
        }

        private static void CharacterDetailMenu(int index)
        {
            // Show menu header
            Console.Clear();
            Console.WriteLine("===========================");
            Console.WriteLine("Character detail");
            Console.WriteLine("===========================");
            Console.WriteLine("");

            // Show content
            characters[index - 1].PrintCharacterDetail();

            // Show options
            Console.WriteLine("");
            Console.WriteLine("1. Level character up");
            Console.WriteLine("2. Delete character");
            Console.WriteLine("3. Equip weapon");
            Console.WriteLine("4. Unequip weapon");
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
            // If user enters 2, delete character
            else if (userInput == "2")
            {
                characters.RemoveAt(index - 1);
            }
            // If user enters 3, create and equip a weapon
            else if (userInput == "3")
            {
                Console.Write("Weapon name: ");
                string weaponName = Console.ReadLine();
                Console.Write("Weapon description: ");
                string weaponDescription = Console.ReadLine();
                Console.Write("Damage: ");
                int weaponDamage = Int32.Parse(Console.ReadLine());

                characters[index - 1].Equip(new Weapon(weaponName, weaponDescription, weaponDamage));
            }
            // If user enters 4, unequip the weapon
            else if (userInput == "4")
            {
                characters[index - 1].Unequip();
            }
        }
    }
}

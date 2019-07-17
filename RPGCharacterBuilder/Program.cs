using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace RPGCharacterBuilder
{
    class Program
    {
        // List for storing all character instances
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
                AddCharacterToList("Barbarian", "Barbara", 50);
                AddCharacterToList("Ranger", "Roger", 50);
                AddCharacterToList("Paladin", "Pally", 50);
                AddCharacterToList("Sorcerer", "Sorcy", 50);
                AddCharacterToList("Thief", "Theodore", 50);
            }

            // Show splash screen for 5 seconds
            ShowSplashScreen(5000);

            // Start interactive menu. Loop until user enters 0 in main menu
            string userInput;
            do
            {
                userInput = MainMenu();
            } while (userInput != "0");

            // Write characters to file before the program closes
            WriteCharactersToFile(filePath);
        }

        private static void ShowSplashScreen(int displayTime)
        {
            Console.WriteLine("");
            Console.WriteLine("                            ██████╗ ██████╗  ██████╗");
            Console.WriteLine("                            ██╔══██╗██╔══██╗██╔════╝");
            Console.WriteLine("                            ██████╔╝██████╔╝██║  ███╗");
            Console.WriteLine("                            ██╔══██╗██╔═══╝ ██║   ██║");
            Console.WriteLine("                            ██║  ██║██║     ╚██████╔╝");
            Console.WriteLine("                            ╚═╝  ╚═╝╚═╝      ╚═════╝");
            Console.WriteLine("");
            Console.WriteLine("      ██████╗██╗  ██╗ █████╗ ██████╗  █████╗  ██████╗████████╗███████╗██████╗");
            Console.WriteLine("     ██╔════╝██║  ██║██╔══██╗██╔══██╗██╔══██╗██╔════╝╚══██╔══╝██╔════╝██╔══██╗");
            Console.WriteLine("     ██║     ███████║███████║██████╔╝███████║██║        ██║   █████╗  ██████╔╝");
            Console.WriteLine("     ██║     ██╔══██║██╔══██║██╔══██╗██╔══██║██║        ██║   ██╔══╝  ██╔══██╗");
            Console.WriteLine("     ╚██████╗██║  ██║██║  ██║██║  ██║██║  ██║╚██████╗   ██║   ███████╗██║  ██║");
            Console.WriteLine("      ╚═════╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═╝ ╚═════╝   ╚═╝   ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine("");
            Console.WriteLine("               ██████╗ ██╗   ██╗██╗██╗     ██████╗ ███████╗██████╗");
            Console.WriteLine("               ██╔══██╗██║   ██║██║██║     ██╔══██╗██╔════╝██╔══██╗");
            Console.WriteLine("               ██████╔╝██║   ██║██║██║     ██║  ██║█████╗  ██████╔╝");
            Console.WriteLine("               ██╔══██╗██║   ██║██║██║     ██║  ██║██╔══╝  ██╔══██╗");
            Console.WriteLine("               ██████╔╝╚██████╔╝██║███████╗██████╔╝███████╗██║  ██║");
            Console.WriteLine("               ╚═════╝  ╚═════╝ ╚═╝╚══════╝╚═════╝ ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("By Andy Kimbell");

            Thread.Sleep(displayTime);                                                                     
        }

        private static void ReadCharactersFromFile(string filePath)
        {
            int currentCharacterIndex = 0;

            // Read each line of the file into a string array. Each element of the array is one line of the file.
            string[] lines = File.ReadAllLines(filePath);

            // Read in the contents of the character data file. Each line represents an object
            foreach (string line in lines)
            {
                var currentData = line.Split(',');
                
                // [0]-Class, [1]-Name, [2]-Level
                AddCharacterToList(currentData[0], currentData[1], Int32.Parse(currentData[2]));

                // [3]-Weapon equipped (true/false), [4]-Weapon name, [5]-Weapon description, [6]-Weapon damage
                if (currentData[3] == "true")
                {
                    // If character has a weapon, equip it
                    characters[currentCharacterIndex].Equip(new Weapon(currentData[4], currentData[5], Int32.Parse(currentData[6])));
                }

                currentCharacterIndex++;
            }
        }

        /// <summary>
        /// Add a single character to the character list
        /// </summary>
        /// <param name="characterClass"></param>
        /// <param name="characterName"></param>
        /// <param name="characterLevel"></param>
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
                case "Thief":
                    characters.Add(new Thief(characterName, characterLevel));
                    break;
                case "Sorcerer":
                    characters.Add(new Sorcerer(characterName, characterLevel));
                    break;
                case "Paladin":
                    characters.Add(new Paladin(characterName, characterLevel));
                    break;

            }
        }

        private static void WriteCharactersToFile(string filePath)
        {
            List<string> lines = new List<string>();

            // For every Character in characters list, write that line to the file
            foreach (Character character in characters)
            {
                string line = character.CharacterClass + "," + character.Name + "," + character.Level;

                if (character.WeaponEquipped)
                {
                    line += ",true," + character.Weapon.Name + "," + character.Weapon.Description + "," + character.Weapon.Damage;
                }
                else
                {
                    line += ",false";
                }

                lines.Add(line);
            }
            
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

            // Get first character of input
            var userInput = Console.ReadLine()[0].ToString();

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
            Console.WriteLine("");

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
            Console.WriteLine("-----------------------------");
            Console.WriteLine("1-{0}. View character detail", characters.Count);
            Console.WriteLine("0. Return to main menu");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get first character of input
            var userInput = Console.ReadLine()[0].ToString();

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
            Console.WriteLine("");

            // Show options
            Console.WriteLine("1. Create a barbarian");
            Console.WriteLine("2. Create a ranger");
            Console.WriteLine("3. Create a thief");
            Console.WriteLine("4. Create a sorcerer");
            Console.WriteLine("5. Create a paladin");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get user input for character class
            var userInput = Console.ReadLine()[0].ToString();

            if (userInput == "1")
            {
                characterClass = "Barbarian";
            }
            else if (userInput == "2")
            {
                characterClass = "Ranger";
            }
            else if (userInput == "3")
            {
                characterClass = "Thief";
            }
            else if (userInput == "4")
            {
                characterClass = "Sorcerer";
            }
            else if (userInput == "5")
            {
                characterClass = "Paladin";
            }
            else
            {
                characterClass = "Barbarian"; // Default in case the user doesn't choose a valid option
            }

            // Get input for character name
            Console.Write("Character name: ");
            name = Console.ReadLine().Replace(",", "");

            // Get user input for level
            Console.Write("Character level: ");
            if (Int32.TryParse(Console.ReadLine(), out level))
            {
                // In this case, the level they entered was valid
            }
            else
            {
                // The level the user entered was not valid. Assign default level of 30
                level = 30;
            }

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
            Console.WriteLine("");

            // Show options
            Console.WriteLine("1. Level character up");
            Console.WriteLine("2. Delete character");
            Console.WriteLine("3. Equip weapon");
            Console.WriteLine("4. Unequip weapon");
            Console.WriteLine("0. Return to character list");
            Console.WriteLine("");
            Console.Write("Selection: ");

            // Get input
            var userInput = Console.ReadLine()[0].ToString();

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
                int weaponDamage;

                Console.Write("Weapon name: ");
                string weaponName = Console.ReadLine().Replace(",", "");

                Console.Write("Weapon description: ");
                string weaponDescription = Console.ReadLine().Replace(",", "");

                Console.Write("Damage: ");
                if(Int32.TryParse(Console.ReadLine(), out weaponDamage))
                {
                    // In this case, the user entered a valid weaponDamage and everything is good
                }
                else
                {
                    // If the user did not enter a valid weaponDamage, use a default value
                    weaponDamage = 100;
                }

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
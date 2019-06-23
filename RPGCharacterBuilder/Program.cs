using System;
using System.Collections.Generic;
using System.IO;

namespace RPGCharacterBuilder
{
    class Program
    {
        static void Main()
        {
            List<Barbarian> barbarians = new List<Barbarian>();

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
                        barbarians.Add(new Barbarian(currentData[1], Int32.Parse(currentData[2])));
                        break;
                }
            }
            Console.ReadLine();
        }
    }
}

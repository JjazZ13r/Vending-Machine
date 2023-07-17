using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class Inventory
    {
        //Dictionary containing a code, and the available inventory for each item.
        public Dictionary<string, int> AvailableInventory = new Dictionary<string, int>();
        //List of all the CuteAnimal objects
        public List<CuteAnimal> AnimalList = new List<CuteAnimal>();
        
        
        //Reads the input text file and fills the dictionary and list of the inventory
        public void PopulateInventory()
        {
            string directory = Environment.CurrentDirectory;
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            string path = "C:\\Users\\Student\\workspace\\c-sharp-minicapstonemodule1-team1\\Capstone\\vendingmachine.csv";
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] words = line.Split("|");
                        if (words[3] == "Duck")
                        {
                            Duck newDuck = new Duck(words[0], words[1], decimal.Parse(words[2]), words[3]);
                            
                            AnimalList.Add(newDuck);
                            AvailableInventory[newDuck.Code] = 5;
                        }
                        else if (words[3] == "Penguin")
                        {
                            Penguin newPenguin = new Penguin(words[0], words[1], decimal.Parse(words[2]), words[3]);
                            AnimalList.Add(newPenguin);
                            AvailableInventory[newPenguin.Code] = 5;
                        }
                        else if (words[3] == "Cat")
                        {
                            Cat newCat = new Cat(words[0], words[1], decimal.Parse(words[2]), words[3]);
                            AnimalList.Add(newCat);
                            AvailableInventory[newCat.Code] = 5;
                        }
                        else if (words[3] == "Pony")
                        {
                            Pony newPony = new Pony(words[0], words[1], decimal.Parse(words[2]), words[3]);
                            AnimalList.Add(newPony);
                            AvailableInventory[newPony.Code] = 5;
                        }

                    }

                }
            }
            catch (IOException e)
            {
                Console.WriteLine("Their was an error displaying the item.");
            }


        }

        //Inventory is populated on construction
        public Inventory()
        {
            PopulateInventory();
        }


    }
}

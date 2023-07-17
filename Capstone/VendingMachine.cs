using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;

namespace Capstone
{
    public class VendingMachine
    {
        public decimal Balance { get; set; } = 0.00M;
        public Inventory MachineInvetory = new Inventory();
        public Customer NewCustomer = new Customer();
        public static List<string> SalesReport = new List<string>();


        //Boolean method to check if there is inventory to be purchased for specific product
        public bool CheckInventory(string code)
        {

            if (MachineInvetory.AvailableInventory[code] >= 1)
            {
                return true;
            }

            return false;
        }

        //Method that starts interation with customer. This initializes the first menu screen
        public void Interaction()
        {
            Console.Title = "Jon & Nate's Vending Machine";
            this.MachineInvetory = new Inventory();
            this.NewCustomer = new Customer();
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\r\n\r\n ____________________________________________\r\n|############################################|\r\n|#|                           |##############|\r\n|#|  =====  ..--''`  |~~``|   |##|````````|##|\r\n|#|  |   |  \\     |  :    |   |##| Exact  |##|\r\n|#|  |___|   /___ |  | ___|   |##| Change |##|\r\n|#|  /=__\\  ./.__\\   |/,__\\   |##| Only   |##|\r\n|#|  \\__//   \\__//    \\__//   |##|________|##|\r\n|#|===========================|##############|\r\n|#|```````````````````````````|##############|\r\n|#| =.._      +++     //////  |##############|\r\n|#| \\/  \\     | |     \\    \\  |#|`````````|##|\r\n|#|  \\___\\    |_|     /___ /  |#| _______ |##|\r\n|#|  / __\\\\  /|_|\\   // __\\   |#| |1|2|3| |##|\r\n|#|  \\__//-  \\|_//   -\\__//   |#| |4|5|6| |##|\r\n|#|===========================|#| |7|8|9| |##|\r\n|#|```````````````````````````|#| ``````` |##|\r\n|#| ..--    ______   .--._.   |#|[=======]|##|\r\n|#| \\   \\   |    |   |    |   |#|  _   _  |##|\r\n|#|  \\___\\  : ___:   | ___|   |#| ||| ( ) |##|\r\n|#|  / __\\  |/ __\\   // __\\   |#| |||  `  |##|\r\n|#|  \\__//   \\__//  /_\\__//   |#|  ~      |##|\r\n|#|===========================|#|_________|##|\r\n|#|```````````````````````````|##############|\r\n|############################################|\r\n|#|||||||||||||||||||||||||||||####```````###|\r\n|#||||||||||||PUSH|||||||||||||####\\|||||/###|\r\n|############################################|\r\n\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\///////////////////////\r\n |________________________________|JN97|___|\r\n\r\n");
            Console.ForegroundColor = ConsoleColor.Gray;
            DisplayOptions();
                 
        }
        
        //Present the user with three option from the main and handle their input. Also contains hidden 4th option.
        public void DisplayOptions()
        {
            Console.WriteLine($"\n(1) Display Vending Machine Items");
            Console.WriteLine($"(2) Purchase");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"(3) Exit Program");
            Console.ForegroundColor = ConsoleColor.Gray;
            int userInput;
            try
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 1)
                {
                    Console.Clear();
                    
                    DisplayItems();
                    DisplayOptions();
                    
                }
                else if (userInput == 2)
                {
                    Console.Clear();
                    DisplayPurchaseMenu();
                }
                else if (userInput == 4)
                {
                    
                    DisplayHiddenSalesReport();
                    DisplayOptions();
                }
                else
                {
                    Environment.Exit(0);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Input was invalid. Please try again by selecting a number.");
                DisplayOptions();
            }

        }
        //Reads the input file and lists the items available in the vending machine to the user.
        public void DisplayItems()
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
                        if (MachineInvetory.AvailableInventory[words[0]] != 0)
                        {                        
                            Console.WriteLine("{0,-40} {1,40}", $"{line}", $"Available Inventory: {MachineInvetory.AvailableInventory[words[0]]}");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("{0,-40} {1,40}", $"{line}", $"Available Inventory: SOLD OUT");
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }

                }
            }
            catch(IOException e)
            {
                Console.WriteLine("Their was an error displaying the item.");
                DisplayOptions();
            }

        }


        //Displays the purchase menu and handles the user input.
        public void DisplayPurchaseMenu()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nCurrent Money Provided: ${Balance} \n");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine($"(1) Feed Money");
            Console.WriteLine($"(2) Select Product");
            Console.WriteLine($"(3) Finish Transaction");

            int userInput;
            try
            {
                userInput = int.Parse(Console.ReadLine());
                if (userInput == 1)
                {
                    //Take customer input and update the balance of the Vending machine
                    decimal newDeposit = FeedMoney();
                    this.Balance += newDeposit;

                    //Log the money feed transaction to the Log.txt file
                    string logEntry = LogEntryCreator.FeedMoneyLog(newDeposit,this.Balance);
                    Log.LogToFile(logEntry);

                    //Clear the console and go back to purchase menu.
                    Console.Clear();
                    DisplayPurchaseMenu();
                }
                else if (userInput == 2)
                { 
                    DisplayItems();

                    //Prompt the user to select an item.
                    string selectedItem = Console.ReadLine().ToUpper();
                    //Check if item selected has available inventory
                    if(MachineInvetory.AvailableInventory.ContainsKey(selectedItem) && CheckInventory(selectedItem) )
                    {   
                        foreach(CuteAnimal item in MachineInvetory.AnimalList)
                        {
                            //Go through list of CuteAnimals to find matching code and check balance vs. price
                            if (selectedItem.Equals(item.Code) && this.Balance >= item.Price)
                            {
                                //Add item to customers list of items purchased
                                NewCustomer.ItemsBought.Add(item);
                                //Update the inventory of the item in the inventory
                                UpdateInventory(item);                           
                                Console.Clear();
                                //Dispense the item and update the balance
                                DispenseAndUpdateBalance(item);
                                //Return user to purchase menu
                                DisplayPurchaseMenu();                               
                            }
                            //Else: they don't have enough balance
                            else if(this.Balance < item.Price)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nSorry not enough money was entered");
                                Console.ForegroundColor = ConsoleColor.Gray;
                                //Take them back to Purchase menu
                                goto AfterLoop;
                                
                            }
                            
                        }
                    AfterLoop:
                        DisplayPurchaseMenu();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Not a valid code or item out of stock. Please try again");
                        DisplayPurchaseMenu();
                    }
                }
                else if (userInput == 3)
                {
                    //Return the change to the customer.
                    ReturnAndMakeChange();
                    
                }


            }
            catch (Exception e)
            {
                Console.WriteLine("Input was invalid. Please try again by selecting a number.");
                DisplayPurchaseMenu();
            }
        }
        


       //Updates the machine inventory for the animal selected
        public void UpdateInventory(CuteAnimal selection)
        {
            MachineInvetory.AvailableInventory[selection.Code] -= 1;
            Console.WriteLine($"You removed 1{selection.Variety} from inventory");
        }

        //Dispenses toy and updates machine's balance
        public void DispenseAndUpdateBalance(CuteAnimal selection)
        {
            //Update Balance
            this.Balance -= selection.Price;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"You selected {selection.Variety} it costs ${selection.Price}. \n You have ${this.Balance} remaining." + selection.MakeSound());
            Console.ForegroundColor = ConsoleColor.Gray;
            //Updates amount sold of certain toy
            selection.AmountSold += 1;

            //Logs purchased toy to the Log.txt file
            string logEntry = LogEntryCreator.DispenseProductLog(selection.Variety, selection.Code, selection.Price, this.Balance);
            Log.LogToFile(logEntry);
                        
        }

        //Return the owed change to the customer
        public void ReturnAndMakeChange()
        {
            int nickels = 0;
            int dimes = 0;
            int quarters = 0;

            decimal startingBalance = this.Balance;

            while(this.Balance > 0)
            {
                if(this.Balance >= .25M)
                {
                    quarters += 1;
                    this.Balance -= .25M;
                }
                else if(this.Balance >= .10M && this.Balance <= .25M)
                {
                    dimes += 1;
                    this.Balance -= .10M;
                }
                else if(this.Balance < .10M)
                {
                    nickels += 1;
                    this.Balance -= .05M;
                }
            }

            Console.WriteLine($"You got ${startingBalance} back.\n It was: \n {quarters} quarters \n {dimes} dimes \n {nickels} nickels");
            //Write to Log.txt file of the change returned
            string logEntry = LogEntryCreator.ReturnMoneyLog(startingBalance,this.Balance);
            Log.LogToFile(logEntry);          
            //Wait 3.5 seconds after completed transaction before returning to Main Menu
            Thread.Sleep(3500);
            Console.Clear();
            DisplayOptions();
        }

        //Tracks the sales of each item in a list for the hidden menu
        public void TrackSale()
        {
            decimal reportTotal = 0.00M;
            
            foreach(CuteAnimal item in MachineInvetory.AnimalList)
            {     
                //Update sales total and add to the list for each CuteAnimal
                reportTotal += (item.AmountSold * item.Price);
                SalesReport.Add($"{item.Variety}|{item.AmountSold}");               
            }
            //Add the total sales amount to the end of List.
            SalesReport.Add($"TOTAL SALES: ${reportTotal}");
            //Write the List to the SalesReport .txt file.
            SaleReportLogger.LogToSaleReport(SalesReport);
        }


        //Feed money to the machine
        private decimal FeedMoney()
        {
            //Prompt user amount
            Console.Write("Enter deposit amount: ");
            decimal deposit = 0;
            try
            {

                deposit = decimal.Parse(Console.ReadLine());
                if (deposit < 0)
                {
                    Console.WriteLine("Invalid amount entered. Please Re-Enter deposit amount: ");
                    deposit = decimal.Parse(Console.ReadLine());
                }

                return deposit;
            }
            catch
            {
                while (deposit <= 0)
                {

                    Console.WriteLine("Entry was not able to be read. Please Re-Enter deposit amount as a number: ");
                    deposit = decimal.Parse(Console.ReadLine());
                }
                return deposit;
            }

        }

        //Displays the hidden menu option
        public void DisplayHiddenSalesReport()
        {
            Console.Clear();
            TrackSale();
            //Write each item in the list of sales made as well as the total
            foreach(string item in SalesReport)
            {
                Console.WriteLine(item);
            }
        }




    }

}


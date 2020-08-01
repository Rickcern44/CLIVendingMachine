using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class VendingMachine
    {
        public string Path = @"..\..\..\..\Log.txt";
        private Bank bank;
        private StockMachine stock;
        public VendingMachine(Bank bank, StockMachine stock)
        {
            this.bank = bank;
            this.stock = stock;
        }
        public Dictionary<string, VendingItem> Inventory = new Dictionary<string, VendingItem>();

        public void PurchaseItem()
        {
            //Ask user to select the item
            Console.Write("Enter the item ID you want to purchase: ");
            string userSelection = Console.ReadLine().ToUpper().Trim();

            

            if (Inventory.ContainsKey(userSelection))
            {
                VendingItem selection = Inventory[userSelection];

                if (bank.CurrentBalance < selection.ProductPrice)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n!!! Sorry Insufficient Funds !!!\n");
                    Console.ResetColor();
                }

                else
                {
                    if (selection.ItemInventory < 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\n!!! Sorry product SOLD OUT !!!\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("");
                        //Subtract money from amount in machine
                        bank.CurrentBalance -= selection.ProductPrice;

                        //Subtract 1 from product inventory
                        selection.ItemInventory -= 1;
                        
                        //Write out user message
                        Console.WriteLine($"Product: {selection.ProductName}\tCost: {selection.ProductPrice}\tMoney Remaining: {bank.CurrentBalance}");
                        Console.WriteLine($"\"{selection.ReturnMessage()}\"\n");
                        //Log date time| item name and slot | beginning balance | balance after purchase

                        decimal newBalance = bank.CurrentBalance + selection.ProductPrice;
                        using (StreamWriter sw = new StreamWriter(Path, true))
                        {    
                            sw.WriteLine($"{DateTime.Now} {selection.ProductName} {selection.ItemId} {bank.CurrentBalance:C} {newBalance:C}");
                        }
                    }
                    

                }

            }
            else
            {
                Console.WriteLine("Sorry that code does not exist. Enter another code.");

            }
        }


    }
}

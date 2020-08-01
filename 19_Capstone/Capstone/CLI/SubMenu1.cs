using Capstone;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    public class SubMenu1 : CLIMenu
    {
        // Store any private variables here....

        /// <summary>
        /// Constructor adds items to the top-level menu
        private VendingMachine vendingMachine;
        private Bank bank;
        private Change change;
        /// </summary>
        public SubMenu1(VendingMachine vending, Bank bank) :
            base("Sub-Menu 1")
        {
            this.bank = bank;
            this.vendingMachine = vending;
            //this.menu = menu;
            // Store any values passed in....
        }

        protected override void SetMenuOptions()
        {
            this.menuOptions.Add("1", "Feed Money");
            this.menuOptions.Add("2", "Select Product");
            this.menuOptions.Add("3", "Finish Transaction");
            this.quitKey = "Q";
        }

        /// <summary>
        /// The override of ExecuteSelection handles whatever selection was made by the user.
        /// This is where any business logic is executed.
        /// </summary>
        /// <param name="choice">"Key" of the user's menu selection</param>
        /// <returns></returns>
        protected override bool ExecuteSelection(string choice)
        {
            switch (choice)
            {
                case "1": // Do whatever option 1 is
                    string message = "How much money are you inserting to bill collector?: ";
                    bank.MoneyIn(message);

                    Pause("");
                    return true;

                case "2": // Do whatever option 2 is
                    PrintList();
                    vendingMachine.PurchaseItem();
                    Pause("");
                    return true;

                case "3": // Do whatever option 3 is
                    //Change change = bank.ChangeMaker(change);
                    this.change = new Change();
                    bank.ChangeMaker(this.change);

                    DisplayChange();
                    Pause("");
                    return false;
            }
            return true;
        }
        public void DisplayChange()
        {
            Console.WriteLine($"Change Returned:\n\t{this.change.NumberOfQuarters} Quarters\n\t{this.change.NumberOfDimes} Dimes\n\t{this.change.NumberOfNickels} Nickels\n\t{this.change.NumberOfPennies} Pennies");
        }
        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }

        protected override void AfterDisplayMenu()
        {
            base.AfterDisplayMenu();
            SetColor(ConsoleColor.Cyan);
            Console.WriteLine($"Balance: {bank.CurrentBalance:C}");
            ResetColor();
        }

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Magenta);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Purchase Menu"));
            ResetColor();
        }
        public void PrintList()
        {
            foreach (KeyValuePair<string, VendingItem> vi in vendingMachine.Inventory)
            {
                if (vi.Value.ItemInventory > 0)
                {
                    Console.WriteLine($"{vi.Key} Holds {vi.Value.ProductName}. And costs {vi.Value.ProductPrice}. There are {vi.Value.ItemInventory} remaining");
                }
                else
                {
                    Console.WriteLine($"{vi.Key} Holds {vi.Value.ProductName}. And costs {vi.Value.ProductPrice}. IT IS SOLD OUT ");
                }
            }
        }

    }
}

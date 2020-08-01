using Capstone;
using System;
using System.Collections.Generic;

namespace CLI
{
    /// <summary>
    /// The top-level menu in our Market Application
    /// </summary>
    /// 
    
    public class MainMenu : CLIMenu
    {

        // You may want to store some private variables here.  YOu may want those passed in 
        // in the constructor of this menu
        private VendingMachine vendingMachine;
        private Bank bank;
        //private SubMenu1 subMenu;

        /// <summary>
        /// Constructor adds items to the top-level menu. You will likely have parameters  passed in
        /// here...
        /// </summary>
        public MainMenu(VendingMachine vendingMachine, Bank bank) : base("Main Menu")
        {
            this.bank = bank;
            // Set any private variables here.
            this.vendingMachine = vendingMachine;
            
        }

        protected override void SetMenuOptions()
        {
            // A Sample menu.  Build the dictionary here
            this.menuOptions.Add("1", "Display Vending Machine Items");
            this.menuOptions.Add("2", "Purchase");
            //this.menuOptions.Add("3", "Go to a sub-menu");
            this.menuOptions.Add("3", "Exit");
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
                case "1": 
                    PrintList();
                    
                    Pause("");
                    return true;    // Keep running the main menu
                case "2": // Do whatever option 2 is
                    SubMenu1 subMenu = new SubMenu1(vendingMachine, bank);
                    subMenu.Run();
                    return true;    // Keep running the main menu
                case "3":
                    //TODO *as is now, user must hit enter multiple times to close console and remove from screen*
                    return false;    // Keep running the main menu
            }
            return true;
        }

        protected override void BeforeDisplayMenu()
        {
            PrintHeader();
        }
        

        private void PrintHeader()
        {
            SetColor(ConsoleColor.Yellow);
            Console.WriteLine(Figgle.FiggleFonts.Standard.Render("Vendo-matic 800"));
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

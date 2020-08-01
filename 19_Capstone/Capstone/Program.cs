using CLI;
using System;

namespace Capstone
{
    static class Program
    {
        public static void Main()
        {
            Bank bank = new Bank();
            StockMachine stock = new StockMachine();
            VendingMachine vendingMachine = new VendingMachine(bank, stock);




            string path = @"..\..\..\..\vendingmachine.csv";
            stock.StockVendingMachine(vendingMachine.Inventory, path);

            MainMenu mainMenu = new MainMenu(vendingMachine, bank);
            mainMenu.Run();
            //Instance of stock machine

            //stock.PrintList();

            Console.Read();

        }

    }

}

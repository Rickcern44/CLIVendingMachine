using System;
using System.Collections.Generic;
using System.IO;

namespace Capstone
{
    public class StockMachine
    {
        public void StockVendingMachine(Dictionary<string, VendingItem> inventory, string path)
        {

            using (StreamReader rdr = new StreamReader(path))
            {
                while (!rdr.EndOfStream)
                {

                    //Read by line and split by |
                    string line = rdr.ReadLine();
                    string[] itemInfo = line.Split("|");

                    //take each entry assign to variable
                    string itemId = itemInfo[0];
                    string itemName = itemInfo[1];
                    decimal itemPrice = decimal.Parse(itemInfo[2]);
                    string itemType = itemInfo[3];

                    if (itemType == "Drink")
                    {
                        inventory.Add(itemId, new Beverage(itemId,itemName, itemPrice, itemType));
                    }
                    else if (itemType == "Candy")
                    {
                        inventory.Add(itemId, new Candy(itemId,itemName, itemPrice, itemType)); ;
                    }
                    else if (itemType == "Chip")
                    {
                        inventory.Add(itemId, new Chips(itemId,itemName, itemPrice, itemType));
                    }
                    else
                    {
                        inventory.Add(itemId, new Gum(itemId,itemName, itemPrice, itemType));
                    }

                }

            }

        }


    }

}

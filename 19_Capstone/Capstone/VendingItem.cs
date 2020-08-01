using System;
using System.ComponentModel;

namespace Capstone
{
    public class VendingItem
    {
        //Contructor
        public VendingItem(string itemId, string name, decimal price, string type)
        {
            this.ProductName = name;
            this.ProductType = type;
            this.ProductPrice = price;
            this.ItemId = itemId;
        }

        //Properties
        public string ProductName { get; private set; }
        public string ProductType { get; private set; }
        public decimal ProductPrice { get; private set; }
        
        public int ItemInventory { get; set; } = 5;
        public string ItemId { get; private set; }

        //virtual string for individual messages 
        public virtual string ReturnMessage()
        {
            return "";
        }
    }
}

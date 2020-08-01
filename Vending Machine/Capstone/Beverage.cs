using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Beverage : VendingItem
    {
        public Beverage(string itemId, string name, decimal price, string type) : base(itemId, name, price, type)
        {

        }
        public override string ReturnMessage()
        {
            return "Glug, Glug, Yum!";
        }
    }
}

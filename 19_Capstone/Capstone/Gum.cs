using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Gum : VendingItem
    {
        public Gum(string itemId, string name, decimal price, string type) : base(itemId, name, price, type)
        {
        }
        public override string ReturnMessage()
        {
            return "Chew, Chew, Yum!";
        }
    }

}

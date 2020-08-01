using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
        public class Candy : VendingItem
        {
            public Candy(string itemId, string name, decimal price, string type) : base(itemId, name, price, type)
        {
            }
            public override string ReturnMessage()
            {
                return "Munch, Munch, Yum!";
            }
        }
    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone
{
    public class Change
    {
        public int NumberOfQuarters { get; set; }
        public int NumberOfDimes { get; set; }
        public int NumberOfNickels { get; set; }
        public int NumberOfPennies { get; set; }
        public decimal AmountOfChange
        {
            get
            {
                return 0.25M * NumberOfQuarters + 0.10M * NumberOfDimes + 0.05M * NumberOfNickels + 0.01M * NumberOfPennies;
            }
        }
            
    }
}

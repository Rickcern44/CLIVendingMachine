using System;
using System.IO;

namespace Capstone
{
    public class Bank
    {
        public string Path = @"..\..\..\..\Log.txt";
        public decimal CurrentBalance { get; set; }

        private decimal WholeDollar { get; }

        public int MoneyIn(string askUser)
        {
            int resultValue = 0;
            while (true)
            {
                Console.Write(askUser + " ");
                string userInput = Console.ReadLine().Trim();
                if (int.TryParse(userInput, out resultValue))
                {

                    break;
                }
                else
                {
                    Console.WriteLine("!!! Invalid input. Please enter a valid whole number.");
                }
            }
            CurrentBalance += resultValue;
            return resultValue;
        }


        public Change ChangeMaker(Change change)
        {
            if (this.CurrentBalance == 0)
            {
                change.NumberOfQuarters = 0;
                change.NumberOfDimes = 0;
                change.NumberOfNickels = 0;
                change.NumberOfPennies = 0;
            }
            else
            {
                decimal untouchedBalance = this.CurrentBalance;
                this.CurrentBalance *= 100;
                if (this.CurrentBalance % 25 == 0)
                {
                    change.NumberOfQuarters = (int)this.CurrentBalance / 25;
                }
                else if (!(this.CurrentBalance % 25 == 0))
                {
                    change.NumberOfQuarters = (int)this.CurrentBalance / 25;
                    this.CurrentBalance = CurrentBalance % 25;
                    if (this.CurrentBalance % 10 == 0)
                    {
                        change.NumberOfDimes = (int)this.CurrentBalance / 10;
                    }
                    else if (!(this.CurrentBalance % 10 == 0))
                    {
                        change.NumberOfDimes = (int)this.CurrentBalance / 10;
                        this.CurrentBalance = CurrentBalance % 10;
                        if (this.CurrentBalance % 5 == 0)
                        {
                            change.NumberOfNickels = (int)this.CurrentBalance / 5;
                        }
                        else
                        {
                            change.NumberOfNickels = (int)this.CurrentBalance / 5;
                            this.CurrentBalance = CurrentBalance % 5;
                            change.NumberOfPennies = (int)this.CurrentBalance;
                        }
                    }
                }
                using (StreamWriter sw = new StreamWriter(Path, true))
                {
                    sw.WriteLine($"{DateTime.Now} RETURNED CHANGE ({untouchedBalance:C})");
                }

            }
            this.CurrentBalance = 0;
            return change;
        }

    }
}

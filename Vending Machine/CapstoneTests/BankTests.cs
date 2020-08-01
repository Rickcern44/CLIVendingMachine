using Capstone;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void ChangeIs10Dollars()
        {

            Bank bank = new Bank();
            Change change1 = new Change();

            bank.CurrentBalance = 10;

            bank.ChangeMaker(change1);

            Assert.AreEqual(change1.NumberOfQuarters, 40);
            Assert.AreEqual(change1.NumberOfDimes, 0);
            Assert.AreEqual(change1.NumberOfNickels, 0);
            Assert.AreEqual(change1.NumberOfPennies, 0);

        }
        [DataTestMethod]
        [DataRow(20.00, 80, 0, 0, 0)]
        [DataRow(10.11, 40, 1, 0, 1)]
        [DataRow(.5, 2, 0, 0, 0)]
        [DataRow(0, 0, 0, 0, 0)]
        [DataRow(.41, 1, 1, 1, 1)]
        public void ChangeHasCents(double balance, int quarters, int dimes, int nickels, int pennies)
        {

            Bank bank = new Bank();
            Change change1 = new Change();

            bank.CurrentBalance = (decimal)balance;

            bank.ChangeMaker(change1);

            Assert.AreEqual(change1.NumberOfQuarters, quarters);
            Assert.AreEqual(change1.NumberOfDimes, dimes);
            Assert.AreEqual(change1.NumberOfNickels, nickels);
            Assert.AreEqual(change1.NumberOfPennies, pennies);

        }
        [TestMethod]
        public void ChangeIs10DollarsAnd11Cents()
        {

            Bank bank = new Bank();
            Change change1 = new Change();

            bank.CurrentBalance = 10.11M;

            bank.ChangeMaker(change1);

            Assert.AreEqual(change1.NumberOfQuarters, 40);
            Assert.AreEqual(change1.NumberOfDimes, 1);
            Assert.AreEqual(change1.NumberOfNickels, 0);
            Assert.AreEqual(change1.NumberOfPennies, 1);

        }
    }
}

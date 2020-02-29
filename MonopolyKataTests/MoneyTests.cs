using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class MoneyTests
    {
        [TestMethod]
        public void AddMoneyReturnsCorrectAmount()
        {
            var money = new Money(5);
            var moneyToAdd = new Money(4);
            var expectedMoney = new Money(9);

            var result = money.Add(moneyToAdd);

            Assert.AreEqual(expectedMoney, result);
        }

        [TestMethod]
        public void SubtractMoneyReturnsCorrectAmount()
        {
            var money = new Money(5);
            var moneyToSubtract = new Money(4);
            var expectedMoney = new Money(1);

            var result = money.Subtract(moneyToSubtract);

            Assert.AreEqual(expectedMoney, result);
        }
    }
}

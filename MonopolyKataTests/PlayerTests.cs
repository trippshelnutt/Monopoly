using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void MoveToLocationSetsPlayerLocation()
        {
            var player = Player.Create("horse");
            var expectedLocation = new Location(500);

            var result = player.MoveToLocation(expectedLocation);

            Assert.AreEqual(expectedLocation, result.Location);
        }

        [TestMethod]
        public void HasAvailableFundsReturnsTrueWhenBalancesIsGreaterThanRequest()
        {
            var player = Player.Create("horse", balance: 201);
            var request = new Money(200);

            Assert.IsTrue(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsTrueWhenBalanceIsEqualToRequest()
        {
            var player = Player.Create("horse", balance: 200);
            var request = new Money(200);

            Assert.IsTrue(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsFalseWhenBalanceIsLessThanRequest()
        {
            var player = Player.Create("horse", balance: 199);
            var request = new Money(200);

            Assert.IsFalse(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void DepositMoneyAddsMoneyToBalance()
        {
            var player = Player.Create("horse");
            var expectedBalance = new Money(500);

            var result = player.DepositMoney(expectedBalance);

            Assert.AreEqual(expectedBalance, result.Balance);
        }

        [TestMethod]
        public void WithdrawMoneySubtractsMoneyFromBalance()
        {
            var player = Player.Create("horse", balance: 400);
            var expectedBalance = new Money(200);

            var result = player.WithdrawMoney(expectedBalance);

            Assert.AreEqual(expectedBalance, result.Balance);
        }
    }
}

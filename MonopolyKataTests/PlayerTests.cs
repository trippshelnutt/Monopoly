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
            var player = PlayerServices.Create(PlayerName.Horse);
            var expectedLocation = new LocationIndex(500);

            var result = player.MoveToLocation(expectedLocation);

            Assert.AreEqual(expectedLocation, result.Location);
        }

        [TestMethod]
        public void HasAvailableFundsReturnsTrueWhenBalancesIsGreaterThanRequest()
        {
            var player = PlayerServices.Create(PlayerName.Horse, balance: new Money(201));
            var request = new Money(200);

            Assert.IsTrue(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsTrueWhenBalanceIsEqualToRequest()
        {
            var player = PlayerServices.Create(PlayerName.Horse, balance: new Money(200));
            var request = new Money(200);

            Assert.IsTrue(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void HasAvailableFundsReturnsFalseWhenBalanceIsLessThanRequest()
        {
            var player = PlayerServices.Create(PlayerName.Horse, balance: new Money(199));
            var request = new Money(200);

            Assert.IsFalse(player.HasAvailableFunds(request));
        }

        [TestMethod]
        public void DepositMoneyAddsMoneyToBalance()
        {
            var player = PlayerServices.Create(PlayerName.Horse);
            var expectedBalance = new Money(500);

            var result = player.DepositMoney(expectedBalance);

            Assert.AreEqual(expectedBalance, result.Balance);
        }

        [TestMethod]
        public void WithdrawMoneySubtractsMoneyFromBalance()
        {
            var player = PlayerServices.Create(PlayerName.Horse, balance: new Money(400));
            var expectedBalance = new Money(200);

            var result = player.WithdrawMoney(expectedBalance);

            Assert.AreEqual(expectedBalance, result.Balance);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class BoardServicesTests
    {
        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            var board = Board.Create();
            var player = Player.Create("horse");
            var rollResult = new RollResult(7);

            player = board.MovePlayer(player, rollResult);

            Assert.AreEqual(new Location(7), player.Location);
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsOnLocation5()
        {
            var board = Board.Create();
            var player = Player.Create("horse", 39);
            var rollResult = new RollResult(6);

            player = board.MovePlayer(player, rollResult);

            Assert.AreEqual(new Location(5), player.Location);
        }
    }
}

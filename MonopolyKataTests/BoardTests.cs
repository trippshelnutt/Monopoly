using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class BoardTests
    {
        [TestMethod]
        public void PlayerOnBeginningLocationRolls7AndEndsOnLocation7()
        {
            var board = BoardServices.Create();
            var player = PlayerServices.Create(NameConstants.Horse);
            var rollResult = new RollResult(7);

            var (_, location) = board.MovePlayer(player.Location, rollResult);

            Assert.AreEqual(new Location(7), location);
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsOnLocation5()
        {
            var board = BoardServices.Create();
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.Boardwalk);
            var rollResult = new RollResult(6);

            var (_, location) = board.MovePlayer(player.Location, rollResult);

            Assert.AreEqual(LocationConstants.ReadingRailroad, location);
        }
    }
}

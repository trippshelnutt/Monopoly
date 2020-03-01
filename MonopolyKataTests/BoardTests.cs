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
            var player = PlayerServices.Create(Name.Horse);
            var rollResult = new RollResult(7);

            var (_, location) = board.MovePlayer(player.Location, rollResult);

            Assert.AreEqual(new LocationIndex(7), location);
        }

        [TestMethod]
        public void PlayerOnLocation39Rolls6AndEndsOnLocation5()
        {
            var board = BoardServices.Create();
            var player = PlayerServices.Create(Name.Horse, LocationIndex.Boardwalk);
            var rollResult = new RollResult(6);

            var (_, location) = board.MovePlayer(player.Location, rollResult);

            Assert.AreEqual(LocationIndex.ReadingRailroad, location);
        }
    }
}

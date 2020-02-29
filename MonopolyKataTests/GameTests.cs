using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void CanCreateAGameWithTwoPlayers()
        {
            var game = Game.Create(new[] { "horse", "car" });

            Assert.IsNotNull(game);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithLessThan2PlayersFails()
        {
            Game.Create(new[] { "horse" });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithMoreThan8PlayersFails()
        {
            Game.Create(Enumerable.Range(1, 9).Select(i => $"Player{i}"));
        }

        [TestMethod]
        public void PlayerOrderingIsRandom()
        {
            var players = new[] { "horse", "car" }.Select(n => Player.Create(n));

            var games = Enumerable.Range(1, 100).Select(i => Game.Create(players));

            Assert.IsTrue(games.Any(g => g.Players.First().Name.Value == "horse"));
            Assert.IsTrue(games.Any(g => g.Players.First().Name.Value == "car"));
        }

        [TestMethod]
        public void PlayReturns20Rounds()
        {
            var game = Game.Create(new[] { "horse", "car" });

            var rounds = game.Play();

            Assert.AreEqual(20, rounds.Count());
        }
    }
}

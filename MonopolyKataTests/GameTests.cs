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
            var game = GameServices.Create(new[] { "horse", "car" });

            Assert.IsNotNull(game);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithLessThan2PlayersFails()
        {
            GameServices.Create(new[] { "horse" }).Play();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithMoreThan8PlayersFails()
        {
            GameServices.Create(Enumerable.Range(1, 9).Select(i => $"Player{i}")).Play();
        }

        [TestMethod]
        public void PlayerOrderingIsRandom()
        {
            var players = new[] { "horse", "car" }.Select(n => PlayerServices.Create(n));

            var games = Enumerable.Range(1, 100).Select(i => GameServices.Create(players));

            Assert.IsTrue(games.Any(g => g.Players.First().Name.Value == "horse"));
            Assert.IsTrue(games.Any(g => g.Players.First().Name.Value == "car"));
        }

        [TestMethod]
        public void PlayReturns20Rounds()
        {
            var game = GameServices.Create(new[] { "horse", "car" });

            var rounds = game.Play().Rounds;

            Assert.AreEqual(20, rounds.Count());
        }

        [TestMethod]
        public void PlayReturns20RoundsForEachPlayer()
        {
            var game = GameServices.Create(new[] { "horse", "car" });

            var rounds = game.Play().Rounds;

            var turns = rounds.SelectMany(r => r.Turns);
            Assert.AreEqual(20, turns.Where(t => t.Player.Name.Value == "horse").Count());
            Assert.AreEqual(20, turns.Where(t => t.Player.Name.Value == "car").Count());
        }

        [TestMethod]
        public void PlayerOrderIsTheSameForEveryRound()
        {
            var game = GameServices.Create(new[] { "horse", "car" });

            var rounds = game.Play().Rounds;

            var firstPlayerTurns = rounds.Select(r => r.Turns[0]);
            var secondPlayerTurns = rounds.Select(r => r.Turns[1]);
            var firstPlayerName = firstPlayerTurns.First().Player.Name;
            var secondPlayerName = secondPlayerTurns.First().Player.Name;
            Assert.IsTrue(firstPlayerTurns.All(t => t.Player.Name.Value == firstPlayerName.Value));
            Assert.IsTrue(secondPlayerTurns.All(t => t.Player.Name.Value == secondPlayerName.Value));
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy200WhenPlayerLandsOnGo()
        {
            var game = GameServices.Create(new[] { PlayerServices.Create("horse", 39) });
            var rollResult = new RollResult(1);

            game = game.StartNewRound()
                .TakeTurn(game.Players.First(), rollResult);

            Assert.AreEqual(new Money(200), game.Players.First().Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy200WhenPlayerPassesOverGo()
        {
            var game = GameServices.Create(new[] { PlayerServices.Create("horse", 39) });
            var rollResult = new RollResult(2);

            game = game.StartNewRound()
                .TakeTurn(game.Players.First(), rollResult);

            Assert.AreEqual(new Money(200), game.Players.First().Balance);
        }

        [TestMethod]
        public void PlayerBalanceDoesNotIncreaseBy200WhenPlayerDoesNotPassOverGo()
        {
            var game = GameServices.Create(new[] { PlayerServices.Create("horse", 5) });
            var rollResult = new RollResult(2);

            game = game.StartNewRound()
                .TakeTurn(game.Players.First(), rollResult);

            Assert.AreEqual(new Money(0), game.Players.First().Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy400IfPlayerCouldPassGoTwice()
        {
            var game = GameServices.Create(new[] { PlayerServices.Create("horse", 39) });
            var rollResult = new RollResult(42);

            game = game.StartNewRound()
                .TakeTurn(game.Players.First(), rollResult);

            Assert.AreEqual(new Money(400), game.Players.First().Balance);
        }
    }
}

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
            var game = GameTestsServices.CreateHorseCarGame();

            Assert.IsNotNull(game);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithLessThan2PlayersFails()
        {
            var players = new[] { NameConstants.Horse };
            GameServices.Create(players).Play();
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void CreatingAGameWithMoreThan8PlayersFails()
        {
            var players = Enumerable.Range(1, 9).Select(i => PlayerServices.Create(new Name($"Player{i}")));
            GameServices.Create(players).Play();
        }

        [TestMethod]
        public void PlayerOrderingIsRandom()
        {
            var games = Enumerable.Range(1, 100).Select(i => GameTestsServices.CreateHorseCarGame());

            Assert.IsTrue(games.Any(g => g.Players.First().Name.Equals(NameConstants.Horse)));
            Assert.IsTrue(games.Any(g => g.Players.First().Name.Equals(NameConstants.Car)));
        }

        [TestMethod]
        public void PlayReturns20Rounds()
        {
            var game = GameTestsServices.CreateHorseCarGame();

            var rounds = game.Play().Rounds;

            Assert.AreEqual(20, rounds.Count());
        }

        [TestMethod]
        public void PlayReturns20RoundsForEachPlayer()
        {
            var game = GameTestsServices.CreateHorseCarGame();

            var rounds = game.Play().Rounds;

            var turns = rounds.SelectMany(r => r.Turns);
            Assert.AreEqual(20, turns.Where(t => t.Player.Name.Value == "horse").Count());
            Assert.AreEqual(20, turns.Where(t => t.Player.Name.Value == "car").Count());
        }

        [TestMethod]
        public void PlayerOrderIsTheSameForEveryRound()
        {
            var game = GameTestsServices.CreateHorseCarGame();

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
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(1);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(200), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy200WhenPlayerPassesOverGo()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(2);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(200), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceDoesNotIncreaseBy200WhenPlayerDoesNotPassOverGo()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.ReadingRailroad);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(2);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(0), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy400IfPlayerCouldPassGoTwice()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(42);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(400), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnGoToJailAndEndsUpOnJustVisitingAndBalanceIsUnchanged()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.WaterWorks);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(2);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(0), player.Balance);
            Assert.AreEqual(LocationConstants.JustVisiting, player.Location);
        }

        [TestMethod]
        public void PlayerPassesOverGoToJailAndEndsUpOnNormalLocationAndBalanceIsUnchanged()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.WaterWorks);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(3);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(0), player.Balance);
            Assert.AreEqual(LocationConstants.PacificAve, player.Location);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxAndPays10Percent()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.BalticAve, new Money(1800));
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(1);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(1620), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxAndPaysMaxOf200()
        {
            var player = PlayerServices.Create(NameConstants.Horse, LocationConstants.BalticAve, new Money(2200));
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(1);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(2000), player.Balance);
        }
    }
}

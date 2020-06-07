﻿using System;
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
            var players = new[] { Name.Horse };
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

            Assert.IsTrue(games.Any(g => g.Players.First().Name.Equals(Name.Horse)));
            Assert.IsTrue(games.Any(g => g.Players.First().Name.Equals(Name.Car)));
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
            var player = PlayerServices.Create(Name.Horse, LocationIndex.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(1);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(200), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy200WhenPlayerPassesOverGo()
        {
            var player = PlayerServices.Create(Name.Horse, LocationIndex.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(2);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(200), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceDoesNotIncreaseBy200WhenPlayerDoesNotPassOverGo()
        {
            var player = PlayerServices.Create(Name.Horse, LocationIndex.ReadingRailroad);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(2);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(0), player.Balance);
        }

        [TestMethod]
        public void PlayerBalanceIncreasesBy400IfPlayerCouldPassGoTwice()
        {
            var player = PlayerServices.Create(Name.Horse, LocationIndex.Boardwalk);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(42);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(400), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnGoToJailAndEndsUpOnJustVisitingAndBalanceIsUnchanged()
        {
            var player = PlayerServices.Create(Name.Horse);
            var game = GameServices.Create(new[] { player });

            (_, player) = game.GoToJailActivity(player);

            Assert.AreEqual(new Money(0), player.Balance);
            Assert.AreEqual(LocationIndex.JustVisiting, player.Location);
        }

        [TestMethod]
        public void PlayerPassesOverGoToJailAndEndsUpOnNormalLocationAndBalanceIsUnchanged()
        {
            var player = PlayerServices.Create(Name.Horse, LocationIndex.WaterWorks);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(3);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(0), player.Balance);
            Assert.AreEqual(LocationIndex.PacificAve, player.Location);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxAndPays10Percent()
        {
            var player = PlayerServices.Create(Name.Horse, balance: new Money(1800));
            var game = GameServices.Create(new[] { player });

            (_, player) = game.IncomeTaxActivity(player);

            Assert.AreEqual(new Money(1620), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxAndPaysMaxOf200()
        {
            var player = PlayerServices.Create(Name.Horse, balance: new Money(2200));
            var game = GameServices.Create(new[] { player });

            (_, player) = game.IncomeTaxActivity(player);

            Assert.AreEqual(new Money(2000), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxDoesNotPayWhenPlayerBalanceIsZero()
        {
            var player = PlayerServices.Create(Name.Horse);
            var game = GameServices.Create(new[] { player });

            (_, player) = game.IncomeTaxActivity(player);

            Assert.AreEqual(new Money(0), player.Balance);
        }

        [TestMethod]
        public void PlayerLandsOnIncomeTaxAndPays10PercentUpToBalanceOf2000()
        {
            var player = PlayerServices.Create(Name.Horse, balance: new Money(2000));
            var game = GameServices.Create(new[] { player });

            (_, player) = game.IncomeTaxActivity(player);

            Assert.AreEqual(new Money(1800), player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverIncomeTaxAndBalanceDoesNotChange()
        {
            var player = PlayerServices.Create(Name.Horse, LocationIndex.BalticAve, new Money(2000));
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(7);

            (_, player) = game.TakeTurn(player, rollResult);

            Assert.AreEqual(new Money(2000), player.Balance);
            Assert.AreEqual(LocationIndex.JustVisiting, player.Location);
        }

        [TestMethod]
        public void PlayerLandsOnLuxuryTaxAndPays75()
        {
            var player = PlayerServices.Create(Name.Horse, balance: new Money(100));
            var game = GameServices.Create(new[] { player });

            (_, player) = game.LuxuryTaxActivity(player);

            Assert.AreEqual(new Money(25), player.Balance);
        }

        [TestMethod]
        public void PlayerPassesOverLuxuryTaxAndBalanceDoesNotChange()
        {
            var startingBalance = new Money(100);
            var player = PlayerServices.Create(Name.Horse, LocationIndex.ParkPlace, startingBalance);
            var game = GameServices.Create(new[] { player }).StartNewRound();
            var rollResult = new RollResult(13);

            (_, player) = game.TakeTurn(player, rollResult);

            var expectedBalance = startingBalance.Add(Money.PassingGoPayout);
            Assert.AreEqual(expectedBalance, player.Balance);
            Assert.AreEqual(LocationIndex.JustVisiting, player.Location);
        }
    }
}

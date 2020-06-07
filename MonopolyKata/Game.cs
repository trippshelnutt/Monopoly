﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Game
    {
        private Game() { }

        public Game(IEnumerable<Player> players, Board board, Die die, IList<Round> rounds)
        {
            Players = players;
            Board = board;
            Die = die;
            Rounds = rounds;
        }

        public IEnumerable<Player> Players { get; }
        public IDictionary<Name, Player> PlayersByName => Players.ToDictionary(p => p.Name, p => p);
        public Board Board { get; }
        public Die Die { get; }
        public IList<Round> Rounds { get; }

        public Game With(IEnumerable<Player> players = null, Board? board = null, Die? die = null, IList<Round> rounds = null)
        {
            return new Game(players ?? Players, board ?? Board, die ?? Die, rounds ?? Rounds);
        }
    }

    public static class GameServices
    {
        private const int MinimumNumberOfPlayers = 2;
        private const int MaximumNumberOfPlayers = 8;
        private const int NumberOfRounds = 20;

        public static Game Create(IEnumerable<Name> names)
        {
            return Create(names.Select(n => PlayerServices.Create(n)));
        }

        public static Game Create(IEnumerable<Player> players)
        {
            return new Game(players, BoardServices.Create(), DieServices.Create(), new List<Round>()).ShufflePlayers();
        }


        private static Game UpdatePlayer(this Game game, Player player)
        {
            return game.With(players: game.Players.Select(p => p.Name.Value == player.Name.Value ? player : p));
        }

        private static Game UpdateRound(this Game game, Round round)
        {
            return game.With(rounds: game.Rounds.Select(r => r.RoundNumber.Value == round.RoundNumber.Value ? round : r).ToList());
        }

        public static Game ValidateNumberOfPlayers(this Game game)
        {
            if (game.Players.Count() < MinimumNumberOfPlayers || game.Players.Count() > MaximumNumberOfPlayers)
            {
                throw new Exception();
            }

            return game;
        }

        public static Game ShufflePlayers(this Game game)
        {
            return game.With(game.Players.OrderBy(p => Guid.NewGuid()).ToList());
        }

        public static Game Play(this Game game)
        {
            game = game.ValidateNumberOfPlayers()
                .ShufflePlayers();

            for (var i = 0; i < NumberOfRounds; i++)
            {
                game = game.PlayRound(); 
            }

            return game;
        }

        public static Game PlayRound(this Game game)
        {
            game = game.StartNewRound();

            foreach (var player in game.Players)
            {
                (game, _) = game.RollAndTakeTurn(player);
            }

            return game;
        }

        public static Game StartNewRound(this Game game)
        {
            var round = new Round(new RoundNumber(game.Rounds.Count() + 1), new List<Turn>());
            return game.With(rounds: game.Rounds.Append(round).ToList());
        }

        public static (Game, Player) RollAndTakeTurn(this Game game, Player player)
        {
            var rollResult = game.Die.Roll();
            return game.TakeTurn(player, rollResult);
        }

        public static (Game, Player) TakeTurn(this Game game, Player player, RollResult rollResult)
        {
            var (timesPassingGo, location) = game.Board.MovePlayer(player.Location, rollResult);
            (game, player) = game.DepositMoneyForPlayer(player, new Money(timesPassingGo * MonopolyConstants.PassingGoPayout.Amount));

            (game, player) = game.MovePlayerToLocation(player, location);
            (game, player) = game.ProcessLocationActivities(player);

            return (game.AddTurn(new Turn(player)), player);
        }

        public static (Game, Player) DepositMoneyForPlayer(this Game game, Player player, Money amountToDeposit)
        {
            player = player.DepositMoney(amountToDeposit);
            return (game.UpdatePlayer(player), player);
        }

        public static (Game, Player) MovePlayerToLocation(this Game game, Player player, Location location)
        {
            player = player.MoveToLocation(location);
            return (game.UpdatePlayer(player), player);
        }

        public static (Game, Player) ProcessLocationActivities(this Game game, Player player)
        {
            if (player.Location.Equals(LocationConstants.GoToJail))
            {
                (game, player) = game.MovePlayerToLocation(player, LocationConstants.JustVisiting);
            }

            return (game, player);
        }

        public static Game AddTurn(this Game game, Turn turn)
        {
            var round = game.Rounds.Last();
            round = round.With(turns: round.Turns.Append(turn).ToList());
            return game.UpdateRound(round);
        }
    }
}

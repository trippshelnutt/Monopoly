using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Game
    {
        public Game(IEnumerable<Player> players, Board board, Die die, IList<Round> rounds)
        {
            Players = players;
            Board = board;
            Die = die;
            Rounds = rounds;
        }

        public IEnumerable<Player> Players { get; }
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

        public static Game Create(IEnumerable<string> names)
        {
            return Create(names.Select(n => Player.Create(n)));
        }

        public static Game Create(IEnumerable<Player> players)
        {
            if (players.Count() < MinimumNumberOfPlayers || players.Count() > MaximumNumberOfPlayers)
            {
                throw new Exception();
            }

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

        public static Game ShufflePlayers(this Game game)
        {
            return game.With(game.Players.OrderBy(p => Guid.NewGuid()).ToList());
        }

        public static Game Play(this Game game)
        {
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
                game = game.TakeTurn(player);
            }
            return game;
        }

        public static Game StartNewRound(this Game game)
        {
            var round = new Round(new RoundNumber(game.Rounds.Count() + 1), new List<Turn>());
            return game.With(rounds: game.Rounds.Append(round).ToList());
        }

        public static Game TakeTurn(this Game game, Player player)
        {
            var rollResult = game.Die.Roll();
            var updatedPlayer = game.Board.MovePlayer(player, rollResult);
            game = game.UpdatePlayer(updatedPlayer);
            return game.AddTurn(new Turn(player));
        }

        public static Game AddTurn(this Game game, Turn turn)
        {
            var round = game.Rounds.Last();
            round = round.With(turns: round.Turns.Append(turn).ToList());
            return game.UpdateRound(round);
        }
    }
}

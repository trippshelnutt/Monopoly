using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Game
    {
        private const int MinimumNumberOfPlayers = 2;
        private const int MaximumNumberOfPlayers = 8;
        private const int NumberOfRounds = 20;

        private Game(IEnumerable<Player> players = null, Board? board = null, Die? die = null, IList<Round> rounds = null)
        {
            Players = players ?? Enumerable.Empty<Player>();
            Board = board ?? Board.Create();
            Die = die ?? Die.Create();
            Rounds = rounds ?? Enumerable.Empty<Round>().ToList();
        }

        public IEnumerable<Player> Players { get; }
        public Board Board { get; }
        public Die Die { get; }
        public IList<Round> Rounds { get; }

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

            return new Game(players, Board.Create(), Die.Create(), new List<Round>()).ShufflePlayers();
        }

        private Game With(IEnumerable<Player> players = null, Board? board = null, Die? die = null, IList<Round> rounds = null)
        {
            return new Game(players ?? Players, board ?? Board, die ?? Die, rounds ?? Rounds);
        }

        private Game UpdatePlayer(Player player)
        {
            return With(players: Players.Select(p => p.Name.Value == player.Name.Value ? player : p));
        }

        private Game UpdateRound(Round round)
        {
            return With(rounds: Rounds.Select(r => r.RoundNumber.Value == round.RoundNumber.Value ? round : r).ToList());
        }

        public Game ShufflePlayers()
        {
            return With(Players.OrderBy(p => Guid.NewGuid()).ToList());
        }

        public Game Play()
        {
            var game = this;
            for (var i = 0; i < NumberOfRounds; i++)
            {
                game = game.PlayRound(); 
            }
            return game;
        }

        public Game PlayRound()
        {
            var game = StartNewRound();
            foreach (var player in Players)
            {
                game = game.TakeTurn(player);
            }
            return game;
        }

        public Game StartNewRound()
        {
            var round = new Round(new RoundNumber(Rounds.Count() + 1), new List<Turn>());
            return With(rounds: Rounds.Append(round).ToList());
        }

        public Game TakeTurn(Player player)
        {
            var rollResult = Die.Roll();
            var updatedPlayer = Board.MovePlayer(player, rollResult);
            var game = UpdatePlayer(updatedPlayer);
            return game.AddTurn(new Turn(player));
        }

        public Game AddTurn(Turn turn)
        {
            var round = Rounds.Last().With(turns: Rounds.Last().Turns.Append(turn).ToList());
            return UpdateRound(round);
        }
    }
}

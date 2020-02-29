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

        private Game(IEnumerable<Player> players)
        {
            Players = players;
        }

        public IEnumerable<Player> Players { get; }

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

            return new Game(players).ShufflePlayers();
        }

        public Game With(IEnumerable<Player> players = null)
        {
            return new Game(players ?? Players);
        }

        public Game ShufflePlayers()
        {
            return With(Players.OrderBy(p => Guid.NewGuid()).ToList());
        }

        public IEnumerable<Round> Play()
        {
            var game = this;
            return Enumerable.Range(1, NumberOfRounds).Select(i => game.PlayRound());
        }

        public Round PlayRound()
        {
            var game = this;
            return new Round(Players.Select(p => game.TakeTurn(p)).ToList());
        }

        public Turn TakeTurn(Player player)
        {
            return new Turn(player);
        }
    }
}

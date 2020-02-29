using System;
using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Game
    {
        public const int MinimumNumberOfPlayers = 2;
        public const int MaximumNumberOfPlayers = 8;

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
    }
}

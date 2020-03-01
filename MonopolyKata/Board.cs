using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Board
    {
        public const int NumberOfLocations = 40;

        public Board(IList<Location> locations)
        {
            Locations = locations;
        }

        public IList<Location> Locations { get; }
    }

    public static class BoardServices
    {
        public static Board Create()
        {
            return new Board(Enumerable.Range(0, 40).Select(i => new Location(i)).ToList());
        }

        public static Player MovePlayer(this Board board, Player player, RollResult rollResult)
        {
            player = player.MoveToLocation(board.GetNewLocation(player.Location, rollResult.Value));
            return player;
        }

        private static Location GetNewLocation(this Board board, Location location, int numberToMove)
        {
            var newIndex = (location.Index + numberToMove) % board.Locations.Count();
            return new Location(newIndex);
        }
    }
}

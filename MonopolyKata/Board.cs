using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Board
    {
        public const int NumberOfLocations = 40;

        private Board(IList<Location> locations)
        {
            Locations = locations;
        }

        public IList<Location> Locations { get; }

        public static Board Create()
        {
            return new Board(Enumerable.Range(0, 40).Select(i => new Location(i)).ToList());
        }

        public Player MovePlayer(Player player, RollResult rollResult)
        {
            player = player.With(location: GetNewLocation(player.Location, rollResult.Value));
            return player;
        }

        private Location GetNewLocation(Location location, int numberToMove)
        {
            var newIndex = (location.Index + numberToMove) % Locations.Count();
            return new Location(newIndex);
        }
    }
}

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

        public static (int timesPassingGo, Location newLocation) MovePlayer(this Board board, Location location, RollResult rollResult)
        {
            var timesPassingGo = board.GetNumberOfTimesPassingGo(location, rollResult.Value);
            location = board.GetNewLocation(location, rollResult.Value);
            return (timesPassingGo, location);
        }

        public static int GetNumberOfTimesPassingGo(this Board board, Location location, int numberToMove)
        {
            return (location.Index + numberToMove) / board.Locations.Count();
        }

        public static Location GetNewLocation(this Board board, Location location, int numberToMove)
        {
            var newIndex = (location.Index + numberToMove) % board.Locations.Count();
            return new Location(newIndex);
        }
    }
}

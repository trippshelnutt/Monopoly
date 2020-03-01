using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Board
    {
        public const int NumberOfLocations = 40;

        private Board() { }

        public Board(IList<LocationIndex> locations)
        {
            Locations = locations;
        }

        public IList<LocationIndex> Locations { get; }
    }

    public static class BoardServices
    {
        public static Board Create()
        {
            return new Board(Enumerable.Range(0, 40).Select(i => new LocationIndex(i)).ToList());
        }

        public static (int timesPassingGo, LocationIndex newLocation) MovePlayer(this Board board, LocationIndex location, RollResult rollResult)
        {
            var timesPassingGo = board.GetNumberOfTimesPassingGo(location, rollResult.Value);
            location = board.GetNewLocation(location, rollResult.Value);
            return (timesPassingGo, location);
        }

        public static int GetNumberOfTimesPassingGo(this Board board, LocationIndex location, int numberToMove)
        {
            return (location.Value + numberToMove) / board.Locations.Count();
        }

        public static LocationIndex GetNewLocation(this Board board, LocationIndex location, int numberToMove)
        {
            var newIndex = (location.Value + numberToMove) % board.Locations.Count();
            return new LocationIndex(newIndex);
        }
    }
}

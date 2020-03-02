using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Board
    {
        public const int NumberOfLocations = 40;

        public Board(IDictionary<LocationIndex, Location> locations)
        {
            Locations = locations;
        }

        public IDictionary<LocationIndex, Location> Locations { get; }
    }

    public static class BoardServices
    {
        private static IDictionary<LocationIndex, Location> LocationDictionary;

        public static Board Create()
        {
            return new Board(GetLocationDictionary());
        }

        public static IDictionary<LocationIndex, Location> GetLocationDictionary()
        {
            LocationDictionary = LocationDictionary ?? new List<Location>()
            {
                new Location(LocationIndex.Go, LocationType.Go),
                new Location(LocationIndex.MediterraneanAve, LocationType.Property),
                new Location(LocationIndex.Location2, LocationType.Empty),
                new Location(LocationIndex.BalticAve, LocationType.Property),
                new Location(LocationIndex.IncomeTax, LocationType.IncomeTax),
                new Location(LocationIndex.ReadingRailroad, LocationType.Property),
                new Location(LocationIndex.OrientalAve, LocationType.Property),
                new Location(LocationIndex.Location7, LocationType.Empty),
                new Location(LocationIndex.VermontAve, LocationType.Property),
                new Location(LocationIndex.ConnecticutAve, LocationType.Property),
                new Location(LocationIndex.JustVisiting, LocationType.Empty),
                new Location(LocationIndex.StCharlesPlace, LocationType.Property),
                new Location(LocationIndex.ElectricCompany, LocationType.Property),
                new Location(LocationIndex.StatesAve, LocationType.Property),
                new Location(LocationIndex.VirginiaAve, LocationType.Property),
                new Location(LocationIndex.PennsylvaniaRailroad, LocationType.Property),
                new Location(LocationIndex.StJamesPlace, LocationType.Property),
                new Location(LocationIndex.Location17, LocationType.Empty),
                new Location(LocationIndex.TennesseeAve, LocationType.Property),
                new Location(LocationIndex.NewYorkAve, LocationType.Property),
                new Location(LocationIndex.FreeParking, LocationType.Empty),
                new Location(LocationIndex.KentuckyAve, LocationType.Property),
                new Location(LocationIndex.Location22, LocationType.Empty),
                new Location(LocationIndex.IndianaAve, LocationType.Property),
                new Location(LocationIndex.IllinoisAve, LocationType.Property),
                new Location(LocationIndex.BAndORailroad, LocationType.Property),
                new Location(LocationIndex.AtlanticAve, LocationType.Property),
                new Location(LocationIndex.VentnorAve, LocationType.Property),
                new Location(LocationIndex.WaterWorks, LocationType.Property),
                new Location(LocationIndex.MarvinGardens, LocationType.Property),
                new Location(LocationIndex.GoToJail, LocationType.GoToJail),
                new Location(LocationIndex.PacificAve, LocationType.Property),
                new Location(LocationIndex.NorthCarolinaAve, LocationType.Property),
                new Location(LocationIndex.Location33, LocationType.Empty),
                new Location(LocationIndex.PennsylvaniaAve, LocationType.Property),
                new Location(LocationIndex.ShortLineRailroad, LocationType.Property),
                new Location(LocationIndex.Location36, LocationType.Empty),
                new Location(LocationIndex.ParkPlace, LocationType.Property),
                new Location(LocationIndex.LuxuryTax, LocationType.LuxuryTax),
                new Location(LocationIndex.Boardwalk, LocationType.Property),
            }.ToDictionary(l => l.Index);

            return LocationDictionary;
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

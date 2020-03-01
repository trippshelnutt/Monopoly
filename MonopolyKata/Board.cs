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

        public static Board Create()
        {
            return new Board(BuildLocationDictionary());
        }

        private static IDictionary<LocationIndex, Location> BuildLocationDictionary()
        {
            return new List<Location>()
            {
                new Location(LocationIndex.Go, LocationType.Go),
                new Location(LocationIndex.MediterraneanAve, LocationType.RealEstate),
                new Location(LocationIndex.Location2, LocationType.Empty),
                new Location(LocationIndex.BalticAve, LocationType.RealEstate),
                new Location(LocationIndex.IncomeTax, LocationType.IncomeTax),
                new Location(LocationIndex.ReadingRailroad, LocationType.Railroad),
                new Location(LocationIndex.OrientalAve, LocationType.RealEstate),
                new Location(LocationIndex.Location7, LocationType.Empty),
                new Location(LocationIndex.VermontAve, LocationType.RealEstate),
                new Location(LocationIndex.ConnecticutAve, LocationType.RealEstate),
                new Location(LocationIndex.JustVisiting, LocationType.Empty),
                new Location(LocationIndex.StCharlesPlace, LocationType.RealEstate),
                new Location(LocationIndex.ElectricCompany, LocationType.Utility),
                new Location(LocationIndex.StatesAve, LocationType.RealEstate),
                new Location(LocationIndex.VirginiaAve, LocationType.RealEstate),
                new Location(LocationIndex.PennsylvaniaRailroad, LocationType.Railroad),
                new Location(LocationIndex.StJamesPlace, LocationType.RealEstate),
                new Location(LocationIndex.Location17, LocationType.Empty),
                new Location(LocationIndex.TennesseeAve, LocationType.RealEstate),
                new Location(LocationIndex.NewYorkAve, LocationType.RealEstate),
                new Location(LocationIndex.FreeParking, LocationType.Empty),
                new Location(LocationIndex.KentuckyAve, LocationType.RealEstate),
                new Location(LocationIndex.Location22, LocationType.Empty),
                new Location(LocationIndex.IndianaAve, LocationType.RealEstate),
                new Location(LocationIndex.IllinoisAve, LocationType.RealEstate),
                new Location(LocationIndex.BAndORailroad, LocationType.Railroad),
                new Location(LocationIndex.AtlanticAve, LocationType.RealEstate),
                new Location(LocationIndex.VentnorAve, LocationType.RealEstate),
                new Location(LocationIndex.WaterWorks, LocationType.Utility),
                new Location(LocationIndex.MarvinGardens, LocationType.RealEstate),
                new Location(LocationIndex.GoToJail, LocationType.GoToJail),
                new Location(LocationIndex.PacificAve, LocationType.RealEstate),
                new Location(LocationIndex.NorthCarolinaAve, LocationType.RealEstate),
                new Location(LocationIndex.Location33, LocationType.Empty),
                new Location(LocationIndex.PennsylvaniaAve, LocationType.RealEstate),
                new Location(LocationIndex.ShortLineRailroad, LocationType.Railroad),
                new Location(LocationIndex.Location36, LocationType.Empty),
                new Location(LocationIndex.ParkPlace, LocationType.RealEstate),
                new Location(LocationIndex.LuxuryTax, LocationType.LuxuryTax),
                new Location(LocationIndex.Boardwalk, LocationType.RealEstate),
            }.ToDictionary(l => l.Index);
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

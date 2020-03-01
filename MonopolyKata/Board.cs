using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public class Board
    {
        public const int NumberOfLocations = 40;

        private Board() { }

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
                new Location(LocationConstants.Go, LocationType.Go),
                new Location(LocationConstants.MediterraneanAve, LocationType.RealEstate),
                new Location(LocationConstants.Location2, LocationType.Empty),
                new Location(LocationConstants.BalticAve, LocationType.RealEstate),
                new Location(LocationConstants.IncomeTax, LocationType.IncomeTax),
                new Location(LocationConstants.ReadingRailroad, LocationType.Railroad),
                new Location(LocationConstants.OrientalAve, LocationType.RealEstate),
                new Location(LocationConstants.Location7, LocationType.Empty),
                new Location(LocationConstants.VermontAve, LocationType.RealEstate),
                new Location(LocationConstants.ConnecticutAve, LocationType.RealEstate),
                new Location(LocationConstants.JustVisiting, LocationType.Empty),
                new Location(LocationConstants.StCharlesPlace, LocationType.RealEstate),
                new Location(LocationConstants.ElectricCompany, LocationType.Utility),
                new Location(LocationConstants.StatesAve, LocationType.RealEstate),
                new Location(LocationConstants.VirginiaAve, LocationType.RealEstate),
                new Location(LocationConstants.PennsylvaniaRailroad, LocationType.Railroad),
                new Location(LocationConstants.StJamesPlace, LocationType.RealEstate),
                new Location(LocationConstants.Location17, LocationType.Empty),
                new Location(LocationConstants.TennesseeAve, LocationType.RealEstate),
                new Location(LocationConstants.NewYorkAve, LocationType.RealEstate),
                new Location(LocationConstants.FreeParking, LocationType.Empty),
                new Location(LocationConstants.KentuckyAve, LocationType.RealEstate),
                new Location(LocationConstants.Location22, LocationType.Empty),
                new Location(LocationConstants.IndianaAve, LocationType.RealEstate),
                new Location(LocationConstants.IllinoisAve, LocationType.RealEstate),
                new Location(LocationConstants.BAndORailroad, LocationType.Railroad),
                new Location(LocationConstants.AtlanticAve, LocationType.RealEstate),
                new Location(LocationConstants.VentnorAve, LocationType.RealEstate),
                new Location(LocationConstants.WaterWorks, LocationType.Utility),
                new Location(LocationConstants.MarvinGardens, LocationType.RealEstate),
                new Location(LocationConstants.GoToJail, LocationType.GoToJail),
                new Location(LocationConstants.PacificAve, LocationType.RealEstate),
                new Location(LocationConstants.NorthCarolinaAve, LocationType.RealEstate),
                new Location(LocationConstants.Location33, LocationType.Empty),
                new Location(LocationConstants.PennsylvaniaAve, LocationType.RealEstate),
                new Location(LocationConstants.ShortLineRailroad, LocationType.Railroad),
                new Location(LocationConstants.Location36, LocationType.Empty),
                new Location(LocationConstants.ParkPlace, LocationType.RealEstate),
                new Location(LocationConstants.LuxuryTax, LocationType.LuxuryTax),
                new Location(LocationConstants.Boardwalk, LocationType.RealEstate),
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

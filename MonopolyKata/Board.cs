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
                new Location(LocationConstants.Go, LocationConstants.GoType),
                new Location(LocationConstants.MediterraneanAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.Location2, LocationConstants.EmptyType),
                new Location(LocationConstants.BalticAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.IncomeTax, LocationConstants.IncomeTaxType),
                new Location(LocationConstants.ReadingRailroad, LocationConstants.RailroadType),
                new Location(LocationConstants.OrientalAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.Location7, LocationConstants.EmptyType),
                new Location(LocationConstants.VermontAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.ConnecticutAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.JustVisiting, LocationConstants.EmptyType),
                new Location(LocationConstants.StCharlesPlace, LocationConstants.RealEstateType),
                new Location(LocationConstants.ElectricCompany, LocationConstants.UtilityType),
                new Location(LocationConstants.StatesAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.VirginiaAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.PennsylvaniaRailroad, LocationConstants.RailroadType),
                new Location(LocationConstants.StJamesPlace, LocationConstants.RealEstateType),
                new Location(LocationConstants.Location17, LocationConstants.EmptyType),
                new Location(LocationConstants.TennesseeAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.NewYorkAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.FreeParking, LocationConstants.EmptyType),
                new Location(LocationConstants.KentuckyAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.Location22, LocationConstants.EmptyType),
                new Location(LocationConstants.IndianaAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.IllinoisAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.BAndORailroad, LocationConstants.RailroadType),
                new Location(LocationConstants.AtlanticAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.VentnorAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.WaterWorks, LocationConstants.UtilityType),
                new Location(LocationConstants.MarvinGardens, LocationConstants.RealEstateType),
                new Location(LocationConstants.GoToJail, LocationConstants.GoToJailType),
                new Location(LocationConstants.PacificAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.NorthCarolinaAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.Location33, LocationConstants.EmptyType),
                new Location(LocationConstants.PennsylvaniaAve, LocationConstants.RealEstateType),
                new Location(LocationConstants.ShortLineRailroad, LocationConstants.RailroadType),
                new Location(LocationConstants.Location36, LocationConstants.EmptyType),
                new Location(LocationConstants.ParkPlace, LocationConstants.RealEstateType),
                new Location(LocationConstants.LuxuryTax, LocationConstants.LuxuryTaxType),
                new Location(LocationConstants.Boardwalk, LocationConstants.RealEstateType),
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

using System.Collections.Generic;

namespace MonopolyKata
{

    public readonly struct Money
    {
        public Money(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public override string ToString()
        {
            return $"Money: {Amount}";
        }

        // Payouts
        public static readonly Money PassingGoPayout = new Money(200);

        // Costs
        public static readonly Money MediterraneanAveCost = new Money(60);
        public static readonly Money BalticAveCost = new Money(60);
        public static readonly Money OrientalAveCost = new Money(100);
        public static readonly Money VermontAveCost = new Money(100);
        public static readonly Money ConnecticutAveCost = new Money(120);
        public static readonly Money StCharlesPlaceCost = new Money(140);
        public static readonly Money StatesAveCost = new Money(140);
        public static readonly Money VirginiaAveCost = new Money(160);
        public static readonly Money StJamesPlaceCost = new Money(180);
        public static readonly Money TennesseeAveCost = new Money(180);
        public static readonly Money NewYorkAveCost = new Money(200);
        public static readonly Money KentuckyAveCost = new Money(220);
        public static readonly Money IndianaAveCost = new Money(220);
        public static readonly Money IllinoisAveCost = new Money(240);
        public static readonly Money AtlanticAveCost = new Money(260);
        public static readonly Money VentnorAveCost = new Money(260);
        public static readonly Money MarvinGardensCost = new Money(280);
        public static readonly Money PacificAveCost = new Money(300);
        public static readonly Money NorthCarolinaAveCost = new Money(300);
        public static readonly Money PennsylvaniaAveCost = new Money(320);
        public static readonly Money ParkPlaceCost = new Money(350);
        public static readonly Money BoardwalkCost = new Money(400);
        public static readonly Money RailroadCost = new Money(200);
        public static readonly Money UtilityCost = new Money(150);

        // Rents
        public static readonly Money MediterraneanAveRent = new Money(2);
        public static readonly Money BalticAveRent = new Money(4);
        public static readonly Money OrientalAveRent = new Money(6);
        public static readonly Money VermontAveRent = new Money(6);
        public static readonly Money ConnecticutAveRent = new Money(8);
        public static readonly Money StCharlesPlaceRent = new Money(10);
        public static readonly Money StatesAveRent = new Money(10);
        public static readonly Money VirginiaAveRent = new Money(12);
        public static readonly Money StJamesPlaceRent = new Money(14);
        public static readonly Money TennesseeAveRent = new Money(14);
        public static readonly Money NewYorkAveRent = new Money(16);
        public static readonly Money KentuckyAveRent = new Money(18);
        public static readonly Money IndianaAveRent = new Money(18);
        public static readonly Money IllinoisAveRent = new Money(20);
        public static readonly Money AtlanticAveRent = new Money(22);
        public static readonly Money VentnorAveRent = new Money(22);
        public static readonly Money MarvinGardensRent = new Money(24);
        public static readonly Money PacificAveRent = new Money(26);
        public static readonly Money NorthCarolinaAveRent = new Money(26);
        public static readonly Money PennsylvaniaAveRent = new Money(28);
        public static readonly Money ParkPlaceRent = new Money(35);
        public static readonly Money BoardwalkRent = new Money(50);
        public static readonly Money RailroadRent = new Money(0);
        public static readonly Money UtilityRent = new Money(0);
    }

    public static class MoneyServices
    {
        private static IDictionary<LocationIndex, Money> CostDictionary;
        private static IDictionary<LocationIndex, Money> RentDictionary;

        public static Money Add(this Money money, Money moneyToAdd)
        {
            return new Money(money.Amount + moneyToAdd.Amount);
        }

        public static Money Subtract(this Money money, Money moneyToSubtract)
        {
            return new Money(money.Amount - moneyToSubtract.Amount);
        }

        public static Money GetCost(LocationIndex index)
        {
            CostDictionary = CostDictionary ?? new Dictionary<LocationIndex, Money>
            {
                { LocationIndex.MediterraneanAve, Money.MediterraneanAveCost },
                { LocationIndex.BalticAve, Money.BalticAveCost },
                { LocationIndex.OrientalAve, Money.OrientalAveCost },
                { LocationIndex.VermontAve, Money.VermontAveCost },
                { LocationIndex.ConnecticutAve, Money.ConnecticutAveCost },
                { LocationIndex.StCharlesPlace, Money.StCharlesPlaceCost },
                { LocationIndex.StatesAve, Money.StatesAveCost },
                { LocationIndex.VirginiaAve, Money.VirginiaAveCost },
                { LocationIndex.StJamesPlace, Money.StJamesPlaceCost },
                { LocationIndex.TennesseeAve, Money.TennesseeAveCost },
                { LocationIndex.NewYorkAve, Money.NewYorkAveCost },
                { LocationIndex.KentuckyAve, Money.KentuckyAveCost },
                { LocationIndex.IndianaAve, Money.IndianaAveCost },
                { LocationIndex.IllinoisAve, Money.IllinoisAveCost },
                { LocationIndex.AtlanticAve, Money.AtlanticAveCost },
                { LocationIndex.VentnorAve, Money.VentnorAveCost },
                { LocationIndex.MarvinGardens, Money.MarvinGardensCost },
                { LocationIndex.PacificAve, Money.PacificAveCost },
                { LocationIndex.NorthCarolinaAve, Money.NorthCarolinaAveCost },
                { LocationIndex.PennsylvaniaAve, Money.PennsylvaniaAveCost },
                { LocationIndex.ParkPlace, Money.ParkPlaceCost },
                { LocationIndex.Boardwalk, Money.BoardwalkCost },
                { LocationIndex.ReadingRailroad, Money.RailroadCost },
                { LocationIndex.ShortLineRailroad, Money.RailroadCost },
                { LocationIndex.BAndORailroad, Money.RailroadCost },
                { LocationIndex.PennsylvaniaRailroad, Money.RailroadCost },
                { LocationIndex.ElectricCompany, Money.UtilityCost },
                { LocationIndex.WaterWorks, Money.UtilityCost },
            };
            return CostDictionary[index];
        }

        public static Money GetRent(LocationIndex index)
        {
            RentDictionary = RentDictionary ?? new Dictionary<LocationIndex, Money>
            {
                { LocationIndex.MediterraneanAve, Money.MediterraneanAveRent },
                { LocationIndex.BalticAve, Money.BalticAveRent },
                { LocationIndex.OrientalAve, Money.OrientalAveRent },
                { LocationIndex.VermontAve, Money.VermontAveRent },
                { LocationIndex.ConnecticutAve, Money.ConnecticutAveRent },
                { LocationIndex.StCharlesPlace, Money.StCharlesPlaceRent },
                { LocationIndex.StatesAve, Money.StatesAveRent },
                { LocationIndex.VirginiaAve, Money.VirginiaAveRent },
                { LocationIndex.StJamesPlace, Money.StJamesPlaceRent },
                { LocationIndex.TennesseeAve, Money.TennesseeAveRent },
                { LocationIndex.NewYorkAve, Money.NewYorkAveRent },
                { LocationIndex.KentuckyAve, Money.KentuckyAveRent },
                { LocationIndex.IndianaAve, Money.IndianaAveRent },
                { LocationIndex.IllinoisAve, Money.IllinoisAveRent },
                { LocationIndex.AtlanticAve, Money.AtlanticAveRent },
                { LocationIndex.VentnorAve, Money.VentnorAveRent },
                { LocationIndex.MarvinGardens, Money.MarvinGardensRent },
                { LocationIndex.PacificAve, Money.PacificAveRent },
                { LocationIndex.NorthCarolinaAve, Money.NorthCarolinaAveRent },
                { LocationIndex.PennsylvaniaAve, Money.PennsylvaniaAveRent },
                { LocationIndex.ParkPlace, Money.ParkPlaceRent },
                { LocationIndex.Boardwalk, Money.BoardwalkRent },
                { LocationIndex.ReadingRailroad, Money.RailroadRent },
                { LocationIndex.ShortLineRailroad, Money.RailroadRent },
                { LocationIndex.BAndORailroad, Money.RailroadRent },
                { LocationIndex.PennsylvaniaRailroad, Money.RailroadRent },
                { LocationIndex.ElectricCompany, Money.UtilityRent },
                { LocationIndex.WaterWorks, Money.UtilityRent },
            };
            return RentDictionary[index];
        }
    }
}

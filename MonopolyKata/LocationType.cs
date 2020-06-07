﻿namespace MonopolyKata
{
    public readonly struct LocationType
    {
        public LocationType(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"LocationType: {Value}";
        }

        public static readonly LocationType Go = new LocationType("Go");
        public static readonly LocationType GoToJail = new LocationType("GoToJail");
        public static readonly LocationType IncomeTax = new LocationType("IncomeTax");
        public static readonly LocationType LuxuryTax = new LocationType("LuxuryTax");
        public static readonly LocationType RealEstate = new LocationType("RealEstate");
        public static readonly LocationType Railroad = new LocationType("Railroad");
        public static readonly LocationType Utility = new LocationType("Utility");
        public static readonly LocationType Empty = new LocationType("Empty");
    }
}

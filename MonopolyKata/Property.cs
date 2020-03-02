namespace MonopolyKata
{
    public readonly struct Property
    {
        public Property(LocationIndex locationIndex, PropertyGroup propertyGroup, Money cost, Money rent)
        {
            LocationIndex = locationIndex;
            PropertyGroup = propertyGroup;
            Cost = cost;
            Rent = rent;
        }

        public LocationIndex LocationIndex { get; }
        public PropertyGroup PropertyGroup { get; }
        public Money Cost { get; }
        public Money Rent { get; }

        public override string ToString()
        {
            return $"Property: {LocationIndex}";
        }
    }

    public static class PropertyServices
    {
        public static Property BuildProperty(LocationIndex locationIndex)
        {
            return new Property(
                locationIndex,
                PropertyGroupServices.GetPropertyGroup(locationIndex),
                MoneyServices.GetCost(locationIndex),
                MoneyServices.GetRent(locationIndex));
        }
    }
}

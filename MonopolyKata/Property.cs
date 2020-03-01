namespace MonopolyKata
{
    public readonly struct Property
    {
        public Property(Location location, PropertyGroup propertyGroup, Money cost, Money rent)
        {
            Location = location;
            PropertyGroup = propertyGroup;
            Cost = cost;
            Rent = rent;
        }

        public Location Location { get; }
        public PropertyGroup PropertyGroup { get; }
        public Money Cost { get; }
        public Money Rent { get; }

        public override string ToString()
        {
            return $"Property: {Location}";
        }
    }
}

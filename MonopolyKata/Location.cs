namespace MonopolyKata
{
    public readonly struct Location
    {
        public Location(LocationIndex index, LocationType type)
        {
            Index = index;
            Type = type;
        }

        public LocationIndex Index { get; }
        public LocationType Type { get; }

        public override string ToString()
        {
            return $"Location: {Index}, {Type}";
        }
    }
}

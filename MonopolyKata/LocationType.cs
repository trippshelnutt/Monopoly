namespace MonopolyKata
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
    }
}

namespace MonopolyKata
{
    public readonly struct LocationIndex
    {
        public LocationIndex(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override string ToString()
        {
            return $"LocationIndex: {Value}";
        }
    }
}

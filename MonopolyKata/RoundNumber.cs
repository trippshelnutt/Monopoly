namespace MonopolyKata
{
    public readonly struct RoundNumber
    {
        public RoundNumber(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override string ToString()
        {
            return $"RoundNumber: {Value}";
        }
    }
}

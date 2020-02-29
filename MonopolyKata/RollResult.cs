namespace MonopolyKata
{
    public readonly struct RollResult
    {
        public RollResult(int value)
        {
            Value = value;
        }

        public int Value { get; }

        public override string ToString()
        {
            return $"RollResult: {Value}";
        }
    }
}

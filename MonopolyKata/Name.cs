namespace MonopolyKata
{
    public readonly struct Name
    {
        public Name(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"PlayerName: {Value}";
        }
    }
}

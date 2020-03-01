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
            return $"Name: {Value}";
        }

        public static readonly Name Horse = new Name("horse");
        public static readonly Name Car = new Name("car");
    }
}

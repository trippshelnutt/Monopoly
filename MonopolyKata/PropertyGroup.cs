namespace MonopolyKata
{
    public readonly struct PropertyGroup
    {
        public PropertyGroup(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"PropertyGroup: {Value}";
        }
    }
}

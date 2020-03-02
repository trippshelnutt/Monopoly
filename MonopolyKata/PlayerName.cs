namespace MonopolyKata
{
    public readonly struct PlayerName
    {
        public PlayerName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public override string ToString()
        {
            return $"Name: {Value}";
        }

        public static readonly PlayerName Horse = new PlayerName("horse");
        public static readonly PlayerName Car = new PlayerName("car");
    }
}

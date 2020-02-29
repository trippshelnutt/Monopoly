namespace MonopolyKata
{
    public readonly struct Location
    {
        public Location(int index)
        {
            Index = index;
        }

        public int Index { get; }

        public override string ToString()
        {
            return $"Location: {Index}";
        }
    }
}

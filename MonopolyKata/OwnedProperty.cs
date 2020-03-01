namespace MonopolyKata
{
    public readonly struct OwnedProperty
    {
        public OwnedProperty(Property property, Player owner, bool isMortgaged)
        {
            Property = property;
            Owner = owner;
            IsMortgaged = isMortgaged;
        }

        public Property Property { get; }
        public Player Owner { get; }
        public bool IsMortgaged { get; }
    }
}

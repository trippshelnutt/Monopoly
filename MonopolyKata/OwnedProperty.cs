namespace MonopolyKata
{
    public readonly struct OwnedProperty
    {
        public OwnedProperty(Property property, PlayerName ownerName, bool isMortgaged)
        {
            Property = property;
            OwnerName = ownerName;
            IsMortgaged = isMortgaged;
        }

        public Property Property { get; }
        public PlayerName OwnerName { get; }
        public bool IsMortgaged { get; }
    }
}

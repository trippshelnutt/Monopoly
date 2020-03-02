namespace MonopolyKata
{
    public readonly struct OwnedProperty
    {
        public OwnedProperty(Property property, Name ownerName, bool isMortgaged)
        {
            Property = property;
            OwnerName = ownerName;
            IsMortgaged = isMortgaged;
        }

        public Property Property { get; }
        public Name OwnerName { get; }
        public bool IsMortgaged { get; }
    }
}

namespace MonopolyKata
{
    public readonly struct Player
    {
        private Player(string name, int location)
        {
            Name = new Name(name);
            Location = new Location(location);
        }

        private Player(Name name, Location location)
        {
            Name = name;
            Location = location;
        }

        public static Player Create(string name, int location = 0)
        {
            return new Player(name, location);
        }

        public Name Name { get; }
        public Location Location { get; }

        public Player With(Name? name = null, Location? location = null)
        {
            return new Player(name ?? Name, location ?? Location);
        }
    }
}

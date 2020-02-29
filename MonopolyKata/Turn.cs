namespace MonopolyKata
{
    public readonly struct Turn 
    {
        public Turn(Player player)
        {
            Player = player;
        }

        public Player Player { get; }
    }
}

namespace MonopolyKata
{
    public readonly struct Player
    {
        private Player(string name, int location, int balance)
        {
            Name = new Name(name);
            Location = new Location(location);
            Balance = new Money(balance);
        }

        private Player(Name name, Location location, Money balance)
        {
            Name = name;
            Location = location;
            Balance = balance;
        }

        public Name Name { get; }
        public Location Location { get; }
        public Money Balance { get; }

        public static Player Create(string name, int location = 0, int balance = 0)
        {
            return new Player(name, location, balance);
        }

        private Player With(Name? name = null, Location? location = null, Money? balance = null)
        {
            return new Player(name ?? Name, location ?? Location, balance ?? Balance);
        }

        public Player MoveToLocation(Location location)
        {
            return With(location: location);
        }

        public bool HasAvailableFunds(Money money)
        {
            return Balance.Amount >= money.Amount;
        }

        public Player DepositMoney(Money moneyToDeposit)
        {
            return With(balance: Balance.Add(moneyToDeposit));
        }

        public Player WithdrawMoney(Money moneyToWithdraw)
        {
            return With(balance: Balance.Subtract(moneyToWithdraw));
        }
    }
}

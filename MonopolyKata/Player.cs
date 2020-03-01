namespace MonopolyKata
{
    public readonly struct Player
    {
        public Player(Name name, Location location, Money balance)
        {
            Name = name;
            Location = location;
            Balance = balance;
        }

        public Name Name { get; }
        public Location Location { get; }
        public Money Balance { get; }

        public Player With(Name? name = null, Location? location = null, Money? balance = null)
        {
            return new Player(name ?? Name, location ?? Location, balance ?? Balance);
        }
    }

    public static class PlayerServices
    {
        public static Player Create(Name name, Location? location = null, Money? balance = null)
        {
            return new Player(name, location ?? new Location(0), balance ?? new Money(0));
        }

        public static Player MoveToLocation(this Player player, Location location)
        {
            return player.With(location: location);
        }

        public static bool HasAvailableFunds(this Player player, Money money)
        {
            return player.Balance.Amount >= money.Amount;
        }

        public static Player DepositMoney(this Player player, Money moneyToDeposit)
        {
            return player.With(balance: player.Balance.Add(moneyToDeposit));
        }

        public static Player WithdrawMoney(this Player player, Money moneyToWithdraw)
        {
            return player.With(balance: player.Balance.Subtract(moneyToWithdraw));
        }
    }
}

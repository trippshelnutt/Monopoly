namespace MonopolyKata
{
    public readonly struct Player
    {
        public Player(PlayerName playerName, LocationIndex location, Money balance)
        {
            PlayerName = playerName;
            Location = location;
            Balance = balance;
        }

        public PlayerName PlayerName { get; }
        public LocationIndex Location { get; }
        public Money Balance { get; }

        public Player With(PlayerName? playerName = null, LocationIndex? location = null, Money? balance = null)
        {
            return new Player(playerName ?? PlayerName, location ?? Location, balance ?? Balance);
        }

        public override string ToString()
        {
            return $"Player {PlayerName}";
        }
    }

    public static class PlayerServices
    {
        public static Player Create(PlayerName playerName, LocationIndex? location = null, Money? balance = null)
        {
            return new Player(playerName, location ?? new LocationIndex(0), balance ?? new Money(0));
        }

        public static Player MoveToLocation(this Player player, LocationIndex location)
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

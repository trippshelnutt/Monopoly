namespace MonopolyKata
{

    public readonly struct Money
    {
        public Money(int amount)
        {
            Amount = amount;
        }

        public int Amount { get; }

        public override string ToString()
        {
            return $"Money: {Amount}";
        }

        public static readonly Money PassingGoPayout = new Money(200);
    }

    public static class MoneyServices
    {
        public static Money Add(this Money money, Money moneyToAdd)
        {
            return new Money(money.Amount + moneyToAdd.Amount);
        }

        public static Money Subtract(this Money money, Money moneyToSubtract)
        {
            return new Money(money.Amount - moneyToSubtract.Amount);
        }
    }
}

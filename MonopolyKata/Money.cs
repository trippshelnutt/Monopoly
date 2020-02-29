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

        public Money Add(Money money)
        {
            return new Money(Amount + money.Amount);
        }

        public Money Subtract(Money money)
        {
            return new Money(Amount - money.Amount);
        }
    }
}

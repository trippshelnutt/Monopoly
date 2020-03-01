using System;

namespace MonopolyKata
{
    public readonly struct Die
    {
        public Die(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }

        public int NumberOfSides { get; }
    }

    public static class DieServices
    {
        private const int StandardNumberOfSides = 6;
        private static readonly Random Random = new Random();

        public static Die Create(int numberOfSides = StandardNumberOfSides)
        {
            return new Die(numberOfSides);
        }

        public static RollResult Roll(this Die die)
        {
            return new RollResult(Random.Next(1, die.NumberOfSides)); 
        }
    }
}

using System;

namespace MonopolyKata
{
    public readonly struct Die
    {
        private const int StandardNumberOfSides = 6;
        private static readonly Random Random = new Random();

        private Die(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }

        public int NumberOfSides { get; }

        public static Die Create(int numberOfSides = StandardNumberOfSides)
        {
            return new Die(numberOfSides);
        }

        public RollResult Roll()
        {
            return new RollResult(Random.Next(1, NumberOfSides)); 
        }
    }
}

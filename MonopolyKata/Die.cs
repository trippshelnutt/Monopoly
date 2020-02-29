using System;

namespace MonopolyKata
{
    public readonly struct Die
    {
        private Die(int numberOfSides)
        {
            NumberOfSides = numberOfSides;
        }

        public static Die Create(int numberOfSides)
        {
            return new Die(numberOfSides);
        }

        public int NumberOfSides { get; }
    }

    public static class DieServices
    {
        public static readonly Random Random = new Random();

        public static RollResult Roll(this Die dice)
        {
            return new RollResult(Random.Next(1, dice.NumberOfSides)); 
        }
    }
}

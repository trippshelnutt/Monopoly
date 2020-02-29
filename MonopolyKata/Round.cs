using System.Collections.Generic;

namespace MonopolyKata
{
    public readonly struct Round
    {
        public Round(IEnumerable<Turn> turns)
        {
            Turns = turns;
        }

        public IEnumerable<Turn> Turns { get; }
    }
}

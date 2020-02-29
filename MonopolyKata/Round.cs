using System.Collections.Generic;

namespace MonopolyKata
{
    public readonly struct Round
    {
        public Round(IList<Turn> turns)
        {
            Turns = turns;
        }

        public IList<Turn> Turns { get; }
    }
}

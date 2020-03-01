using System.Collections.Generic;
using System.Linq;

namespace MonopolyKata
{
    public readonly struct Round
    {
        public Round(RoundNumber roundNumber, IList<Turn> turns)
        {
            RoundNumber = roundNumber;
            Turns = turns ?? Enumerable.Empty<Turn>().ToList();
        }

        public RoundNumber RoundNumber { get; }
        public IList<Turn> Turns { get; }

        public Round With(RoundNumber? roundNumber = null, IList<Turn> turns = null)
        {
            return new Round(roundNumber ?? RoundNumber, turns ?? Turns);
        }
    }
}

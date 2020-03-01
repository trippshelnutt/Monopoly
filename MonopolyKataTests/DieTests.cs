using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonopolyKata;

namespace MonopolyKataTests
{
    [TestClass]
    public class DieTests
    {
        [TestMethod]
        public void RollReturnsValueInRange()
        {
            var die = DieServices.Create();

            var results = Enumerable.Range(1, 1000).Select(i => die.Roll());

            Assert.IsTrue(results.All(r => r.Value >= 1 && r.Value <= die.NumberOfSides));
        }
    }
}

using NUnit.Framework;
using TSMApp;

namespace TSMUnittests
{
    [TestFixture]
    public class UnittestsKnopenGenerator
    {

        [TestCase]
        public void KnopenGenerator_GenereerKnopen()
        {
            Knoop[] knopen = new Knoop[20];
            KnopenGenerator KG = new KnopenGenerator();
            knopen = KG.GeneerKnopen(20);
            Assert.AreEqual(knopen.Length, 20);
        }
    }
}

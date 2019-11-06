using NUnit.Framework;
using TSMApp;


namespace TSMUnittests
{
    [TestFixture]
    public class UnittestsAfstandsBerekenaar
    {
        [TestCase]
        public void Afstandsberekenaar_BerekenAfstand2Knopen()
        {
            Knoop knoopVan = new Knoop(300, 300);
            Knoop knoopTot = new Knoop(800, 800);
            int Afstand = Afstandsberekenaar.BerekenAfstand2Knopen(knoopVan, knoopTot);
            Assert.AreEqual(707, Afstand);
        }

        [TestCase]
        public void Afstandsberekenaar_BerekenLengteRoute()
        {
            Knoop[] Route = new Knoop[4];
            for (int i = 0; i < 4; i++)
            {
                Route[i] = new Knoop(i * 100, i * 200);
            }
            int Lengte = Afstandsberekenaar.BerekenRouteLengte(Route);
            Assert.AreEqual(1339, Lengte);
        }
    }
}

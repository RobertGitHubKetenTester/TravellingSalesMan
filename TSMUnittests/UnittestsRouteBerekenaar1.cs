using NUnit.Framework;
using TSMApp;

namespace TSMUnittests
{
    [TestFixture]
    public class UnittestsRouteBerekenaar1
    {

        [TestCase]
        public void RouteBerekenaar1_ZoekRoute_controleer_lengte()
        {
            //voorbereiding: maak een aantal knopen
            int aantalKnoop = 15;
            Knoop[] knopen_gen = new Knoop[aantalKnoop];
            for (int i = 0; i < aantalKnoop; i++)
            {
                knopen_gen[i] = new Knoop(i * 100, i * 200);
            }

            //testuitvoering
            RouteBerekenaar1 RB1 = new RouteBerekenaar1();
            Knoop[] knopen_calc = RB1.ZoekRoute(knopen_gen);

            //controle route dmv bepalen lengte
            int Lengte = Afstandsberekenaar.BerekenRouteLengte(knopen_calc);
            Assert.AreEqual(6252, Lengte);
        }

    }
}

using System;
using TechTalk.SpecFlow;
using TSMApp;
using NUnit.Framework;


namespace TSMIntegratietests
{
    [Binding]
    public class IntegratietestsMetGherkinsyntaxSteps
    {
        Knoop[] knopen_gen;
        Knoop[] knopen_calc;
        int aantalKnopen = 5;   //intieel aantal knopen
        int berekenMethode = 1; //methode 1 of 2
        int Lengte = 0;         //totale lengte van een route

        [Given(@"De knopen worden initieel gegenereerd")]
        public void GivenDeKnopenWordenInitieelGegenereerd()
        {
            knopen_gen = new Knoop[aantalKnopen];
            KnopenGenerator KGinit = new KnopenGenerator();
            knopen_gen = KGinit.GeneerKnopen(aantalKnopen);
        }


        [When(@"Ik klik  (.*) maal op de plusbutton")]
        public void WhenIkKlikMaalOpDePlusbutton(int aantal)
        {
            aantalKnopen = aantalKnopen + (aantal * 3);
            knopen_gen = new Knoop[aantalKnopen];
            KnopenGenerator KG = new KnopenGenerator();
            knopen_gen = KG.GeneerKnopen(aantalKnopen);
        }
        
        [When(@"Ik klik op het berekenen volgens methode(.*)")]
        public void WhenIkKlikOpHetBerekenenVolgensMethode(int methode)
        {
            berekenMethode = methode;
        }

        [Then(@"toont het scherm (.*) knopen")]
        public void ThenToontHetSchermKnopen(int p0)
        {
            Assert.AreEqual(aantalKnopen, p0);
        }
        
        [Then(@"wordt de route berekend")]
        public void ThenWordtDeRouteBerekend()
        {
            knopen_calc = new Knoop[aantalKnopen];
            if (berekenMethode == 1)
            {
                RouteBerekenaar1 RB1 = new RouteBerekenaar1();
                knopen_calc = RB1.ZoekRoute(knopen_gen);
            }
            else if (berekenMethode == 2)
            {
                RouteBerekenaar2 RB2 = new RouteBerekenaar2();
                knopen_calc = RB2.ZoekRoute(knopen_gen);
            }
        }
        
        [Then(@"wordt de route getoond")]
        public void ThenWordtDeRouteGetoond()
        {
            Assert.AreEqual(knopen_calc.Length, knopen_gen.Length);
        }
        
        [Then(@"wordt de totale  afstand getoond")]
        public void ThenWordtDeTotaleAfstandGetoond()
        {
            Lengte = Afstandsberekenaar.BerekenRouteLengte(knopen_calc);
            Assert.GreaterOrEqual(Lengte, 0);
        }
    }
}

using NUnit.Framework;
using System;
using TechTalk.SpecFlow;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TSMUItests
{
    [Binding]
    public class SpecFlowTestsMetGherkinsyntaxSteps
    {

        AndroidApp app;
        int routelengte_laatst = 0;
        int routelengte_eerder = 0;

        [Given(@"De app is gestart")]
        public void GivenDeAppIsGestart()
        {
            app = ConfigureApp
                 .Android
                 .EnableLocalScreenshots()
                 .ApkFile("C:/data/visualstudio_diverseprojecten/travellingsalesman/TSMApp/bin/Debug/TSMApp.TSMApp.apk")
                 .StartApp();
            app.WaitForElement(c => c.Id("action_bar"));
        }
        
        [When(@"Ik klik  (.*) maal op de plusbutton")]
        public void WhenIkKlikMaalOpDePlusbutton(int nklik)
        {
            app.WaitForElement(c => c.Id("plusButton"));
            for (int i = 1; i <= nklik; i++)
            {
                app.Tap(c => c.Id("plusButton"));
            }
        }



        [When(@"Ik klik  (.*) maal op de minbutton")]
        public void WhenIkKlikMaalOpDeMinbutton(int nklik)
        {
            app.WaitForElement(c => c.Id("minButton"));
            app.Flash(c => c.Id("minButton"));
            for (int i = 1; i <= nklik; i++)
            {
                app.Tap(c => c.Id("minButton"));

            }
        }
        
        [When(@"Ik laat de route berekenen volgens ""(.*)""")]
        public void WhenIkLaatDeRouteBerekenenVolgens(string methode)
        {
            string methodenr = methode.Substring(methode.Length - 1);
            app.WaitForElement(c => c.Id("route1Button"));
            app.WaitForElement(c => c.Id("route2Button"));
            app.Tap(c => c.Id("route" + methodenr + "Button"));

        }
        
        [Then(@"toont het scherm (.*) knopen")]
        public void ThenToontHetSchermKnopen(int aantalverwacht)
        {
            var resultaantal = app.Query(c => c.Id("nknopen").Invoke("getText"));
            if (resultaantal[0].ToString() != null)
            {
                int aantalgetoond = Int32.Parse(resultaantal[0].ToString());
                Assert.AreEqual(aantalgetoond, aantalverwacht);
            }
        }
        
        [Then(@"toont het scherm de berekende route")]
        public void ThenToontHetSchermDeBerekendeRoute()
        {
            routelengte_eerder = routelengte_laatst;
            app.WaitForElement(c => c.Id("lengte"));
            var resultlengte1 = app.Query(c => c.Id("lengte").Invoke("getText"));
            if (resultlengte1[0].ToString() != null)
            {
                routelengte_laatst = Int32.Parse(resultlengte1[0].ToString());
            }
        }
        

        [Then(@"de lengte van de latere route is groter dan die van de eerdere route")]
        public void ThenDeLengteVanDeLatereRouteIsGroterDanDieVanDeEerdereRoute()
        {
            Assert.GreaterOrEqual(routelengte_laatst, routelengte_eerder);
        }

    }
}

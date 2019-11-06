using System;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;

namespace TSMUItests
{
    [TestFixture]
    public class UItests_verkenningen
    {

        AndroidApp app;

        [SetUp]
        public void BeforeEachTest()
        {
            app = ConfigureApp
                .Android
                .EnableLocalScreenshots()
                .ApkFile("C:/data/visualstudio_diverseprojecten/travellingsalesman/TSMApp/bin/Debug/TSMApp.TSMApp.apk")
                .StartApp();
        }

        [Test]
        public void SpecFlow_Start_Repl()
        {
            app.Repl();
        }


        [Test]
        public void SpecFlow_VerkenHoofdscherm()
        {
            int lengte1 = 0;
            int lengte2 = 0;
            app.WaitForElement(c => c.Id("action_bar"));
            app.Flash(c => c.Id("plusButton"));
            app.Tap(c => c.Id("plusButton"));
            app.Tap(c => c.Id("plusButton"));
            app.Tap(c => c.Id("plusButton"));
            app.Flash(c => c.Id("minButton"));
            app.Tap(c => c.Id("minButton"));
            app.Tap(c => c.Id("minButton"));
            app.Flash(c => c.Id("route1Button"));
            app.Tap(c => c.Id("route1Button"));
            var resultlengte1 = app.Query(c => c.Id("lengte").Invoke("getText"));
            if (resultlengte1[0].ToString() != null)
            {
                lengte1 = Int32.Parse(resultlengte1[0].ToString());
            }
            app.Flash(c => c.Id("route2Button"));
            app.Tap(c => c.Id("route2Button"));
            app.Flash(c => c.Id("lengte"));
            var resultlengte2 = app.Query(c => c.Id("lengte").Invoke("getText"));
            if (resultlengte2[0].ToString() != null)
            {
                lengte2 = Int32.Parse(resultlengte2[0].ToString());
            }

            //bij 11 punten is de lengte soms gelijk
            Assert.GreaterOrEqual(lengte2, lengte1);
        }
    }
}

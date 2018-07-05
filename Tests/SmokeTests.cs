using Microsoft.VisualStudio.TestTools.UnitTesting;
using WatchEpisodes.Entities;
using TestStack.BDDfy;

namespace Tests
{
    [TestClass]
    public class SmokeTests
    {
        private readonly Pages _pages = new Pages();

        [TestInitialize]
        public void TestInitialize()
        {
            Driver.Setup();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            Driver.Stop();
        }

        [TestMethod]
        public void TC_001_HomePageElementsAreVisible()
        {
            _pages.Given(step => step.HomePage.GoTo()).
                And(step => step.HomePage.Assert_VerifySignInButtonIsVisible()).
                And(step => step.HomePage.Assert_VerifyRegisterButtonIsVisible()).
                BDDfy();
        }

        [TestMethod]
        public void TC_002_TopNavigationBarElementsAreVisible()
        {
            _pages.Given(step => step.HomePage.GoTo()).
                And(step => step.TopNavigationBar.Assert_VerifyHomeButtonIsVisible()).
                And(step => step.TopNavigationBar.Assert_VerifyBrowseSeriesButtonIsVisible()).
                And(step => step.TopNavigationBar.Assert_VerifyNewSeriesButtonIsVisible()).
                And(step => step.TopNavigationBar.Assert_VerifyPopularSeriesButtonIsVisible()).
                And(step => step.TopNavigationBar.Assert_VerifyScheduleButtonIsVisible()).
                And(step => step.TopNavigationBar.Assert_VerifySearchButtonIsVisible()).
                BDDfy();
        }

        [TestMethod]
        public void TC_003_SearchIsFunctioningProperly()
        {
            var seriesName = "Zoo";

            _pages.Given(step => step.HomePage.GoTo()).
                And(step => step.TopNavigationBar.Action_Search(seriesName)).
                Then(step => step.SeriesPage.Assert_VerifyTitleIsCorrect(seriesName)).
                BDDfy();
        }
    }
}
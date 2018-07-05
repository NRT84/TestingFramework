using OpenQA.Selenium;
using TestStack.BDDfy;
using Shouldly;
using OpenQA.Selenium.Support.PageObjects;
using WatchEpisodes.Entities;
using WatchEpisodes.Extensions;

namespace WatchEpisodes.Pages
{
    public class TopNavigationBar
    {
        #region Actions
        [StepTitle("The user clicked on the search button and searched for '{0}'", false)]
        public void Action_Search(string series)
        {
            SearchButton.Click();
            SearchTextBox.SendKeys(series);
            var formattedSeries = FormatSeries(series);
            var link = Driver.Instance.FindElement(By.XPath("//a[contains(@href, '" + formattedSeries + "')]"));
            if (link == null)
            {
                throw new NotFoundException($"Series named '{series}' not found!");
            }
            link.OpenLink();
        }
        #endregion

        #region Assertions
        [StepTitle("Verified that home button is visible", false)]
        public void Assert_VerifyHomeButtonIsVisible()
        {
            HomeButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that browse series button is visible", false)]
        public void Assert_VerifyBrowseSeriesButtonIsVisible()
        {
            BrowseSeriesButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that new series button is visible", false)]
        public void Assert_VerifyNewSeriesButtonIsVisible()
        {
            NewSeriesButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that popular series button is visible", false)]
        public void Assert_VerifyPopularSeriesButtonIsVisible()
        {
            PopularSeriesButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that schedule button is visible", false)]
        public void Assert_VerifyScheduleButtonIsVisible()
        {
            ScheduleButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that search button is visible", false)]
        public void Assert_VerifySearchButtonIsVisible()
        {
            SearchButton.Displayed.ShouldBeTrue();
        }
        #endregion

        #region Web Elements
        [FindsBy(How = How.LinkText, Using = "Home")]
        private IWebElement HomeButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Browse Series")]
        private IWebElement BrowseSeriesButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "New Series")]
        private IWebElement NewSeriesButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Popular Series")]
        private IWebElement PopularSeriesButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Schedule")]
        private IWebElement ScheduleButton { get; set; }
        [FindsBy(How = How.ClassName, Using = "searchTrigger")]
        private IWebElement SearchButton { get; set; }
        [FindsBy(How = How.Id, Using = "autocomplete")]
        private IWebElement SearchTextBox { get; set; }
        #endregion

        private string FormatSeries(string series)
        {
            if (series.Contains(" "))
            {
                series = series.Replace(" ", "-");
            }
            return series.ToLower();
        }
    }
}
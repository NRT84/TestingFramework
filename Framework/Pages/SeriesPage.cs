using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestStack.BDDfy;
using Shouldly;

namespace WatchEpisodes.Pages
{
    public class SeriesPage
    {
        #region Assertions
        [StepTitle("Verify that the title '{0}' is correct", false)]
        public void Assert_VerifyTitleIsCorrect(string title)
        {
            Title.GetAttribute("title").ShouldBe(title);
        }
        #endregion

        #region Web Elements
        [FindsBy(How = How.ClassName, Using = "sc-bg")]
        private IWebElement Title { get; set; }
        #endregion
    }
}
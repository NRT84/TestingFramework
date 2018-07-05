using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Shouldly;
using TestStack.BDDfy;
using WatchEpisodes.Entities;

namespace WatchEpisodes.Pages
{
    public class HomePage
    {
        [StepTitle("The user visited the home page", false)]
        public void GoTo()
        {
            var Url = "http://www.watchepisodeseries.com";
            Driver.Instance.Navigate().GoToUrl(Url);
        }

        #region Assertions
        [StepTitle("Verified that sign in button is visible", false)]
        public void Assert_VerifySignInButtonIsVisible()
        {
            SignInButton.Displayed.ShouldBeTrue();
        }

        [StepTitle("Verified that register button is visible", false)]
        public void Assert_VerifyRegisterButtonIsVisible()
        {
            RegisterButton.Displayed.ShouldBeTrue();
        }
        #endregion

        #region Web Elements
        [FindsBy(How = How.ClassName, Using = "signInTrigger")]
        private IWebElement SignInButton { get; set; }
        [FindsBy(How = How.LinkText, Using = "Register")]
        private IWebElement RegisterButton { get; set; }
        #endregion
    }
}
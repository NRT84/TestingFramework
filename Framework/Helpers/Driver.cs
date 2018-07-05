using System;
using OpenQA.Selenium;

namespace WatchEpisodes.Entities
{
    public static class Driver
    {
        private static IWebDriver _driver;
        private static readonly string _driversPath = $@"{Environment.CurrentDirectory}\..\..\..\Framework\Drivers\";

        public static IWebDriver Instance
        {
            get
            {
                if (_driver == null)
                {
                    _driver = new OpenQA.Selenium.Chrome.ChromeDriver(_driversPath);
                }

                return _driver;
            }
        }

        public static void Setup()
        {
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            Instance.Manage().Cookies.DeleteAllCookies();
            Instance.Manage().Window.Maximize();
        }
        public static void Stop()
        {
            Instance.Quit();
        }
    }
}
using OpenQA.Selenium.Support.PageObjects;
using WatchEpisodes.Pages;

namespace WatchEpisodes.Entities
{
    public class Pages
    {
        private HomePage _homePage;
        private TopNavigationBar _topNavigationBar;
        private SeriesPage _seriesPage;

        public HomePage HomePage
        {
            get
            {
                if (_homePage == null)
                {
                    _homePage = new HomePage();
                    PageFactory.InitElements(Driver.Instance, _homePage);
                }
                return _homePage;
            }
        }

        public TopNavigationBar TopNavigationBar
        {
            get
            {
                if (_topNavigationBar == null)
                {
                    _topNavigationBar = new TopNavigationBar();
                    PageFactory.InitElements(Driver.Instance, _topNavigationBar);
                }
                return _topNavigationBar;
            }
        }

        public SeriesPage SeriesPage
        {
            get
            {
                if (_seriesPage == null)
                {
                    _seriesPage = new SeriesPage();
                    PageFactory.InitElements(Driver.Instance, _seriesPage);
                }
                return _seriesPage;
            }
        }
    }
}
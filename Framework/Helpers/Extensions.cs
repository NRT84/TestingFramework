using System;
using System.Net;
using OpenQA.Selenium;
using WatchEpisodes.Entities;

namespace WatchEpisodes.Extensions
{
    public static class Extensions
    {
        public static void OpenLink(this IWebElement element)
        {
            var href = element.GetAttribute("href");
            if (string.IsNullOrEmpty(href) || !href.IsLinkValid())
            {
                throw new NullReferenceException();
            }
            Driver.Instance.Navigate().GoToUrl(href);
        }

        public static bool IsLinkValid(this string url)
        {
            Uri result;
            var uriValid = Uri.TryCreate(url, UriKind.Absolute, out result);
            if (!uriValid)
            {
                return false;
            }
            var request = (HttpWebRequest)WebRequest.Create(result);
            request.Timeout = 5 * 1000;
            try
            {
                request.GetResponse();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
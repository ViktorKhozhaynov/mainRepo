using OpenQA.Selenium;
using System;

namespace SeleniumTest.Core
{
    public class CustomPageLoadTimeout : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        private static readonly Configuration config = Configuration.GetInstance();
        private static int defaultTimeout = int.Parse(config.GetValue("pageLoadTimeout"));

        public CustomPageLoadTimeout(IWebDriver webDriver, int timeout)
        {
            WebDriver = webDriver;
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(timeout);
        }

        public void Dispose()
        {
            WebDriver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(defaultTimeout);
        }
    }
}

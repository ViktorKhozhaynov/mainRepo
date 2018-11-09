using OpenQA.Selenium;
using System;

namespace SeleniumTest.Core
{
    public class CustomImplicitTimeout : IDisposable
    {
        private IWebDriver WebDriver { get; set; }
        private static readonly Configuration config = Configuration.GetInstance();
        private static int defaultTimeout = int.Parse(config.GetValue("implicitTimeout"));

        public CustomImplicitTimeout(IWebDriver webDriver, int timeout)
        {
            WebDriver = webDriver;
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(timeout);
        }

        public void Dispose()
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(defaultTimeout);
        }
    }
}

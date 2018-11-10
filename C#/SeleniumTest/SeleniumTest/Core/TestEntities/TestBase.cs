using log4net;
using log4net.Config;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumTest.PageObject;
using System;

namespace SeleniumTest.Core
{
    [TestFixture]
    public class TestBase : DriverBase
    {
        private static int explicitTimeout = int.Parse(config.GetValue("explicitTimeout"));
        
        protected void TestCase(string description, Action testBody)
        {
            TestCaseMethods.TestCase(description, testBody);
        }

        protected void TestStep(string description, Action testBody)
        {
            TestStepMethods.TestStep(description, testBody);
        }

        #region methods

        public void NavigateToUrl(string url) => WebDriver.Navigate().GoToUrl(url);

        public void waitUntil(Func<bool> condition) => new WebDriverWait(WebDriver, TimeSpan.FromSeconds(explicitTimeout)).Until((WebDriver) => condition.Invoke());
        
        public MainPage OpenMainPage()
        {
            using (new CustomPageLoadTimeout(WebDriver, 5))
                try
                {
                    log.Info("Main page has started loading. Waiting for 5 sec and proceed regardless of the result!");
                    NavigateToUrl(config.BaseUrl);
                } catch (WebDriverTimeoutException)
                {
                    log.Warn("Main page hasn't been loaded fully. Proceed with caution!");
                }

            var mainPage = new MainPage(WebDriver, null);

            waitUntil(() => mainPage.Header.Logo.IsDisplayed);

            return mainPage;
        }
        #endregion
    }
}

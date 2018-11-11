using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;
using System;

namespace SeleniumTest.Core
{
    public class HtmlSection
    {
        protected static Configuration config = Configuration.GetInstance();
        protected static int explicitTimeout = int.Parse(config.GetValue("explicitTimeout"));
        protected static int quickSearchTimeout = int.Parse(config.GetValue("quickSearchTimeout"));
        protected ILog log;
        private IWebDriver _webDriver;
        private IWebElement _webElement;
        private By by;

        private HtmlSection()
        {
            log = LogManager.GetLogger(this.GetType());
        }

        public HtmlSection(IWebDriver webDriver, By by) : this()
        {
            this._webDriver = webDriver;
            this.by = by;
        }

        public HtmlSection(IWebElement webElement, By by) : this()
        {
            this._webElement = webElement;
            this.by = by;
        }

        public HtmlSection(IWebElement webElement) : this()
        {
            this._webElement = webElement;
        }

        public IWebElement WebElement
        {
            get
            {
                return by != null && _webElement != null
                   ? _webElement.FindElement(by)
                   : by != null
                       ? _webDriver.FindElement(by)
                       : _webElement;
            }
        }

        public IWebDriver WebDriver => _webDriver != null ? _webDriver : ((IWrapsDriver)_webElement).WrappedDriver;

        protected string InternalId => by != null ? by.ToString() : "by.xpath //";

        public void Click()
        {
            try
            {
                WebElement.Click();
            }
            catch (Exception ex)
            {
                log.Error($"An error has occurred while clicking on the element! Message: {ex.Message}");
            }
        }

        public virtual string Text
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        return WebElement.Text;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Error has occurred during an attempt to get the text of the element! Message: {ex.Message}");
                    return "";
                }
            }
            set { }
        }

        public bool IsPresent
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        var testWebElement = WebElement;
                        return true;
                    }
                }
                catch (Exception)
                {
                    log.Warn($"IsPresent: The element hasn't been found by '{by.ToString()}' locator in the DOM!");
                    return false;
                }
            }
        }

        public bool IsAbsent
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        int numberOfElements = _webElement != null
                            ? _webElement.FindElements(by).Count
                            : _webDriver.FindElements(by).Count;

                        return numberOfElements == 0;
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"IsAbsent: Error has occurred during an attempt to get the element! Message: {ex.Message}");
                }
                return false;
            }
        }

        public bool IsDisplayed
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        return WebElement.Displayed;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    log.Error($"IsDisplayed: Error has occurred during an attempt to get the element! Message: {ex.Message}");
                }
                return false;
            }
        }

        public bool IsHidden
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        return !WebElement.Displayed;
                    }
                }
                catch (NoSuchElementException ex)
                {
                    log.Error($"IsHidden: Error has occurred during an attempt to get the element! Message: {ex.Message}");
                }
                return false;
            }
        }

        public void waitUntil(Func<IWebDriver, bool> condition) => new WebDriverWait(WebDriver, TimeSpan.FromSeconds(explicitTimeout)).Until((WebDriver) => condition.Invoke(WebDriver));
    }
}

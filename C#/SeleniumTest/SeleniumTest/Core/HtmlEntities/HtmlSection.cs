using log4net;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using System;

namespace SeleniumTest.Core
{
    public class HtmlSection
    {
        protected readonly int QUICK_SEARCH_TIMEOUT = 2;
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

        protected String InternalId => by != null ? by.ToString() : "by.xpath //";

        public String Text
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
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
        }

        public Boolean IsPresent
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
                    {
                        var testWebElement = WebElement;
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    log.Warn($"IsPresent: The element hasn't been found by '{by.ToString()}' locator in the DOM!");
                    return false;
                }
            }
        }

        public Boolean IsAbsent
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
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

        public Boolean IsDisplayed
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
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

        public Boolean IsHidden
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, QUICK_SEARCH_TIMEOUT))
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
    }
}

using System;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlElement : HtmlSection
    {
        public HtmlElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public HtmlElement(IWebElement webElement) : base(webElement)
        {
        }

        public String ExpectedText;

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
    }
}

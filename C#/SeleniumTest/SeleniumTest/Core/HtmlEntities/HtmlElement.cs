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

        public string ExpectedText;
    }
}

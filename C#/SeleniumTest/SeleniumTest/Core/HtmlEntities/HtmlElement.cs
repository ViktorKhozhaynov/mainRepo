using System;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlElement : HtmlSection
    {
        public HtmlElement(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public HtmlElement(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public HtmlElement(IWebElement webElement, HtmlSection parent) : base(webElement, parent)
        {
        }

        public string ExpectedText;
    }
}

using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlLinkElement : HtmlElement
    {
        public HtmlLinkElement(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public HtmlLinkElement(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
    }
}

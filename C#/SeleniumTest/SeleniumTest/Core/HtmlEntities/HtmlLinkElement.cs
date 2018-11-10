using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlLinkElement : HtmlElement
    {
        public HtmlLinkElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlLinkElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}

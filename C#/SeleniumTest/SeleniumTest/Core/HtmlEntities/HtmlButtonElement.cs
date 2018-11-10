using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlButtonElement : HtmlElement
    {
        public HtmlButtonElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlButtonElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}

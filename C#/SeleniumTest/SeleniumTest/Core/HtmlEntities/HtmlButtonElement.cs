using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlButtonElement : HtmlElement
    {
        public HtmlButtonElement(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public HtmlButtonElement(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
    }
}

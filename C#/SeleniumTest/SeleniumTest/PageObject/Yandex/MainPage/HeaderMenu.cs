using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class HeaderMenu : HtmlSection
    {
        public HeaderMenu(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public HeaderMenu(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public HtmlElement Logo => new HtmlElement(WebElement, By.ClassName("header2__ya-logo"), this);
    }
}

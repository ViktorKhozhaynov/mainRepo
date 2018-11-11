using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class HeaderMenu : HtmlSection
    {
        public HeaderMenu(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HeaderMenu(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public HtmlElement Logo => new HtmlElement(WebElement, By.ClassName("header2__ya-logo"));
    }
}

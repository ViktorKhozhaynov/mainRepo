using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class OrderSection : HtmlSection
    {
        public OrderSection(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public OrderSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }
    }
}

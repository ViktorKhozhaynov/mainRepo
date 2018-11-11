using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest.Core
{
    public class HtmlHoverableElement : HtmlElement
    {
        public HtmlHoverableElement(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public HtmlHoverableElement(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public void HoverOver()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(WebElement).Perform();
        }
    }
}

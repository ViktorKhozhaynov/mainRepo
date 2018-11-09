using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace SeleniumTest.Core.HtmlEntities
{
    public class HtmlHoverableElement : HtmlElement
    {
        public HtmlHoverableElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlHoverableElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public void HoverOver()
        {
            Actions action = new Actions(WebDriver);
            action.MoveToElement(WebElement).Perform();
        }
    }
}

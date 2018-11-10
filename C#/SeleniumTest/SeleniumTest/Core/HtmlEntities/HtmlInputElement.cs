using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class HtmlInputElement : HtmlElement
    {
        public HtmlInputElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlInputElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public void SetText(string text) => WebElement.SendKeys(text);
    }
}

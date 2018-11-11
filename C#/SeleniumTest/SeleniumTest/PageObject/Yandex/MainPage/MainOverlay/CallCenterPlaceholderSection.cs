using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class CallCenterPlaceholderSection : HtmlSection
    {
        public CallCenterPlaceholderSection(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public CallCenterPlaceholderSection(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public HtmlElement PhoneTextElement => new HtmlElement(WebElement, By.ClassName("callcenter-phone__text"));

        public HtmlElement PhoneElement => new HtmlElement(WebElement, By.ClassName("locale__phone"));

        public string PhoneNumber => PhoneElement.Text;

        public string FullText => PhoneTextElement.Text;
    }
}

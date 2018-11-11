using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class CallCenterPlaceholderSection : HtmlSection
    {
        public CallCenterPlaceholderSection(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public CallCenterPlaceholderSection(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public HtmlElement PhoneTextElement => new HtmlElement(WebElement, By.ClassName("callcenter-phone__text"), this);

        public HtmlElement PhoneElement => new HtmlElement(WebElement, By.ClassName("locale__phone"), this);

        public string PhoneNumber => PhoneElement.Text;

        public string FullText => PhoneTextElement.Text;
    }
}

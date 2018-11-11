using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class AutocompleteOption : HtmlSection
    {
        public AutocompleteOption(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public AutocompleteOption(IWebElement webElement, By by) : base(webElement, by)
        {
        }
        
        public string ShortText => new HtmlElement(WebElement, By.ClassName("b-autocomplete-item__short-text")).Text;

        public string FullText => new HtmlElement(WebElement, By.ClassName("b-autocomplete-item__text")).Text;
    }
}

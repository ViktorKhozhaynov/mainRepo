using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class AutocompleteOption : HtmlSection
    {
        public AutocompleteOption(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public AutocompleteOption(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
        
        public string ShortText => new HtmlElement(WebElement, By.ClassName("b-autocomplete-item__short-text"), this).Text;

        public string FullText => new HtmlElement(WebElement, By.ClassName("b-autocomplete-item__text"), this).Text;
    }
}

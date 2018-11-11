using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class OrderSection : HtmlSection
    {
        public OrderSection(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public OrderSection(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public AddressInputBlock FromInputBlock => new AddressInputBlock(WebElement, By.CssSelector("span.input_direction_from"), this);

        public AddressInputBlock ToInputBlock => new AddressInputBlock(WebElement, By.CssSelector("span.input_direction_to"), this);

        public HtmlButtonElement SwapButton => new HtmlButtonElement(WebElement, By.ClassName("geo-group__swap"), this);

        // Temporary solution, had to use last-of-type due to inability to distinguish two almost identical error containers in the DOM
        public HtmlElement AddressValidationMessage => new HtmlElement(WebDriver, By.CssSelector("div.popup_type_error:last-of-type div.popup__content"), this);

        // Temporary solution, had to use last-of-type due to inability to distinguish two almost identical error containers in the DOM
        public AutocompleteOption AutocompleteOption(int index) => new AutocompleteOption(WebDriver, By.CssSelector($".input__popup:last-of-type li.b-autocomplete-item:nth-of-type({++index})"), this);

        public HtmlButtonElement DateTimeSelectButton => new HtmlButtonElement(WebDriver, By.Id("datetimeSelect"), this);

        public HtmlElement DateTimeOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".popup_type_datetime li:nth-of-type({++index}) div.select__item span"), this);

        public HtmlButtonElement RequirementsSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_preset_requirements"), this);

        public HtmlElement RequirementsOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".popup_type_requirements div.requirements__item:nth-of-type({++index}) span.checkbox"), this);

        public HtmlElement RequirementsOption(string text) => new HtmlElement(WebDriver, By.XPath($"//*[contains(@class, 'popup_type_requirements')]//div[contains(@class, 'requirements__item')]//label[contains(@class, 'checkbox__label') and contains(text(), '{text}')]"), this);

        public HtmlInputElement PhoneNumberInput => new HtmlInputElement(WebDriver, By.Id("phoneNumber"), this);

        public HtmlButtonElement RatesInfoButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-mrt__button"), this);

        public HtmlButtonElement CommentsButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-comments__button"), this);

        public HtmlInputElement CommentsInputArea => new HtmlInputElement(WebElement, By.CssSelector("span.input_type_textarea textarea"), this);

        public HtmlButtonElement RatesSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_size_service-level"), this);

        public HtmlElement RatesOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".select__popup_size_service-level div.select__item:nth-of-type({++index})"), this);

        public HtmlElement PreliminaryCostSurge => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__surge"), this);

        public HtmlElement PreliminaryCostLoader => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__loader"), this);

        public HtmlElement PreliminaryCostHint => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__hint"), this);

        public HtmlElement PreliminaryCost => new HtmlElement(WebElement, By.CssSelector("div.routestats .routestats__price"), this);

        public HtmlButtonElement DemoButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_action_demo"), this);

        public HtmlButtonElement OrderButton => new HtmlButtonElement(WebElement, By.CssSelector("button.js-order-button"), this);
               
        #region methods

        public int GetRateOptionCost(string rawText)
        {
            var from = rawText.LastIndexOf("от") + 3;
            var to = rawText.LastIndexOf("Р");

            return int.Parse(rawText.Substring(from, to - from));
        }

        public void ClickRatesButton()
        {
            waitUntil(x => RatesSelectButton.IsDisplayed);
            RatesSelectButton.Click();
            waitUntil(x => RatesOption(0).IsDisplayed);
        }

        public void SelectRate(int index)
        {
            waitUntil(x => RatesOption(index).IsDisplayed);
            RatesOption(index).Click();

            waitUntil(x => RatesOption(index).IsHidden);
            waitUntil(x => PreliminaryCost.IsDisplayed);
        }

        public void OpenRequirementsDropdown()
        {
            RequirementsSelectButton.Click();
            waitUntil(x => RequirementsOption(0).IsDisplayed);
        }
        #endregion
    }
}

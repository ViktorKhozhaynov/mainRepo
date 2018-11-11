using OpenQA.Selenium;
using SeleniumTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public AddressInputBlock FromInputBlock => new AddressInputBlock(WebElement, By.CssSelector("span.input_direction_from"));

        public AddressInputBlock ToInputBlock => new AddressInputBlock(WebElement, By.CssSelector("span.input_direction_to"));

        public HtmlButtonElement SwapButton => new HtmlButtonElement(WebElement, By.ClassName("geo-group__swap"));

        // Temporary solution, had to use last-of-type due to inability to distinguish two almost identical error containers in the DOM
        public HtmlElement AddressValidationMessage => new HtmlElement(WebDriver, By.CssSelector("div.popup_type_error:last-of-type div.popup__content"));

        public HtmlElement AutocompleteOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".input__popup.popup li span.b-autocomplete-item__short-text:nth-of-type({++index})"));

        public HtmlButtonElement DateTimeSelectButton => new HtmlButtonElement(WebDriver, By.Id("datetimeSelect"));

        public HtmlElement DateTimeOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".popup_type_datetime li div.select__item span:nth-of-type({++index})"));

        public HtmlButtonElement RequirementsSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_preset_requirements"));

        public HtmlElement RequirementsOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".popup_type_requirements div.requirements__item span.checkbox:nth-of-type({++index})"));

        public HtmlInputElement PhoneNumberInput => new HtmlInputElement(WebDriver, By.Id("phoneNumber"));

        public HtmlButtonElement RatesInfoButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-mrt__button"));

        public HtmlButtonElement CommentsButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-comments__button"));

        public HtmlInputElement CommentsInputArea => new HtmlInputElement(WebElement, By.CssSelector("span.input_type_textarea textarea"));

        public HtmlButtonElement RatesSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_size_service-level"));

        public HtmlElement RatesOption(int index) => new HtmlElement(WebDriver, By.CssSelector($".select__popup_size_service-level div.select__item:nth-of-type({++index})"));

        public HtmlElement PreliminaryCostSurge => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__surge"));

        public HtmlElement PreliminaryCostLoader => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__loader"));

        public HtmlElement PreliminaryCostHint => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__hint"));

        public HtmlElement PreliminaryCost => new HtmlElement(WebElement, By.CssSelector("div.routestats .routestats__price"));

        public HtmlButtonElement DemoButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_action_demo"));

        public HtmlButtonElement OrderButton => new HtmlButtonElement(WebElement, By.CssSelector("button.js-order-button"));
               
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
        #endregion
    }
}

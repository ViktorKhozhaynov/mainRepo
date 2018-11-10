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

        public HtmlElementsList AutocompleteShortNames => new HtmlElementsList(WebDriver, By.CssSelector(".input__popup.popup li span.b-autocomplete-item__short-text"));

        public HtmlButtonElement DateTimeSelectButton => new HtmlButtonElement(WebDriver, By.Id("datetimeSelect"));

        public HtmlElementsList DateTimeOptions => new HtmlElementsList(WebDriver, By.CssSelector(".popup_type_datetime li div.select__item span"));

        public HtmlButtonElement RequirementsSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_preset_requirements"));

        public HtmlElementsList RequirementsOptions => new HtmlElementsList(WebDriver, By.CssSelector(".popup_type_requirements div.requirements__item span.checkbox"));

        public HtmlInputElement PhoneNumberInput => new HtmlInputElement(WebDriver, By.Id("phoneNumber"));

        public HtmlButtonElement RatesInfoButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-mrt__button"));

        public HtmlButtonElement CommentsButton => new HtmlButtonElement(WebElement, By.CssSelector("label.api-comments__button"));

        public HtmlInputElement CommentsInputArea => new HtmlInputElement(WebElement, By.CssSelector("span.input_type_textarea textarea"));

        public HtmlButtonElement RatesSelectButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_size_service-level"));

        public HtmlElementsList RatesOptions => new HtmlElementsList(WebDriver, By.CssSelector(".select__popup_size_service-level div.select__item"));

        public HtmlElement RatesLoader => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__loader"));

        public HtmlElement RatesSurge => new HtmlElement(WebElement, By.CssSelector("div.routestats div.routestats__surge"));

        public HtmlElement PreliminaryCost => new HtmlElement(WebElement, By.CssSelector("div.routestats .routestats__price"));

        public HtmlButtonElement DemoButton => new HtmlButtonElement(WebElement, By.CssSelector("button.button_action_demo"));

        public HtmlButtonElement OrderButton => new HtmlButtonElement(WebElement, By.CssSelector("button.js-order-button"));
               
        #region methods

        public void SelectSample(int index)
        {
            var firstSample = FromInputBlock.InputSamples.Elements[index];

            waitUntil(() => firstSample.IsDisplayed);
            firstSample.Click();

            waitUntil(() => FromInputBlock.Input.Text.Equals(firstSample.Text));
        }

        public int GetRateOptionCost(int index)
        {
            waitUntil(() => RatesOptions.Elements.All(x => x.IsDisplayed));
            
            var rawText = RatesOptions.ElementsText[index];
            var from = rawText.LastIndexOf("от") + 3;
            var to = rawText.LastIndexOf("Р");

            return int.Parse(rawText.Substring(from, to - from));
        }

        public void ClickRatesButton()
        {
            waitUntil(() => RatesSelectButton.IsDisplayed);
            RatesSelectButton.Click();
            waitUntil(() => RatesOptions.Elements.All(x => x.IsDisplayed));
        }

        public void SelectRate(int index)
        {
            waitUntil(() => RatesOptions.Elements.All(x => x.IsDisplayed));
            RatesOptions.CLickElementByIndex(index);

            waitUntil(() => RatesOptions.Elements.All(x => x.IsHidden));
        }
        #endregion
    }
}

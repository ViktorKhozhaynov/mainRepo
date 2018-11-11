using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class AddressInputBlock : HtmlSection
    {
        public AddressInputBlock(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public AddressInputBlock(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public HtmlInputElement Input => new HtmlInputElement(WebElement, By.CssSelector("input.input__control"), this);

        public HtmlElement Spinner => new HtmlElement(WebElement, By.CssSelector("div.spinner"), this);

        public HtmlButtonElement ClearButton => new HtmlButtonElement(WebElement, By.CssSelector("span.input__clear"), this);

        public HtmlButtonElement LocationButton => new HtmlButtonElement(WebElement, By.CssSelector("input.input__location"), this);

        public HtmlElement InputHint => new HtmlElement(WebElement, By.CssSelector("label.input__hint"), this);

        public HtmlElementsList InputSamples => new HtmlElementsList(WebElement, By.CssSelector("span.input__samples span"), this);

        #region methods
        

        // Takes SampleType, selects sample and returns its text
        public string SelectSample(SampleType type)
        {
            var sample = InputSamples.Elements[type.Equals(SampleType.Left) ? 0 : 1];
            var sampleText = sample.Text;

            waitUntil(x => sample.IsDisplayed);
            sample.Click();

            waitUntil(x => ClearButton.IsDisplayed);
            waitUntil(x => Input.Text.Equals(sampleText));

            return sampleText;
        }

        public void ClearInput()
        {
            waitUntil(x => ClearButton.IsDisplayed);

            ClearButton.Click();
            waitUntil(x => Input.Text.Equals(string.Empty));
        }

        public void OpenAddressAutocompleteList(string requestedPartialAddress)
        {
            Input.Text = requestedPartialAddress;
            waitUntil(x => ((OrderSection)Parent).AutocompleteOption(0).IsDisplayed);
        }
        #endregion
    }
    
    public enum SampleType
    {
        Left,
        Right
    }
}

using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class AddressInputBlock : HtmlSection
    {
        public AddressInputBlock(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public AddressInputBlock(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public HtmlInputElement Input => new HtmlInputElement(WebElement, By.CssSelector("input.input__control"));

        public HtmlElement Spinner => new HtmlElement(WebElement, By.CssSelector("div.spinner"));

        public HtmlButtonElement ClearButton => new HtmlButtonElement(WebElement, By.CssSelector("span.input__clear"));

        public HtmlButtonElement LocationButton => new HtmlButtonElement(WebElement, By.CssSelector("input.input__location"));

        public HtmlElement InputHint => new HtmlElement(WebElement, By.CssSelector("label.input__hint"));

        public HtmlElementsList InputSamples => new HtmlElementsList(WebElement, By.CssSelector("span.input__samples span"));

        #region methods
        

        // Takes SampleType, selects sample and returns its text
        public string SelectSample(SampleType type)
        {
            var sample = InputSamples.Elements[type.Equals(SampleType.Left) ? 0 : 1];
            var sampleText = sample.Text;

            waitUntil(x => sample.IsDisplayed);
            sample.Click();

            return sampleText;
        }

        public void ClearInput()
        {
            waitUntil(x => ClearButton.IsDisplayed);

            ClearButton.Click();
            waitUntil(x => Input.Text.Equals(string.Empty));
        }
        #endregion
    }
    
    public enum SampleType
    {
        Left,
        Right
    }
}

using OpenQA.Selenium;
using SeleniumTest.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public HtmlInputElement FromInput => new HtmlInputElement(WebElement, By.CssSelector("input.input__control"));

        public HtmlButtonElement ClearButton => new HtmlButtonElement(WebElement, By.CssSelector("input.input__clear"));

        public HtmlButtonElement LocationButton => new HtmlButtonElement(WebElement, By.CssSelector("input.input__location"));

        public HtmlElement InputHint => new HtmlElement(WebElement, By.CssSelector("label.input__hint"));

        public HtmlElementsList InputSamples => new HtmlElementsList(WebElement, By.CssSelector("span.input__samples span"));
    }
}

using OpenQA.Selenium;
using System;

namespace SeleniumTest.Core
{
    public class HtmlInputElement : HtmlElement
    {
        public HtmlInputElement(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public HtmlInputElement(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public override string Text
        {
            get
            {
                try
                {
                    using (new CustomImplicitTimeout(WebDriver, quickSearchTimeout))
                    {
                        return WebElement.GetAttribute("value");
                    }
                }
                catch (Exception ex)
                {
                    log.Error($"Error has occurred during an attempt to get the text of the element! Message: {ex.Message}");
                    return "";
                }
            }
            set
            {
                try
                {
                    WebElement.Clear();
                    WebElement.SendKeys(string.Empty);
                    WebElement.SendKeys(value);
                }
                catch (Exception ex)
                {
                    log.Error($"Error has occurred during an attempt to set the text of the input element! Message: {ex.Message}");
                }
            }
        }

        public void SetText(string text) => Text = text;
    }
}

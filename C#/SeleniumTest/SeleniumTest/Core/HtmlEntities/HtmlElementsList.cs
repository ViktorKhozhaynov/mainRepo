using log4net;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTest.Core
{
    public class HtmlElementsList
    {
        public List<HtmlElement> Elements { get; set; }
        protected ILog log;

        public HtmlElementsList()
        {
            log = LogManager.GetLogger(this.GetType());
        }

        public HtmlElementsList(IWebDriver webDriver, By by) : this()
        {
            Elements = webDriver.FindElements(by).Select(x => new HtmlElement(x)).ToList();
        }

        public HtmlElementsList(IWebElement webElement, By by) : this()
        {
            Elements = webElement.FindElements(by).Select(x => new HtmlElement(x)).ToList();
        }

        public List<string> ElementsText => Elements.Select(x => x.Text).ToList();

        #region methods

        public void CLickElementByIndex(int index) => Elements[index].Click();

        public void ClickElementByText(int text) => Elements.Find(x => x.Text.Equals(text)).Click();
        #endregion
    }
}

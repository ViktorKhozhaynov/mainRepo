using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class OverlayBase : HtmlSection
    {
        public OverlayBase(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public OverlayBase(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }
    }
}

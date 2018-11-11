using log4net;
using OpenQA.Selenium;

namespace SeleniumTest.Core
{
    public class PageBase
    {
        private ILog log;
        protected IWebDriver webDriver;
        public PageBase parent;

        protected PageBase() { }

        public PageBase(IWebDriver webDriver, PageBase parent)
        {
            this.webDriver = webDriver;
            this.parent = parent;

            log = LogManager.GetLogger(this.GetType());
        }
    }
}

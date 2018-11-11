using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class MainOverlay : OverlayBase
    {
        public MainOverlay(IWebDriver webDriver, By by, HtmlSection parent) : base(webDriver, by, parent)
        {
        }

        public MainOverlay(IWebElement webElement, By by, HtmlSection parent) : base(webElement, by, parent)
        {
        }

        public OrderSection OrderSection => new OrderSection(WebElement, By.ClassName("order"), this);

        public CallCenterPlaceholderSection CallCenterPlaceholderSection => new CallCenterPlaceholderSection(WebElement, By.CssSelector(".js-callcenter-placeholder .callcenter-phone"), this);

        public CityPromoSection CityPromoSection => new CityPromoSection(WebElement, By.ClassName("island_type_city-promo"), this);
    }
}

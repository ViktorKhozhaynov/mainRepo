using OpenQA.Selenium;
using SeleniumTest.Core;

namespace SeleniumTest.PageObject
{
    public class MainOverlay : OverlayBase
    {
        public MainOverlay(IWebDriver webDriver, By by) : base(webDriver, by)
        {
        }

        public MainOverlay(IWebElement webElement, By by) : base(webElement, by)
        {
        }

        public OrderSection OrderSection => new OrderSection(WebElement, By.ClassName("order"));

        public CallCenterPlaceholderSection CallCenterPlaceholderSection => new CallCenterPlaceholderSection(WebElement, By.CssSelector(".js-callcenter-placeholder .callcenter-phone"));

        public CityPromoSection CityPromoSection => new CityPromoSection(WebElement, By.ClassName("island_type_city-promo"));
    }
}

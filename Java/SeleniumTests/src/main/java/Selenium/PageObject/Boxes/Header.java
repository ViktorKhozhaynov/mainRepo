package Selenium.PageObject.Boxes;

import Selenium.Common.HtmlEntities.HtmlImageElement;
import Selenium.Common.HtmlEntities.HtmlSection;
import Selenium.PageObject.Rows.Header.NavigationRow;
import Selenium.PageObject.Rows.Header.TopMenuRow;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class Header extends HtmlSection {
    public Header(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public TopMenuRow TopMenuRow = new TopMenuRow(WebDriver(), By.id("block_top_menu"));

    public HtmlImageElement BannerImage = new HtmlImageElement(WebElement(), By.cssSelector("div.banner img"));

    public NavigationRow NavigationRow = new NavigationRow(WebElement(), By.cssSelector("div.nav"));
}

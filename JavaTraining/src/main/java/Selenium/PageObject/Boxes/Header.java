package Selenium.PageObject.Boxes;

import Selenium.Common.ElementEntities.HtmlSection;
import Selenium.PageObject.Rows.TopMenuRow;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class Header extends HtmlSection {
    public Header(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public TopMenuRow TopMenuRow = new TopMenuRow(WebDriver(), By.id("block_top_menu"));
}

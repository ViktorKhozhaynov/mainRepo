package Selenium.PageObject.Rows;

import Selenium.Common.ElementEntities.HtmlElement;
import Selenium.Common.ElementEntities.HtmlSection;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class TopMenuRow extends HtmlSection {
    public TopMenuRow(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlElement WomenHoverable = new HtmlElement(() -> WebElement(), By.xpath(".//a[contains(text(), 'Women')]"));
}

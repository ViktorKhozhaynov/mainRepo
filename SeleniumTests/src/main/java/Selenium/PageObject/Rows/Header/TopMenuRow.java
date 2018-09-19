package Selenium.PageObject.Rows.Header;

import Selenium.Common.HtmlEntities.HtmlElement;
import Selenium.Common.HtmlEntities.HtmlSection;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class TopMenuRow extends HtmlSection {
    public TopMenuRow(WebDriver webDriver, By by) {
        super(webDriver, by);
    }

    public HtmlElement WomenLink = new HtmlElement(WebElement(), By.xpath(".//a[contains(text(), 'Women')]")) {{ ExpectedText = "WOMEN"; }};
}

package Selenium.Common.ElementEntities;

import Selenium.Common.PageEntities.HtmlSection;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class HtmlElement extends HtmlSection {
    public HtmlElement(WebDriver webDriver, By by) {
        super(webDriver, by);
    }
}

package Selenium.PageObject;

import Selenium.Common.PageEntities.MainPage;
import Selenium.PageObject.Boxes.Header;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;

public class MainPortal extends MainPage {
    public MainPortal(WebDriver webDriver) {
        super(webDriver);
    }

    public Header Header = new Header(this.webDriver, By.id("header"));
}

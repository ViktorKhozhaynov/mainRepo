package Selenium.Common.PageEntities;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.openqa.selenium.WebDriver;

public class PageBase {
    private Logger log = LogManager.getFormatterLogger(this.getClass().getName());
    protected WebDriver webDriver;
    public PageBase parent;

    protected PageBase() {}

    public PageBase(WebDriver webDriver, PageBase parent) {
        this.webDriver = webDriver;
        this.parent = parent;
    }
}

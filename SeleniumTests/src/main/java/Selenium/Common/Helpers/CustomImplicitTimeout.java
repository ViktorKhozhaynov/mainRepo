package Selenium.Common.Helpers;

import Selenium.Common.Configs.Configuration;
import org.openqa.selenium.WebDriver;

import java.util.concurrent.TimeUnit;

public class CustomImplicitTimeout implements AutoCloseable {
    private WebDriver webDriver;
    private final Configuration config = Configuration.getInstance();
    private final Integer defaultTimeout = Integer.parseInt(config.getValue("implicitTimeout"));

    public CustomImplicitTimeout(WebDriver webDriver, Integer timeout) {
        this.webDriver = webDriver;
        webDriver.manage().timeouts().implicitlyWait(timeout, TimeUnit.SECONDS);
    }

    @Override
    public void close() {
        webDriver.manage().timeouts().implicitlyWait(defaultTimeout, TimeUnit.SECONDS);
    }
}

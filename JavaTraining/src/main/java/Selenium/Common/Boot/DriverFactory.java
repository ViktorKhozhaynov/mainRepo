package Selenium.Common.Boot;
import Selenium.Common.Configs.Configuration;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;

import static Selenium.Common.Boot.DriverType.CHROME;

public class DriverFactory {
    private RemoteWebDriver driver;
    private DriverType selectedDriverType;
    private Configuration config = Configuration.getInstance();

    public DriverFactory() {
        DriverType driverType = CHROME;
        String driver = config.getValue("driver").toUpperCase();
        try {
            driverType = DriverType.valueOf(driver);
        } catch (IllegalArgumentException ignored) {
            System.err.println("Unknown driver specified, defaulting to '" + driverType + "'...");
        } catch (NullPointerException ignored) {
            System.err.println("No driver specified, defaulting to '" + driverType + "'...");
        }
        selectedDriverType = driverType;
    }

    public RemoteWebDriver getDriver() {
        if (null == driver) {
            instantiateWebDriver(selectedDriverType);
        }

        return driver;
    }

    public RemoteWebDriver getStoredDriver() {
        return driver;
    }

    public void quitDriver() {
        if (null != driver) {
            driver.quit();
            driver = null;
        }
    }

    private void instantiateWebDriver(DriverType driverType) {
        DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
        driver = driverType.getWebDriverObject(desiredCapabilities);
    }
}
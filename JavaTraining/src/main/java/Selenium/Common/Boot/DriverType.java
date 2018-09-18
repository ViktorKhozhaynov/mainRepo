package Selenium.Common.Boot;

import Selenium.Common.Configs.Configuration;
import Selenium.Common.Configs.LocalRegistry;
import org.openqa.selenium.chrome.ChromeDriver;
import org.openqa.selenium.chrome.ChromeOptions;
import org.openqa.selenium.firefox.FirefoxDriver;
import org.openqa.selenium.firefox.FirefoxOptions;
import org.openqa.selenium.remote.DesiredCapabilities;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.util.HashMap;

public enum DriverType implements DriverSetup {
    FIREFOX {
        public RemoteWebDriver getWebDriverObject(DesiredCapabilities capabilities) {
            System.setProperty("webdriver.gecko.driver", driversPath + "geckodriver.exe");

            FirefoxOptions options = new FirefoxOptions();
            options.merge(capabilities);
            options.setHeadless(HEADLESS);

            return new FirefoxDriver(options);
        }
    },
    CHROME {
        public RemoteWebDriver getWebDriverObject(DesiredCapabilities capabilities) {
            System.setProperty("webdriver.chrome.driver", driversPath + "chromedriver.exe");

            HashMap<String, Object> chromePreferences = new HashMap<>();
            chromePreferences.put("profile.password_manager_enabled", false);

            ChromeOptions options = new ChromeOptions();
            options.merge(capabilities);
            options.setHeadless(HEADLESS);
            options.addArguments("--no-default-browser-check");
            options.setExperimentalOption("prefs", chromePreferences);

            return new ChromeDriver(options);
        }
    };

    public final static boolean HEADLESS = Boolean.valueOf(Configuration.getInstance().getValue("headless"));
    public final static String driversPath = LocalRegistry.getInstance().getValue("driversPath");

    @Override
    public String toString() {
        return super.toString().toLowerCase();
    }
}

interface DriverSetup {
    RemoteWebDriver getWebDriverObject(DesiredCapabilities capabilities);
}
package Selenium.Common.TestEntities;

import Selenium.Common.Boot.DriverFactory;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.openqa.selenium.remote.RemoteWebDriver;

import java.util.*;

public class DriverBase {
    private static List<DriverFactory> webDriverThreadPool = Collections.synchronizedList(new ArrayList<DriverFactory>());
    private static ThreadLocal<DriverFactory> driverFactoryThread;
    protected final Logger log = LogManager.getFormatterLogger(this.getClass().getName());

    @BeforeClass
    public static void createDriverViaFactory() {
        System.out.println("Starting the driver...");
        driverFactoryThread = ThreadLocal.withInitial(() -> {
            DriverFactory driverFactory = new DriverFactory();
            webDriverThreadPool.add(driverFactory);
            return driverFactory;
        });
    }

    @AfterClass
    public static void clearAllCookies() {
        try {
            driverFactoryThread.get().getStoredDriver().manage().deleteAllCookies();
        } catch (Exception ignored) {
            System.out.println("Unable to clear cookies, driver object is not viable...");
        }
    }

    @AfterClass
    public static void quitDriver() {
        for (DriverFactory driverFactory : webDriverThreadPool) {
            driverFactory.quitDriver();
        }
    }

    public static RemoteWebDriver webDriver() {
        return driverFactoryThread.get().getDriver();
    }
}
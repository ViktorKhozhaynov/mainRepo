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
    protected List<Runnable> preInstructions = new LinkedList<>();
    protected List<Runnable> postInstructions = new LinkedList<>();
    protected final Logger log = LogManager.getFormatterLogger(this.getClass().getName());

    protected DriverBase() {
        preInstructions.add(() -> {
            System.out.println("Starting the driver...");
            driverFactoryThread = ThreadLocal.withInitial(() -> {
                DriverFactory driverFactory = new DriverFactory();
                webDriverThreadPool.add(driverFactory);
                return driverFactory;
            });
        });
        postInstructions.add(() -> {
            try {
                driverFactoryThread.get().getStoredDriver().manage().deleteAllCookies();
            } catch (Exception ignored) {
                System.out.println("Unable to clear cookies, driver object is not viable...");
            }
        });
        postInstructions.add(() -> {
            for (DriverFactory driverFactory : webDriverThreadPool) {
                driverFactory.quitDriver();
            }
        });
    }

    @BeforeClass
    public static void runBeforeClassInstructions() {
    }

    @AfterClass
    public static void runAfterClassInstructions() {
    }

    @Before
    public void runBeforeInstructions() {
        preInstructions.forEach(Runnable::run);
    }

    @After
    public void runAfterInstructions() {
        postInstructions.forEach(Runnable::run);
    }

    public static RemoteWebDriver getDriver() {
        return driverFactoryThread.get().getDriver();
    }
}
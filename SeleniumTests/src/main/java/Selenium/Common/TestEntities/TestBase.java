package Selenium.Common.TestEntities;

import Selenium.Common.Configs.Configuration;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.function.Predicate;

public class TestBase extends DriverBase {
    protected static final Configuration config = Configuration.getInstance();
    private static final String basePortalUrl = config.getValue("basePortalUrl");

    private static void Initialize() {
        NavigateToBaseUrl();
    }

    public static void TestCase(String description, TestCodeBlock testBody) throws Exception {
        Initialize();

        TestCase.TestCase(description, testBody);
    }

    public static void TestStep(String description, TestCodeBlock testStepBody) throws Exception  {
        TestStep.TestStep(description, testStepBody);
    }

    public static void waitUntil(Predicate condition) {
        new WebDriverWait(webDriver(), Integer.parseInt(config.getValue("explicitTimeout"))).until(x -> condition);
    }

    public static void NavigateToBaseUrl() {
        webDriver().navigate().to(basePortalUrl);
    }
}

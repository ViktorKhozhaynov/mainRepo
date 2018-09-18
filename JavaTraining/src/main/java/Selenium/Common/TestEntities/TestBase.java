package Selenium.Common.TestEntities;

import Selenium.Common.Configs.Configuration;
import Selenium.Common.Configs.LocalRegistry;
import org.openqa.selenium.support.ui.WebDriverWait;

import java.util.function.Predicate;

public class TestBase extends DriverBase {
    protected static final Configuration config = Configuration.getInstance();
    protected static final LocalRegistry localRegistry = LocalRegistry.getInstance();

    private static void Initialize() {
        webDriver().navigate().to(config.getValue("basePortalUrl"));
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
}

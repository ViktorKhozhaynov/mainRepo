package Selenium.Common.TestEntities;

import Selenium.Common.Configs.Configuration;
import Selenium.Common.Configs.LocalRegistry;

public class TestBase extends DriverBase {
    protected static final Configuration config = Configuration.getInstance();
    protected static final LocalRegistry localRegistry = LocalRegistry.getInstance();

    private static void Initialize() {
        getDriver().navigate().to(config.getValue("basePortalUrl"));
    }

    public static void TestCase(String description, Runnable testBody) {
        Initialize();

        TestCase.TestCase(description, testBody);
    }

    public static void TestStep(String description, Runnable testStepBody) {
        TestStep.TestStep(description, testStepBody);
    }
}

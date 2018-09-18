package Selenium.Common.TestEntities;

import com.google.common.base.Stopwatch;
import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;

public class TestCase {
    private static final Logger log = LogManager.getFormatterLogger(TestCase.class.getName());

    public static void TestCase(String description, TestCodeBlock testBody) throws Exception {
        Stopwatch stopwatch = Stopwatch.createStarted();
        log.info("'%s' has started!", description);
        try {
            testBody.run();
        } catch (Exception ex) {
            log.info("'%s' has finished with an exception! Elapsed %d milliseconds", description, stopwatch.elapsed().toMillis());
            log.error("Error message: ", ex.getMessage());

            throw ex;
        } finally {
            log.info("'%s' has finished successfully! Elapsed %d milliseconds", description, stopwatch.elapsed().toMillis());
        }
    }
}

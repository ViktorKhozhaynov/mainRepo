package Selenium.Common.Configs;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileInputStream;
import java.io.InputStreamReader;

public class Configuration {
    private static final String CONFIG_PATH = "src/main/java/com/company/Selenium/config.json";

    private static final Logger log = LogManager.getFormatterLogger(Configuration.class.getName());
    private static JSONObject _jsonObject;
    private static final Configuration config = new Configuration();

    private Configuration() {
        try {
            log.debug("Trying to parse configuration from %s", CONFIG_PATH);
            _jsonObject = (JSONObject) new JSONParser().parse(new InputStreamReader(new FileInputStream(CONFIG_PATH)));
            log.debug("Parsing process has finished successfully!");
        } catch (Exception ex) {
            log.error("Parse Error has occurred during configuration parsing!");
            log.error("Error message: %s", ex.getMessage());
        }
    }

    public String getValue(String key){
        return (String) _jsonObject.get(key);
    }

    public static Configuration getInstance() {
        return config;
    }
}
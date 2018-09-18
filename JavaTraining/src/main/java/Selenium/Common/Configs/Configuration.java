package Selenium.Common.Configs;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.json.simple.JSONObject;
import org.json.simple.parser.JSONParser;

import java.io.FileInputStream;
import java.io.InputStreamReader;

public class Configuration {
    private static final String CONFIG_FILE_NAME = "config.json";

    private static final Logger log = LogManager.getFormatterLogger(Configuration.class.getName());
    private static JSONObject _jsonObject;
    private static final Configuration config = new Configuration();

    private Configuration() {
        try {
            ClassLoader classLoader = getClass().getClassLoader();
            String configFilePath = classLoader.getResource(CONFIG_FILE_NAME).getFile();

            log.debug("Trying to parse configuration from %s", configFilePath);
            _jsonObject = (JSONObject) new JSONParser().parse(new InputStreamReader(new FileInputStream(configFilePath)));
            log.debug("Parsing process has finished successfully!");
        } catch (Exception ex) {
            log.error("Parse Error has occurred during configuration parsing!");
            log.error("Error message: %s", ex.getMessage());
        }
    }

    public String getValue(String key){
        return  _jsonObject.get(key).toString();
    }

    public static Configuration getInstance() {
        return config;
    }
}
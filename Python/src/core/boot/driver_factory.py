# -*- coding: UTF-8 -*-
import os

from selenium.webdriver import Chrome, Firefox, Ie
from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
from selenium.webdriver.firefox.options import Options as FirefoxOptions


class DriverFactory:
    """
    Creates different implementations of Web Driver
    """

    @staticmethod
    def get_driver(driver_type: str) -> WebDriver:
        """
        Returns web driver of a set type
        :param driver_type: type of web driver, currently supported types - ['chrome', 'firefox', 'ie']
        :return: One of [Chrome, Firefox, Ie]
        """

        if driver_type == 'chrome':
            options = ChromeOptions()
            options.add_argument("--disable-notifications")
            options.add_argument('--ignore-certificate-errors')

            return Chrome(executable_path=f'{os.getcwd()}/src/drivers/chromedriver', options=options)
        if driver_type == 'firefox':
            options = FirefoxOptions()
            options.set_preference("dom.push.enabled", False)

            return Firefox(executable_path=f'{os.getcwd()}/src/drivers/geckodriver', options=options)

        raise UnsupportedDriverTypeException(f'{driver_type} is unsupported by the framework!')


class UnsupportedDriverTypeException(Exception):
    """ Custom exception that signals that condition hasn't been met """
    def __init__(self, message):
        self.message = message

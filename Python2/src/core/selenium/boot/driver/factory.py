# -*- coding: utf-8 -*-
import os

import requests

import config

from selenium.webdriver import Chrome, Firefox
from selenium.webdriver import Remote
from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.chrome.options import Options as ChromeOptions
from selenium.webdriver.firefox.options import Options as FirefoxOptions

from src.core.common.waiters.until import wait_until
from src.core.selenium.boot.driver.storage import DriverStorage

import src.core.selenium.boot.driver.type as _driver_type


class DriverFactory:
    """
    Creates different implementations of Web Driver
    """

    @staticmethod
    def get_driver(driver_type: str, headless: bool = False, remote: bool = False) -> WebDriver:
        """
        Returns web driver of a set type
        :param driver_type: type of web driver, currently supported types - ['chrome', 'firefox']
        :param headless: if True adds option to run headless
        :param remote: if True tries to execute on a remote standalone browser
        :return: One of [Chrome, Firefox]
        """

        options = DriverFactory.get_options(driver_type, headless)

        if remote:
            hub_link = DriverFactory.wait_until_remote_hub_is_ready()
            driver = Remote(command_executor=hub_link, desired_capabilities=options.to_capabilities())
        else:
            path = DriverFactory.get_local_executable_path(driver_type)
            driver = DriverFactory.get_local_web_driver(driver_type, path, options, headless)

        return DriverFactory.store_driver_and_return(driver)

    @staticmethod
    def wait_until_remote_hub_is_ready():
        hub_link = f'http://{config.remote_driver_host}:{config.remote_port}/wd/hub'
        hub_status_link = f'{hub_link}/status'

        def get_status():
            try:
                resp = requests.get(hub_status_link)
                resp_json = resp.json()

                return resp.ok and 'value' in resp_json and resp_json['value']['ready']
            except Exception:
                return False

        wait_until(lambda: get_status(), timeout=5)

        return hub_link

    @staticmethod
    def get_local_executable_path(driver_type):
        base_path = f'{os.getcwd()}/src/drivers'

        return {
            _driver_type.chrome: f'{base_path}/chromedriver',
            _driver_type.firefox: f'{base_path}/geckodriver'
        }[driver_type]

    @staticmethod
    def get_local_web_driver(driver_type, path, options, headless):
        return {
            _driver_type.chrome: lambda: DriverFactory.get_local_chrome_driver(path, options),
            _driver_type.firefox: lambda: DriverFactory.get_local_firefox_driver(path, options, headless)
        }[driver_type]()

    @staticmethod
    def get_local_chrome_driver(path, options):
        return Chrome(executable_path=path, options=options)

    @staticmethod
    def get_local_firefox_driver(path, options, headless):
        driver = Firefox(executable_path=path, options=options, service_log_path='logs/geckodriver.log')

        if headless:
            driver.set_window_position(0, 0)
            driver.set_window_size(1920, 1080)

        return driver

    @staticmethod
    def get_options(driver_type, headless):
        options_selection = {
            _driver_type.chrome: lambda: DriverFactory.get_chrome_options(headless),
            _driver_type.firefox: lambda: DriverFactory.get_firefox_options(headless)
        }

        if driver_type not in options_selection.keys():
            raise UnsupportedDriverTypeException(f'{driver_type} is unsupported by the framework!')

        return options_selection[driver_type]()

    @staticmethod
    def get_chrome_options(headless):
        options = ChromeOptions()
        options.add_argument("--disable-notifications")
        options.add_argument('--ignore-certificate-errors')

        if headless:
            options.add_argument("--headless")
            options.add_argument("--window-size=1920,1080")

        return options

    @staticmethod
    def get_firefox_options(headless):
        options = FirefoxOptions()

        if headless:
            options.headless = True

        return options

    @staticmethod
    def store_driver_and_return(web_driver: WebDriver):
        DriverStorage.set_driver(web_driver)
        return web_driver


class UnsupportedDriverTypeException(Exception):
    """ Custom exception that signals that condition hasn't been met """

    def __init__(self, message):
        self.message = message

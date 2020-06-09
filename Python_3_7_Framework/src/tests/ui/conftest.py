# -*- coding: utf-8 -*-
from pytest import fixture
from selenium.webdriver.remote.webdriver import WebDriver

import config
from src.core.selenium.boot.driver.factory import DriverFactory


@fixture(scope='function', name='wd')
def web_driver(browser_type: str, headless, remote) -> WebDriver:
    """ Returns initialized web driver of the set type """

    wd = DriverFactory.get_driver(browser_type, headless=headless, remote=remote)
    prepare_web_driver(wd)
    return wd


def prepare_web_driver(web_driver: WebDriver):
    web_driver.maximize_window()
    web_driver.implicitly_wait(config.default_implicit_wait)
    web_driver.set_page_load_timeout(config.default_page_load_timeout)

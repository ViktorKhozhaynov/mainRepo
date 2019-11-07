# -*- coding: UTF-8 -*-
from pytest import fixture
from selenium.webdriver.remote.webdriver import WebDriver
from src.core.boot.driver_factory import DriverFactory
from src.core.boot.driver_storage import DriverStorage


@fixture(scope='session')
def browser_type(request):
    """ Passes a command line argument into a fixture """
    return request.config.getoption('browser')


@fixture(scope='function', name='wd')
def web_driver(browser_type: str) -> WebDriver:
    """ Returns web driver of set type """
    wd = DriverFactory.get_driver(browser_type)
    DriverStorage.set_driver(wd)
    prepare_web_driver(wd)
    return wd


def prepare_web_driver(web_driver: WebDriver):
    web_driver.maximize_window()

    # set implicit wait to 1 second once and for all
    web_driver.implicitly_wait(1)

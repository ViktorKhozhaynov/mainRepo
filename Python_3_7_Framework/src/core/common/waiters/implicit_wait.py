# -*- coding: utf-8 -*-
import logging as log
from contextlib import contextmanager

import config
from src.core.selenium.boot.driver.storage import DriverStorage


@contextmanager
def implicitly_wait(custom_timeout):
    web_driver = DriverStorage.get_driver()
    try:
        if web_driver:
            web_driver.implicitly_wait(custom_timeout)
        yield
    finally:
        if web_driver:
            web_driver.implicitly_wait(config.default_implicit_wait)

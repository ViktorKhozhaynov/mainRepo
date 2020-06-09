# -*- coding: utf-8 -*-
import logging as log
from time import sleep
from typing import Union

from selenium.common.exceptions import NoSuchElementException
from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.remote.webelement import WebElement

from src.core.common.waiters.until import becomes_true
from src.core.selenium.boot.driver.storage import DriverStorage
from src.core.selenium.by import By
from src.core.selenium.decorators.click_intercept_safe import click_intercept_safe
from src.core.selenium.decorators.stale_reference_safe import stale_reference_safe


class HtmlSection:
    """
    Representation of a DOM section of any size
    """

    def __init__(self, base_object: Union[WebDriver, WebElement],
                 by: By,
                 parent,
                 from_web_element: bool = False):
        self.base_object: Union[WebDriver, WebElement] = base_object
        self.by: By = by
        self.parent = parent
        self.from_web_element = from_web_element

        self.__validate_init()

    def __validate_init(self):
        if self.from_web_element and not (isinstance(self.base_object, WebElement)):
            raise ClassMismatchException('For "from_web_element == True" an object of WebElement class is expected!')

    @property
    def web_element(self):
        return self.base_object if self.from_web_element else self.base_object.find_element(**self.by.as_kwargs)

    @property
    def web_driver(self):
        return self.base_object if isinstance(self.base_object, WebDriver) else DriverStorage.get_driver()

    @stale_reference_safe
    @click_intercept_safe
    def click(self):
        log.debug(f'Clicking the {self.internal_id} element')
        self.web_element.click()
        sleep(0.3)

    @stale_reference_safe
    def send_keys(self, value):
        self.web_element.send_keys(value)

    @stale_reference_safe
    def clear(self):
        self.web_element.clear()

    @property
    @stale_reference_safe
    def text(self):
        return self.web_element.text

    @property
    @stale_reference_safe
    def name(self):
        return self.web_element.tag_name

    @property
    def internal_id(self):
        return f'["{self.by.locator}" by {self.by.type}]'

    @property
    @stale_reference_safe
    def is_present(self):
        try:
            log.debug(f'Checking if element {self.internal_id} is present')

            bool(self.web_element)
            return True
        except NoSuchElementException:
            return False

    @property
    def is_absent(self):
        log.debug(f'Checking if element {self.internal_id} is absent')
        return len(self.base_object.find_elements(self.by.type, self.by.locator)) == 0

    @property
    @stale_reference_safe
    def is_displayed(self):
        try:
            log.debug(f'Checking if element {self.internal_id} is displayed')

            return self.web_element.is_displayed()
        except NoSuchElementException as e:
            log.debug(f'Element {self.internal_id} has not been found!')
            log.error(f'{e.msg}')
        return False

    @property
    @stale_reference_safe
    def is_hidden(self):
        return not self.is_displayed

    @property
    @stale_reference_safe
    def is_enabled(self):
        log.debug(f'Checking if element {self.internal_id} is enabled')
        return self.web_element.is_enabled()

    @stale_reference_safe
    def get_attribute(self, name: str):
        return self.web_element.get_attribute(name)

    @stale_reference_safe
    def has_class(self, name: str):
        return name in self.web_element.get_attribute('class').split()

    def wait_to_come_and_go(self, timeout=1):
        log.debug(f'Waiting for element {self.internal_id} to come and go')
        if not becomes_true(lambda: self.is_present and self.is_displayed, timeout=timeout):
            return

        if becomes_true(lambda: self.is_absent, timeout=timeout):
            return

        if becomes_true(lambda: self.is_hidden, timeout=timeout):
            return

        raise ElementDidNotDisappearException(f'Element {self.internal_id} appeared but did not go away '
                                              f'after a period of time!')


class ElementDidNotDisappearException(Exception):
    """ Custom exception that signals that condition hasn't been met """

    def __init__(self, message):
        self.message = message


class ClassMismatchException(Exception):
    """ Custom exception that signals that condition hasn't been met """

    def __init__(self, message):
        self.message = message

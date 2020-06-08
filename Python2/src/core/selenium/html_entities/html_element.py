# -*- coding: utf-8 -*-
from typing import Union

from selenium.webdriver.remote.webdriver import WebDriver
from selenium.webdriver.remote.webelement import WebElement

from src.core.selenium.by import By
from src.core.selenium.html_entities.html_section import HtmlSection


class HtmlElement(HtmlSection):
    """
    Representation of the smallest HTML unit in the DOM
    """

    def __init__(self, base_object: Union[WebDriver, WebElement],
                 by: Union[By, WebElement],
                 parent,
                 expected_text: str = None,
                 expected_placeholder: str = None,
                 from_web_element: bool = False):
        super().__init__(base_object, by, parent, from_web_element=from_web_element)

        self.expected_text = expected_text
        self.expected_placeholder = expected_placeholder

    def has_expected_text(self) -> bool:
        """
        Compares expected text with current text
        :return: bool result
        """

        if self.expected_text is not None:
            return self.text == self.expected_text
        else:
            raise ExpectedTextNotFoundException('expected_text attribute has not been found in the Html Element!')

    def has_placeholder_text(self) -> bool:
        """
        Compares expected placeholder text with current text
        :return: bool result
        """

        if self.expected_placeholder is not None:
            return self.text == self.expected_placeholder
        else:
            raise ExpectedPlaceholderTextNotFoundException('expected_text attribute has not been found '
                                                           'in the Html Element!')


class ExpectedTextNotFoundException(Exception):
    """ Custom exception that signals that expected text hasn't been set when it should have been """
    def __init__(self, message):
        self.message = message


class ExpectedPlaceholderTextNotFoundException(Exception):
    """ Custom exception that signals that expected placeholder text hasn't been set when it should have been """
    def __init__(self, message):
        self.message = message

# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.html_entities.html_element import HtmlElement
import logging as log


class HtmlInputElement(HtmlElement):
    @property
    def text(self):
        return self.get_attribute('value')

    @text.setter
    def text(self, value: str):
        log.debug(f'Setting the {self.internal_id} element text to "{value}"')
        self.clear()
        self.send_keys('')
        self.send_keys(value)

        wait_until(lambda: self.text == value)

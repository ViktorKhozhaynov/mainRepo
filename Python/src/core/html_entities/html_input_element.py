# -*- coding: UTF-8 -*-
from src.core.html_entities.html_element import HtmlElement
from src.core.waiters.until import wait_until


class HtmlInputElement(HtmlElement):
    @property
    def text(self):
        return self.web_element.get_attribute('value')

    @text.setter
    def text(self, value: str):
        self.web_element.clear()
        self.web_element.send_keys('')
        self.web_element.send_keys(value)

        wait_until(lambda: self.text == value)

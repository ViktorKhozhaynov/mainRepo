# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_button_element import HtmlButtonElement
from src.core.selenium.html_entities.html_element import HtmlElement
from src.core.selenium.html_entities.html_section import HtmlSection


class HeaderSection(HtmlSection):
    @property
    def login_button(self):
        return HtmlButtonElement(self.web_element, By.css('.login'), self)

    @property
    def contact_us_button(self):
        return HtmlButtonElement(self.web_driver, By.css('#contact-link a'), self)

    @property
    def call_us_now_element(self):
        return HtmlElement(self.web_element, By.css('.shop-phone'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.login_button.is_displayed)
        wait_until(lambda: self.login_button.is_enabled)

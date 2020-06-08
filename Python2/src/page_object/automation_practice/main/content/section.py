# -*- coding: utf-8 -*-
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.html_entities.html_button_element import HtmlButtonElement
from src.core.selenium.html_entities.html_section import HtmlSection


class ContentSection(HtmlSection):
    @property
    def dashboard_button(self):
        return HtmlButtonElement(self.web_element, By.css('#menuform\\:om_dashboard a'), self)

    @property
    def shops_button(self):
        return HtmlButtonElement(self.web_element, By.css('#menuform\\:om_shops a'), self)

    @property
    def users_button(self):
        return HtmlButtonElement(self.web_element, By.css('#menuform\\:om_users a'), self)

    @property
    def orientation_button(self):
        return HtmlButtonElement(self.web_element, By.css('#menuform\\:om_orientation a'), self)

    @property
    def logout_button(self):
        return HtmlButtonElement(self.web_element, By.css('#menuform\\:om_ext a'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.logout_button.is_displayed)
        wait_until(lambda: self.logout_button.is_enabled)

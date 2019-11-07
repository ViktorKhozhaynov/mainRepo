# -*- coding: UTF-8 -*-
from src.core.by import By
from src.core.html_entities.html_element import HtmlElement
from src.core.html_entities.html_overlay import HtmlOverlay
from src.core.waiters.until import wait_until


class DiscountOverlay(HtmlOverlay):
    """
    This class represents Discount overlay which should not be shown ever
    cause webdriver never operates outside of the browser
    """

    @property
    def title(self):
        return HtmlElement(self.web_element, By.css('h5.hide-for-small-only'), self)

    @property
    def close_button(self):
        return HtmlElement(self.web_element, By.css('button.desmoines-CloseButton'), self)

    @property
    def promo_code_text(self):
        return HtmlElement(self.web_element, By.xpath('.//span[contains(text(), "Use promocode")]'), self)

    def close_overlay(self):
        self.close_button.click()
        wait_until(lambda: self.is_hidden)

# -*- coding: UTF-8 -*-
from src.core.by import By
from src.core.html_entities.html_element import HtmlElement
from src.core.page import Page
from src.core.waiters.until import wait_until
from src.page_object.peachy.main_page_contents.discount_overlay import DiscountOverlay
from src.page_object.peachy.main_page_contents.loan_section import LoanSection


class MainPage(Page):
    @property
    def loan_section(self):
        return LoanSection(self.web_driver, By.css('.loan-details'), self)

    @property
    def discount_overlay(self):
        return DiscountOverlay(self.web_driver, By.class_name('Campaign__canvas'), self)

    @property
    def logo(self):
        return HtmlElement(self.web_driver, By.id('logo'), self)

    @property
    def title(self):
        return HtmlElement(self.web_driver, By.css('.welcome-block h1'), self, expected_text='Short Term Loans')

    def wait_until_ready(self):
        wait_until(lambda: self.loan_section.is_displayed)
        wait_until(lambda: self.loan_section.total_repayable.text)

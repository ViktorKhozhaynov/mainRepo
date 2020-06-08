# -*- coding: utf-8 -*-
from src.page_object.automation_practice.base.page import BasePage
from src.page_object.automation_practice.main.content.section import ContentSection
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By


class MainPage(BasePage):
    @property
    def content_section(self):
        return ContentSection(self.web_driver, By.id('columns'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.header_section.is_displayed)
        self.header_section.wait_until_ready()

    def click_login_button(self):
        self.header_section.login_button.click()

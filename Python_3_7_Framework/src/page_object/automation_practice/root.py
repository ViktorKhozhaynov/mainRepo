# -*- coding: utf-8 -*-
from selenium.webdriver.remote.webdriver import WebDriver

import config
from src.core.selenium.boot.driver.storage import DriverStorage
from src.page_object.automation_practice.login.page import LoginPage
from src.page_object.automation_practice.main.page import MainPage
from src.test_data.dictionaries.user import AutoTestUser


class Root:
    def __init__(self):
        self.web_driver: WebDriver = DriverStorage.get_driver()

    @property
    def login_page(self):
        return LoginPage(self.web_driver, self)

    @property
    def main_page(self):
        return MainPage(self.web_driver, self)

    def navigate(self):
        self.web_driver.get(config.base_url)
        return self

    def login(self, user: AutoTestUser):
        self.main_page.click_login_button()
        self.login_page.wait_until_ready()
        self.login_page.login(user)

# -*- coding: utf-8 -*-
from src.page_object.automation_practice.base.header.section import HeaderSection
from src.page_object.automation_practice.base.menu.section import MenuSection
from src.core.common.waiters.until import wait_until
from src.core.selenium.by import By
from src.core.selenium.page import Page
from src.page_object.automation_practice.base.search.section import SearchSection


class BasePage(Page):
    @property
    def header_section(self):
        return HeaderSection(self.web_driver, By.css('.nav .row'), self)

    @property
    def search_section(self):
        return SearchSection(self.web_driver, By.xpath('//div[div/div[@class="row"]/div[@id="header_logo"]]'), self)

    @property
    def menu_section(self):
        return MenuSection(self.web_driver, By.id('block_top_menu'), self)

    def wait_until_ready(self):
        wait_until(lambda: self.header_section.is_displayed)
        self.header_section.wait_until_ready()

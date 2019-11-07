# -*- coding: UTF-8 -*-
from selenium.webdriver.remote.webdriver import WebDriver
import os
import datetime


class ScreenShot:
    """
    Helps creating screenshots for a failed test
    """
    @staticmethod
    def take(web_driver: WebDriver, test_name: str) -> bool:
        """

        :param web_driver: an object that will actually be taking the screen shot
        :param test_name: name of the test which is associated with the screen shot
        :return: True if everything worked well
        """
        if not os.path.exists('logs'):
            os.makedirs('logs')
        if not os.path.exists(f'logs/{test_name}'):
            os.makedirs(f'logs/{test_name}')

        screenshot_path = f'logs/{test_name}/screenshot_{datetime.datetime.now().strftime("%Y%m%d%H%M%S")}.png'
        return web_driver.save_screenshot(screenshot_path)

# -*- coding: utf-8 -*-
from time import sleep

from selenium.common.exceptions import ElementClickInterceptedException


def click_intercept_safe(func):
    def func_wrapper(*args, **kwargs):
        try:
            return func(*args, **kwargs)
        except ElementClickInterceptedException:
            sleep(1)
            return func(*args, **kwargs)
    return func_wrapper

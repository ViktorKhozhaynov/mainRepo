# -*- coding: utf-8 -*-
from time import sleep

from selenium.common.exceptions import StaleElementReferenceException


def stale_reference_safe(func):
    def func_wrapper(*args, **kwargs):
        try:
            return func(*args, **kwargs)
        except StaleElementReferenceException:
            sleep(0.5)
            return func(*args, **kwargs)
    return func_wrapper

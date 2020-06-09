# -*- coding: utf-8 -*-
# noinspection PyProtectedMember
from allure_commons._allure import step as allure_step
import logging as log


def step(title):
    log.info(f'||| ----> "{title}"')
    return allure_step(title)

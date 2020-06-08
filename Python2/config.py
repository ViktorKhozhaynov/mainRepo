# -*- coding: utf-8 -*-
import os

default_implicit_wait = 5
default_page_load_timeout = 20

base_url = 'http://automationpractice.com/index.php'

remote_driver_host = os.getenv('SELENIUM_HUB_HOST', 'X.X.X.X')
remote_port = 4444

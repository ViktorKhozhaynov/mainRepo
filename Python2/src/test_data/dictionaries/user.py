# -*- coding: utf-8 -*-
from dataclasses import dataclass


@dataclass
class AutoTestUser:
    login: str
    password: str
    email_domain: str = 'xyz.com'

    @property
    def email(self):
        return f'{self.login}@{self.email_domain}'


# Password encryption mechanism is yet to be implemented
test_user = AutoTestUser(login='abc', password='Test@123')

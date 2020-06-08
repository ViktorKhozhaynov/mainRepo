# -*- coding: utf-8 -*-
from _pytest.mark.structures import MarkDecorator

# noinspection PyProtectedMember
from allure_commons._allure import link
from allure_commons.types import LinkType


def jira(issue_number: str) -> MarkDecorator:
    return link(
        f'https://jira-address/browse/{issue_number}',
        link_type=LinkType.ISSUE,
        name=issue_number
    )

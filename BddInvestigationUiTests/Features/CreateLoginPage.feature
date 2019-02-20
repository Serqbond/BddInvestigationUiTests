﻿Feature: Create login page

@1 @positive
Scenario: Verify that a user is able to log in
    Given I open a login page
    When I enter correct user name 'admin@mail.com' and password 'Password123!'
    When I use exisiting user login and password
    Then The user is logged in
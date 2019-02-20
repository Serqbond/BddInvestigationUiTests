Feature: It should be possible to add a new user via 'Add New' button

@1 @positive
Scenario: Verify creating a new user
    Given I open Add New User Page
	When I fill new user form
	| Field       | Value          |
	| FirstName   | Ivan           |
	| LastName    | Ivanov         |
	| Email       | user@email.com |
	| DateOfBirth | 12301990       |
	| City        | Boston         |
	And click on create button
    Then user should be in the table

@2 @negative
Scenario: Verify the canceling of a new user creation
    Given I open Add New User Page
    When I fill new user form
	| Field       | Value          |
	| FirstName   | John           |
	| LastName    | Dow            |
	| Email       | djdou@email.com |
	| DateOfBirth | 11301991       |
	| City        | Boston         |
	And click on Cancel button
    Then Add New User Page closes
    And user isn't added to the table
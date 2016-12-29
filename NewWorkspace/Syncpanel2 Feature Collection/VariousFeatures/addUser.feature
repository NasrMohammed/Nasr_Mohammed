#Kevin
Feature: Adding user to system
	As a Syncpanel2 administrator,
	I want to make sure I can add users to the system,
	In order to ensure core functionality is unchanged.
	
	Background: Must be logged in and in the correct testing area
		Given I am on the Syncpanel2 landing page
		Then I log in
		And I navigate to the correct testing location
	
	Scenario: Adding user to syncpanel2
		Given I click the Add User button
		When the dialog box opens
		Then I should be able to fill in the fields with data
		And return to the users section
		
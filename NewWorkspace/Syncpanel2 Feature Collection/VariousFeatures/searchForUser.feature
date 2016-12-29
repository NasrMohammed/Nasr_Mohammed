#Author: Wesley Parriott
Feature: Searching system for User 
	As a Syncpanel2 administrator,
	I want to make sure I can search for a user,
	In order to assert core functionality.

	Background: Must be logged in and in the correct testing area
		Given I am on the Syncpanel2 landing page
		Then I log in
		
		
	Scenario: Searching for a user 
		Given I navigate to Users under User Management in the navigation bar 
		When I enter my user into the search bar
		Then the user should be in the table
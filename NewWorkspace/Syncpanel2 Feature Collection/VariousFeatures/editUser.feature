#Nasr
Feature: Editing user 
	As a Syncpanel2 administrator, 
	I want to edit the user profile, 
	Inorder to make sure the correct functionality working correctly.
	
	Background: Must be logged in and in the correct testing area
		Given I am on the Syncpanel2 landing page
		Then I log in
		And I navigate to the correct testing location
		
  Scenario: Editing user in Syncpanel2
  	Given I click the Edit User button
  	When the dialog box opens
  	Then I should be able to edit the fields of data
  	And return to the users section
  

#Kevin Gallagher
#12/22/2016
#v1.0.0
#Feature to validate elements on the home page.
Feature: Syncpanel2 home page testing
  As an administrator at Syncbak,
  I want to make sure all the elements on the home page are there,
  In order to ensure quality product for my clients.

  Background: Must be logged in and in the correct testing location
    Given I am on the landing page
    And I am logged in to Syncpanel2

  Scenario: Basic smoke test for the Syncpanel2 home page
    Given I am on the homepage
    Then it should contain these tabs
      | UserManagement | User Management |
      | ProgramLibrary | Program Library |
      | Schedule       | Schedule        |
      | StreamAccess   | Stream Access   |
      | AllAccess      | All Access      |
      | MediaManager   | Media Manager   |
      | Miscellaneous  | Utilities       |
      | Reports        | Reports         |
      | Settings       | Settings        |

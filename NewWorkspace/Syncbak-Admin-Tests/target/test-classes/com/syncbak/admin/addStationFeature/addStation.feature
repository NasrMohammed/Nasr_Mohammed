#Kevin Gallagher
#12/20/2016
#v1.5.0
#Test feature for stations tab
Feature: Stations tab testing
  As an adminstrator at Syncbak,
  I want to be able to add Stations to the system,
  In order to effectively manage them.

  Background: Must be logged in. Must be in the correct testing location.
    Given I am on the landing page
    And I am logged in to Syncbak Admin
    And I am in the Stations tab

  Scenario: Basic smoke test for adding a station
    Given I have pressed the "Add Station" button
    When the dialog box opens
    Then I should be able to fill the fields with data
      #column 1 = webElement id
      #column 2 = value to be sent
      | callSign     | QATST      |
      | stationType  | Network    |
      | stationOwner | CBS TV     |
      | operator     | CBS TV     |
      | dma          | Albany, GA |
      | broadcastDMA | Albany, GA |
      | latitude     |    31.5785 |
      | longitude    |    84.1557 |
      | city         | Albany     |
      | state        | Georgia    |
    And sucessfully close the "Add Station" dialog box

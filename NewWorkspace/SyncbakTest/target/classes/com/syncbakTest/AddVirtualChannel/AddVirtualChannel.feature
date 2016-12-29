#Test feature for Virtual Channel
Feature: Add Virtual Channel testing
  As an adminstrator at Syncbak,
  I want to be able to add Virtual Channel to the system,
  In order to effectively manage them.

  Background: Mst be logged in. Must be in the correct testing location.
    Given I am on the landing page
    And I am logged in to Syncbak Admin
    And I am in the Stations tab

  Scenario: Adding a virtual channel to Syncbak Admin
    Given I have pressed the "Green plus sign" button
    When the dialog box expanded
    And I pressed "Add Vritual Channel" button
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
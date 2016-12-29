$(document).ready(function() {var formatter = new CucumberHTML.DOMFormatter($('.cucumber-report'));formatter.uri("src/test/resources/com/syncbak/admin/addStationFeature/addStation.feature");
formatter.feature({
  "comments": [
    {
      "line": 1,
      "value": "#Kevin Gallagher"
    },
    {
      "line": 2,
      "value": "#12/20/2016"
    },
    {
      "line": 3,
      "value": "#v1.5.0"
    },
    {
      "line": 4,
      "value": "#Test feature for stations tab"
    }
  ],
  "line": 5,
  "name": "Stations tab testing",
  "description": "As an adminstrator at Syncbak,\r\nI want to be able to add Stations to the system,\r\nIn order to effectively manage them.",
  "id": "stations-tab-testing",
  "keyword": "Feature"
});
formatter.background({
  "line": 10,
  "name": "Must be logged in. Must be in the correct testing location.",
  "description": "",
  "type": "background",
  "keyword": "Background"
});
formatter.step({
  "line": 11,
  "name": "I am on the landing page",
  "keyword": "Given "
});
formatter.step({
  "line": 12,
  "name": "I am logged in to Syncbak Admin",
  "keyword": "And "
});
formatter.step({
  "line": 13,
  "name": "I am in the Stations tab",
  "keyword": "And "
});
formatter.match({
  "location": "AddStationSteps.i_am_on_the_landing_page()"
});
formatter.result({
  "duration": 15780643148,
  "status": "passed"
});
formatter.match({
  "location": "AddStationSteps.i_am_logged_in_to_Syncbak_Admin()"
});
formatter.result({
  "duration": 993227100,
  "status": "passed"
});
formatter.match({
  "location": "AddStationSteps.i_am_in_the_Stations_tab()"
});
formatter.result({
  "duration": 10961426001,
  "status": "passed"
});
formatter.scenario({
  "line": 15,
  "name": "Basic smoke test for adding a station",
  "description": "",
  "id": "stations-tab-testing;basic-smoke-test-for-adding-a-station",
  "type": "scenario",
  "keyword": "Scenario"
});
formatter.step({
  "line": 16,
  "name": "I have pressed the \"Add Station\" button",
  "keyword": "Given "
});
formatter.step({
  "line": 17,
  "name": "the dialog box opens",
  "keyword": "When "
});
formatter.step({
  "line": 18,
  "name": "I should be able to fill the fields with data",
  "rows": [
    {
      "comments": [
        {
          "line": 19,
          "value": "#column 1 \u003d webElement id"
        },
        {
          "line": 20,
          "value": "#column 2 \u003d value to be sent"
        }
      ],
      "cells": [
        "callSign",
        "QATST"
      ],
      "line": 21
    },
    {
      "cells": [
        "stationType",
        "Network"
      ],
      "line": 22
    },
    {
      "cells": [
        "stationOwner",
        "CBS TV"
      ],
      "line": 23
    },
    {
      "cells": [
        "operator",
        "CBS TV"
      ],
      "line": 24
    },
    {
      "cells": [
        "dma",
        "Albany, GA"
      ],
      "line": 25
    },
    {
      "cells": [
        "broadcastDMA",
        "Albany, GA"
      ],
      "line": 26
    },
    {
      "cells": [
        "latitude",
        "31.5785"
      ],
      "line": 27
    },
    {
      "cells": [
        "longitude",
        "84.1557"
      ],
      "line": 28
    },
    {
      "cells": [
        "city",
        "Albany"
      ],
      "line": 29
    },
    {
      "cells": [
        "state",
        "Georgia"
      ],
      "line": 30
    }
  ],
  "keyword": "Then "
});
formatter.step({
  "line": 31,
  "name": "sucessfully close the \"Add Station\" dialog box",
  "keyword": "And "
});
formatter.match({
  "arguments": [
    {
      "val": "Add Station",
      "offset": 20
    }
  ],
  "location": "AddStationSteps.i_have_pressed_the_button(String)"
});
formatter.result({
  "duration": 275473968,
  "status": "passed"
});
formatter.match({
  "location": "AddStationSteps.the_dialog_box_opens()"
});
formatter.result({
  "duration": 45504034,
  "status": "passed"
});
formatter.match({
  "location": "AddStationSteps.i_should_be_able_to_fill_the_fields_with_data(DataTable)"
});
formatter.result({
  "duration": 9395954108,
  "status": "passed"
});
formatter.match({
  "arguments": [
    {
      "val": "Add Station",
      "offset": 23
    }
  ],
  "location": "AddStationSteps.sucessfully_close_the_dialog_box(String)"
});
formatter.result({
  "duration": 2461462923,
  "status": "passed"
});
});
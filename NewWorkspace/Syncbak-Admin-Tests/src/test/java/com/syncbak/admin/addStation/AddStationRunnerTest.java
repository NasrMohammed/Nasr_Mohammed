package com.syncbak.admin.addStation;

import org.junit.runner.RunWith;
import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(features = { "src/test/resources/com/syncbak/admin/addStationFeature/addStation.feature" }, 
				 plugin = { "pretty", "html:target/html-reports","json:target/json-reports/cucumber-report.json" },
				 glue = { "com.syncbak.admin.addStation" }
				)
public class AddStationRunnerTest {

}

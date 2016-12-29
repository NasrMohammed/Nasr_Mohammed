package com.syncbak.syncpanel2.homePageValidation;

import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(features = { "src/test/resources/com/syncbak/syncpanel2/homePageFeature/homepagevalidation.feature" },
				 plugin = { "pretty", "html:target/html-reports","json:target/json-reports/cucumber-report.json" },
				 glue = { "com.syncbak.syncpanel2.homePageValidation" }
				)


public class HomePageValidationRunnerTest {

}

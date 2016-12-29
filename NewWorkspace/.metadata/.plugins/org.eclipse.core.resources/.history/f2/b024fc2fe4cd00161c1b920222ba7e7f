package com.nasr.syncbak.SyncbakTest;

import org.junit.runner.RunWith;

import cucumber.api.CucumberOptions;
import cucumber.api.junit.Cucumber;

@RunWith(Cucumber.class)
@CucumberOptions(features = { "src/test/resources/com/syncbakTest/AddVirtualChannel/AddVirtualChannel.feature" }, 
plugin = { "pretty", "html:target/html-reports","json:target/json-reports/cucumber-report.json" },
glue = { "com.syncbak.admin.addStation" }
)
public class AddVirtualChannelRunner {

}

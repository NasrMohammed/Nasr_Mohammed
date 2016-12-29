package com.syncbak.admin.addStation;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.syncbak.admin.driverUtilities.DriverUtilities;
import com.syncbak.admin.pageObjects.StationsTab;

import cucumber.api.DataTable;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;

public class AddStationSteps {
	DriverUtilities di = new DriverUtilities();
	WebDriver driver = di.getDriver();
	WebDriverWait wait = new WebDriverWait(driver, 10);
	private String userName = "kevin";
	private String passWord = "syncbak";
	private String stationsUrl = "https://qa-admin.syncbak.com/StationChannel";
	private String addStationClassName = "modal-body";

	// Background sequences...
	@Given("^I am on the landing page")
	public void i_am_on_the_landing_page() throws Throwable {
		driver.manage().deleteAllCookies();
		driver.manage().window().maximize();
		driver.navigate().to(stationsUrl);
	}

	@And("^I am logged in to Syncbak Admin$")
	public void i_am_logged_in_to_Syncbak_Admin() throws Throwable {
		wait.until(ExpectedConditions.elementToBeClickable(By.id("UserName"))).sendKeys(userName);
		wait.until(ExpectedConditions.elementToBeClickable(By.id("Password"))).sendKeys(passWord);
		wait.until(ExpectedConditions.elementToBeClickable(By.id("btnSubmit"))).click();
	}

	@And("^I am in the Stations tab$")
	public void i_am_in_the_Stations_tab() throws Throwable {
		wait.until(ExpectedConditions.urlToBe(stationsUrl));
	}
	// End Background sequences...

	// Scenario start...
	@Given("^I have pressed the \"([^\"]*)\" button$")
	public void i_have_pressed_the_button(String Add_Station) throws Throwable {
		Add_Station = "(//button[@data-bind='click: add'])[1]";
		wait.until(ExpectedConditions.elementToBeClickable(By.xpath(Add_Station))).click();
	}

	@And("^the dialog box opens$")
	public void the_dialog_box_opens() throws Throwable {
		wait.until(ExpectedConditions.presenceOfElementLocated(By.className(addStationClassName)));
	}

	@Then("^I should be able to fill the fields with data$")
	public void i_should_be_able_to_fill_the_fields_with_data(DataTable fieldData) throws Throwable {
		wait.until(ExpectedConditions.elementToBeClickable(By.id("callSign")));
		StationsTab.addStationInputFields(fieldData, driver);
		StationsTab.addStationToggleGroups(driver);
	}

	@Then("^sucessfully close the \"([^\"]*)\" dialog box$")
	public void sucessfully_close_the_dialog_box(String cancelButton) throws Throwable {
		cancelButton = "(//button)[@data-dismiss='modal'][2]";
		wait.until(ExpectedConditions.elementToBeClickable(By.xpath(cancelButton))).click();
		di.closeDriver();
	}
	// Scenario finish...

}

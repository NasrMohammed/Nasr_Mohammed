package com.syncbak.syncpanel2.homePageValidation;

import org.junit.Assert;
import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import com.syncbak.syncpanel2.driverUtilities.DriverUtilities;
import com.syncbak.syncpanel2.pageObjects.HomePageNavigation;

import cucumber.api.DataTable;
import cucumber.api.java.After;
import cucumber.api.java.en.And;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;

public class HomePageValidationSteps {
	DriverUtilities di = new DriverUtilities();
	WebDriver driver = di.getDriver();
	WebDriverWait wait = new WebDriverWait(driver, 10);
	private String syncpanel2Url = "http://qa-syncpanel2.syncbak.com/Account/Login?ReturnUrl=%2F";
	private String userName = "kevin.gallagher@syncbak.com";
	private String passWord = "Syncb@k01";
	private String buttonXpath = "//input[@value='LOGIN']";

	@Given("^I am on the landing page$")
	public void i_am_on_the_landing_page() throws Throwable {
		driver.manage().deleteAllCookies();
		driver.manage().window().maximize();
		driver.navigate().to(syncpanel2Url);
	}

	@And("^I am logged in to Syncpanel(\\d+)$")
	public void i_am_logged_in_to_Syncpanel(int arg1) throws Throwable {
		wait.until(ExpectedConditions.elementToBeClickable(By.id("Username"))).sendKeys(userName);
		wait.until(ExpectedConditions.elementToBeClickable(By.id("Password"))).sendKeys(passWord);
		wait.until(ExpectedConditions.elementToBeClickable(By.xpath(buttonXpath))).click();
	}

	@Given("^I am on the homepage$")
	public void i_am_on_the_homepage() throws Throwable {
		wait.until(ExpectedConditions.urlToBe("http://qa-syncpanel2.syncbak.com/"));
	}

	@Then("^it should contain these tabs$")
	public void it_should_contain_these_tabs(DataTable HomePageData) throws Throwable {
		HomePageNavigation hpn = new HomePageNavigation();
		Boolean result = hpn.validateTopLevelNav(HomePageData, driver);
		Assert.assertTrue(result.booleanValue());
	}

	@After
	public void closeStuff() {
		di.closeDriver();
	}
}

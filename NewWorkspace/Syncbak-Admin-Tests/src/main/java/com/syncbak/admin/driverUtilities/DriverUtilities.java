package com.syncbak.admin.driverUtilities;

import org.openqa.selenium.WebDriver;
import org.openqa.selenium.chrome.ChromeDriver;

public class DriverUtilities {
	private WebDriver driver = new ChromeDriver();

	public WebDriver getDriver() {
		if (driver.toString() == null) {
			driver = new ChromeDriver();
		}
		return driver;
	}

	public void closeDriver() {
		if (driver.toString() != null) {
			driver.close();
		}
	}

}

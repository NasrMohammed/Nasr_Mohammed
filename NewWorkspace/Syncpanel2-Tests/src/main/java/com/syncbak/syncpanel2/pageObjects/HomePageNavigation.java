package com.syncbak.syncpanel2.pageObjects;

import java.util.Map;

import org.openqa.selenium.By;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import cucumber.api.DataTable;
import cucumber.api.junit.Cucumber;

public class HomePageNavigation {

	public Boolean validateTopLevelNav(DataTable homePageData, WebDriver driver) {
		WebDriverWait wait = new WebDriverWait(driver, 10);
		Map<String, String> dataList;
		dataList = homePageData.asMap(String.class, String.class);
		WebElement sp2NavTabs;
		Boolean value = false;
		for (Map.Entry<String, String> entry : dataList.entrySet()) {
			sp2NavTabs = wait.until(ExpectedConditions.visibilityOfElementLocated(By.id(entry.getKey())));
			value = sp2NavTabs.getText().equals(entry.getValue());
			if(value.equals(false)){
				break;
			}
		}
		return value;
	}

}
package com.syncbak.admin.pageObjects;

import java.util.Map;

import org.openqa.selenium.By;
import org.openqa.selenium.Keys;
import org.openqa.selenium.WebDriver;
import org.openqa.selenium.WebElement;
import org.openqa.selenium.support.ui.ExpectedConditions;
import org.openqa.selenium.support.ui.WebDriverWait;

import cucumber.api.DataTable;

public class StationsTab {

	public static void addStationInputFields(DataTable fieldData, WebDriver driver) {
		Map<String, String> dataList;
		dataList = fieldData.asMap(String.class, String.class);
		WebElement em;
		WebDriverWait wait = new WebDriverWait(driver, 5);

		for (Map.Entry<String, String> entry : dataList.entrySet()) {
			em = wait.until(ExpectedConditions.elementToBeClickable(By.id(entry.getKey())));
			try {
				em.sendKeys(Keys.BACK_SPACE);
				Thread.sleep(250);
				em.sendKeys(entry.getValue());
				Thread.sleep(250);
			} catch (InterruptedException ie) {
				ie.printStackTrace();
			}
		}
	}

	public static void addStationToggleGroups(WebDriver driver) {
		String includeInProdToggleOn = "(//div[@class='toggle-group'])[1]/descendant::label[1]";
		String includeInProdToggleOff = "(//div[@class='toggle-group'])[1]/descendant::label[2]";
		String includeInDemoToggleOn = "(//div[@class='toggle-group'])[2]/descendant::label[1]";
		String includeInDemoToggleOff = "(//div[@class='toggle-group'])[2]/descendant::label[2]";

		WebDriverWait wait = new WebDriverWait(driver, 5);
		WebElement iPtoggleOn = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(includeInProdToggleOn)));
		WebElement iPtoggleOff = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(includeInProdToggleOff)));
		WebElement iDtoggleOn = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(includeInDemoToggleOn)));
		WebElement iDtoggleOff = wait.until(ExpectedConditions.elementToBeClickable(By.xpath(includeInDemoToggleOff)));

		if (iPtoggleOn.isSelected()) {
			iPtoggleOff.click();

			System.err.println("We had to click iPtoggleOff.");

		}

		if (iDtoggleOn.isSelected()) {
			iDtoggleOff.click();

			System.err.println("We had to click iDtoggleOff.");

		}

	}

}

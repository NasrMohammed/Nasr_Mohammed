package com.nasr.syncbak.SyncbakTest;

import cucumber.api.DataTable;
import cucumber.api.PendingException;
import cucumber.api.java.en.Given;
import cucumber.api.java.en.Then;
import cucumber.api.java.en.When;

public class AddVirtualChannelSteps {

	@Given("^I am on the landing page$")
	public void i_am_on_the_landing_page() throws Throwable {
		System.out.println("Executed to landing page");

	}

	@Given("^I am logged in to Syncbak Admin$")
	public void i_am_logged_in_to_Syncbak_Admin() throws Throwable {
		System.out.println("Executed to landing 2");


	}

	@Given("^I am in the Stations tab$")
	public void i_am_in_the_Stations_tab() throws Throwable {

		System.out.println("Executed to landing 3");

	}

	@Given("^I have pressed the \"([^\"]*)\" button$")
	public void i_have_pressed_the_button(String arg1) throws Throwable {

		System.out.println("Executed to landing 4");

	}

	@When("^the dialog box expanded$")
	public void the_dialog_box_expanded() throws Throwable {
		System.out.println("Executed to landing 5");


	}

	@When("^I pressed \"([^\"]*)\" button$")
	public void i_pressed_button(String arg1) throws Throwable {

		System.out.println("Executed to landing 6");

	}

	@Then("^I should be able to fill the fields with data$")
	public void i_should_be_able_to_fill_the_fields_with_data(DataTable arg1) throws Throwable {
	    // Write code here that turns the phrase above into concrete actions
	    // For automatic transformation, change DataTable to one of
	    // List<YourType>, List<List<E>>, List<Map<K,V>> or Map<K,V>.
	    // E,K,V must be a scalar (String, Integer, Date, enum etc)
		System.out.println("Executed to landing 7");

	}

	@Then("^sucessfully close the \"([^\"]*)\" dialog box$")
	public void sucessfully_close_the_dialog_box(String arg1) throws Throwable {

		System.out.println("Executed to landing 8");

	}

}

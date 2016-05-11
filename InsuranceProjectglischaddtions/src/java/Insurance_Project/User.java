/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package Insurance_Project;

import java.util.ArrayList;

/**
 *
 * @author NH228U13
 */
public class User {

    private String _username;
    private String _password;
    private String _FirstName;
    private String _LastName;
    private String _Address;
    private int _zipcode;
    private int _Social;

    private ArrayList<Role> Roles;

    public User() {

    }

    /**
     * @return the _username
     */
    public String getUsername() {
        return _username;
    }

    /**
     * @param _username the _username to set
     */
    public void setUsername(String _username) {
        this._username = _username;
    }

    /**
     * @return the _password
     */
    public String getPassword() {
        return _password;
    }

    /**
     * @param _password the _password to set
     */
    public void setPassword(String _password) {
        this._password = _password;
    }

    /**
     * @return the _FirstName
     */
    public String getFirstName() {
        return _FirstName;
    }

    /**
     * @param _FirstName the _FirstName to set
     */
    public void setFirstName(String _FirstName) {
        this._FirstName = _FirstName;
    }

    /**
     * @return the _LastName
     */
    public String getLastName() {
        return _LastName;
    }

    /**
     * @param _LastName the _LastName to set
     */
    public void setLastName(String _LastName) {
        this._LastName = _LastName;
    }

    /**
     * @return the _Address
     */
    public String getAddress() {
        return _Address;
    }

    /**
     * @param _Address the _Address to set
     */
    public void setAddress(String _Address) {
        this._Address = _Address;
    }

    /**
     * @return the _zipcode
     */
    public int getZipcode() {
        return _zipcode;
    }

    /**
     * @param _zipcode the _zipcode to set
     */
    public void setZipcode(int _zipcode) {
        this._zipcode = _zipcode;
    }

    /**
     * @return the _Social
     */
    public int getSocial() {
        return _Social;
    }

    /**
     * @param _Social the _Social to set
     */
    public void setSocial(int _Social) {
        this._Social = _Social;
    }

    /**
     * @return the Roles
     */
    public ArrayList<Role> getRoles() {
        return Roles;
    }

    /**
     * @param Roles the Roles to set
     */
    public void setRoles(ArrayList<Role> Roles) {
        this.Roles = Roles;
    }

}

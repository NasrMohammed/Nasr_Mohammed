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
public class AccessToken {
    private User _usr;
    private ArrayList<Role> roles;
    
    public AccessToken(){
                
    }

    /**
     * @return the _usr
     */
    public User getUsr() {
        return _usr;
    }

    /**
     * @param _usr the _usr to set
     */
    public void setUsr(User _usr) {
        this._usr = _usr;
    }

    /**
     * @return the roles
     */
    public ArrayList<Role> getRoles() {
        return roles;
    }

    /**
     * @param roles the roles to set
     */
    public void setRoles(ArrayList<Role> roles) {
        this.roles = roles;
    }
}

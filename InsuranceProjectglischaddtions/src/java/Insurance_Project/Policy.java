/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package Insurance_Project;

/**
 *
 * @author NH228U13
 */
public class Policy {
    private String _policyName;
    private String _policyDescription;
    private String _policyType;
    private double _policyPrice;
    
    public Policy(){
        
        
    }

    /**
     * @return the _policyName
     */
    public String getPolicyName() {
        return _policyName;
    }

    /**
     * @param _policyName the _policyName to set
     */
    public void setPolicyName(String _policyName) {
        this._policyName = _policyName;
    }

    /**
     * @return the _policyDescription
     */
    public String getPolicyDescription() {
        return _policyDescription;
    }

    /**
     * @param _policyDescription the _policyDescription to set
     */
    public void setPolicyDescription(String _policyDescription) {
        this._policyDescription = _policyDescription;
    }

    /**
     * @return the _policyType
     */
    public String getPolicyType() {
        return _policyType;
    }

    /**
     * @param _policyType the _policyType to set
     */
    public void setPolicyType(String _policyType) {
        this._policyType = _policyType;
    }

    /**
     * @return the _policyPrice
     */
    public double getPolicyPrice() {
        return _policyPrice;
    }

    /**
     * @param _policyPrice the _policyPrice to set
     */
    public void setPolicyPrice(double _policyPrice) {
        this._policyPrice = _policyPrice;
    }
    
}

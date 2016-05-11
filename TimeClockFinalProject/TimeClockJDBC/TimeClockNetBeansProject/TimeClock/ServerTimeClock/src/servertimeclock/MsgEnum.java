 /*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package servertimeclock;

/**
 *
 * @author nh228u10
 */
public enum MsgEnum {  
      /**
     * PUNCHIN punch in time for employee if employee is exist
     */
    PUNCHIN,
    /**
     * EMPID employee ID that pulled from the database
     */
    EMPID,
    /**
     * SERVERERROR error that reported if something went wrong
     */
    SERVERERROR,
    /**
     * GOOD reported if employee Id found
     */
    GOOD
}


package client;

/**
 * Enumeration class hold four type of object state
 *
 * @author Nasr
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

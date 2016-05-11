package timeclock;

import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.io.Serializable;
import java.net.InetAddress;
import java.net.Socket;
import java.net.SocketTimeoutException;
import servertimeclock.MsgEnum;

/**
 * MsgState class implements Serializable and holds 
 * instance attribute for the msgState Enumeration and
 * instance attribute for the Object Class 
 * and holds getters and setters and constructors for msgState and Object
 * @author Nasr
 */
public final class MsgState implements Serializable {
   /**
    * serialVersionUID instead of default serial version number
    * messageObject a reference to an object class
    * msgState a reference to a msgState Enumeration
    */
    private static final long serialVersionUID = 42L;
    private Employee EmployeeID;
    private MsgEnum msgEnum;

	
    /**
     * Default Constructor
     */
    public MsgState() {
    }
	
	private Socket socket = null;
	
	/**
	 * The only constructor for this class reinforces the fact that we need 
	 * a Socket to do anything.
	 * 
	 * @param socket The Socket object through which to communicate.
	 */
	public MsgState(Socket socket) {
		this.socket = socket;
	 // end constructor// end constructor
	
	/**
	 * Because we implement Runnable, we must override the run() method.  This 
	 * is the method that will perform the actual program logic.
	 */
	
		if(null != socket) {
			try {
				// display the IP address, but just for illustrative purposes,
				// Do not do this on a production machine
				InetAddress inetAddress = socket.getInetAddress();
				System.out.println("\n\tConnection from: " 
									+ inetAddress.getAddress());
                                
                                ObjectOutputStream outputStream = new
									ObjectOutputStream(socket.getOutputStream());
				
				ObjectInputStream inputStream = new 
									ObjectInputStream(socket.getInputStream());
				
									
				//double radius = inputStream.readDouble();
				
				
				if (msgEnum.EMPID == EmployeeID)
                                {
                                    
                                }
				
				//double area = radius * radius * Math.PI;
				
				//System.out.println("\tIncoming radius: " + radius 
								//+ "\n\tOutgoing area: " + area);
				
				//outputStream.writeDouble(area);
				outputStream.flush();
				
				inputStream.close();
				outputStream.close();
			} catch(SocketTimeoutException ste) {
				System.out.println("\tSocket connection timed out."
									+ "\n\tSocket process ending");
			} catch(IOException ioe) {
				System.out.println("\tIO ERROR: " + ioe.getMessage());
			} catch(Exception ex) {
				System.out.println("\tERROR: " + ex.getMessage());
			}
		} 
        }
    /**
     * Constructor takes two arguments and sets them
     *
     * @param messageObject
     * @param msgState
     */
    public MsgState(Employee EmployeeID, MsgEnum msgState) {
        setState(msgState);
        setEmployee(EmployeeID);
    }

    /**
     * Constructor takes one argument and sets it
     *
     * @param msgState
     */
    public MsgState(MsgEnum msgState) {
        setState(msgState);
    }

    /**
     * Method getter for the object
     *
     * @return messageObject
     */
    public Employee getEmployee() {
        return EmployeeID;
    }

    /**
     * Method getter for the state
     *
     * @return msgState
     */
    public MsgEnum getState() {
        return msgState;
    }

    /**
     * Setter for Object
     *
     * @param messageObject
     */
    public void setEmployee(Employee EmployeeID) {
        this.EmployeeID = EmployeeID;
    }

    /**
     * Setter for Message
     *
     * @param msgState
     */
    public void setState(MsgEnum msgState) {
        this.msgState = msgState;
    }


        
 
}

package clientserverproject;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.lang.NumberFormatException;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;


public class ClientTimeClock {
	/**
	* This is the main logic for the client program 
	*/
	public static void main(String [] args) {
		boolean keepGoing = true;
		String employeeId = null;
		
		while (keepGoing) {
			employeeId = getEmployeeID();
			if(employeeId.equalsIgnoreCase("Q")) {
				keepGoing = false;
                                System.exit(-1);
			} else {
                            // Checking if user has entered employee ID 
				 if(employeeId == null || employeeId.length() < 1) {
                                            System.out.println(" You have've enter the employeeID yet ?");    
                                        }
        
        
 
			} // end if response
		}	 // end while 
	
	} // end of main method
	
	/**
	* Create a socket, send the radius, read back the area.
	* @param radius the radius of the circle
	* @return the area of the circle
	*/
	public static String getEmployeeFromServer(String employee) throws 
		UnknownHostException, IOException{
		Socket socket = new Socket("localhost", 5555);
                
		ObjectOutputStream outputStream = new 
				ObjectOutputStream(socket.getOutputStream());
		
                ObjectInputStream inputStream = new 
				ObjectInputStream(socket.getInputStream());
		
				
		outputStream.writeObject(employee);
		outputStream.flush();
                
                
		
		//double area = inputStream.readDouble();
		
		outputStream.close();
		inputStream.close();
		return employee;
	} // end of getAreaFromServer method
	
	/**
	* Prompts user for the radius of the a circle of Q to quit
	* @param String entered by the user
	*/
	public static String getEmployeeID() {
		System.out.println("\nEnter the employeeID to punch-in , or \"Q\" to quit: ");
		Scanner input = new Scanner(System.in);
		return input.nextLine();
		
	} // end method getChoice
} // end class Client 
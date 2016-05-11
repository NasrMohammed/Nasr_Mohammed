/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package client;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.lang.NumberFormatException;
import java.net.Socket;
import java.net.UnknownHostException;
import java.util.Scanner;

/**
 *
 * @author Nasr
 * The client class responsible for getting the user input and 
 * send message to the server, the message has an object  
 */
public class Client {

    /**
     * The main logic of the program
     *
     * @param args
     * @throws java.lang.ClassNotFoundException
     */
    public static void main(String[] args) throws ClassNotFoundException {

        boolean keepGoing = true;
        String response = null;

        while (keepGoing) {
            response = getChoice();
            if (response.equalsIgnoreCase("Q")) {
                keepGoing = false;
            } else {
                try {
                    MessageState msgS = new MessageState();
                    msgS.setState(MsgEnum.PUNCHIN);
                    msgS.setMessageContent(response);

                    MessageState msgFromServer = getEmployeeFromServer(msgS);

                    System.out.println("Employee ID from server: " + msgFromServer);
                } catch (UnknownHostException uhe) {
                    System.out.println("ERROR: There was an error connecting"
                            + " to the server.\nThis is a catastrophic "
                            + "error and the program must terminate.");
                    System.out.println(uhe.getMessage());
                    System.exit(-1);
                } catch (IOException ioe) {
                    System.out.println("ERROR: There was an error reading "
                            + "or writing values.\n"
                            + "You can try again or quit the program.");
                } catch (NumberFormatException nfe) {
                    System.out.println("\nSorry, the value you entered could not "
                            + " be interpretted as a number.");
                    System.out.println("Please try again.");
                }
            }
        } // end if reponse
    } // end while
    // end method main()

    /**
     * Creates a socket, connects to the server and sends the radius. Then it
     * reads the value returned from the server.
     *
     * @param msgS
     * @return The area of the circle.
     * @throws java.net.UnknownHostException
     * @throws java.lang.ClassNotFoundException
     */
    public static MessageState getEmployeeFromServer(MessageState msgS) throws
            UnknownHostException, IOException, ClassNotFoundException {
        Socket socket = new Socket("localhost", 5555);

        ObjectInputStream inputStream = new ObjectInputStream(socket.getInputStream());

        ObjectOutputStream outputStream = new ObjectOutputStream(socket.getOutputStream());
        outputStream.writeObject(msgS);
        outputStream.flush();
        MessageState empId = (MessageState) inputStream.readObject();

        switch (empId.getState()) {
            case PUNCHIN:
                System.out.println("Punch-in successful");
                break;
            case EMPID:
                System.out.println("Employee Found ");
                break;

            case SERVERERROR:
                System.out.println("CATASTROPHIC FAILURE: Server stopping.\n");
                break;
            case GOOD:
                System.out.println("System has found your info, please wait....");
                break;
        }

        return msgS;
    } // end method getEmployeeFromServer()

    /**
     * Prompts the user for the employee id, or Q to quit. Returns the string
     * typed by the user.
     *
     * @return String entered by the user
     */
    public static String getChoice() {
        System.out.println("\nEnter the employee ID , or \"Q\" to quit:");
        Scanner input = new Scanner(System.in);
        return input.nextLine();
    }

    /**
     * Displays the usage information for the user.
     */
    public static void showUsage() {
        System.out.println("USAGE: java TimeClock <employee ID>");
    }

    /**
     * There was no employee ID provided, so show an error message and the usage
     * information
     */
    public static void showError() {
        System.out.println("ERROR: No employee ID was provided.");
        showUsage();
    }

}

package server;

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.IOException;
import java.io.ObjectInputStream;
import java.io.ObjectOutputStream;
import java.net.InetAddress;
import java.net.Socket;
import java.net.SocketTimeoutException;
import java.sql.SQLException;

public class RequestHandler implements Runnable {

    private static final String dbUrl = "localhost";
    private static final String dbName = "timeclock";
    private static final String dbUserName = "timeclockuser";
    private static final String dbPassword = "password_1234";
    
                EmployeeDAO employeeDao = new EmployeeDAO();
                employeeDao.setDbUrl(dbUrl);
                employeeDao.setDbName(dbName);
                employeeDao.setDbUserName(dbUserName);
                employeeDao.setDbUserPassword(dbPassword);

                Employee employee = null;

                try {
                    employee = employeeDao.getEmployeeById(employeeId);

                } catch (SQLException | ClassNotFoundException ex) {
                     MessageState msgS = new MessageState();
                     msgS.setState(MsgEnum.SERVERERROR);
                }
                if (employee != null) {
                    // save time stamp
                    TimePunchDAO timePunchDao = new TimePunchDAO();
                    timePunchDao.setDbUrl(dbUrl);
                    timePunchDao.setDbName(dbName);
                    timePunchDao.setDbUserName(dbUserName);
                    timePunchDao.setDbUserPassword(dbPassword);
                    try {
                        timePunchDao.recordTimePunch(employee, "TimeClock");
                        MessageState msgS = new MessageState();
                         msgS.setState(MsgEnum.SERVERERROR);
                    } catch (SQLException ex) {
                         MessageState msgS = new MessageState();
                         msgS.setState(MsgEnum.SERVERERROR);
                    }
                } else {
                     MessageState msgS = new MessageState();
                     msgS.setState(MsgEnum.SERVERERROR);
                }

                System.out.println("Program complete.");
    /**
     * The RequestHandler requires a Socket or it has now way of determining
     * what to do or how to respond
     */
    private Socket socket = null;

    /**
     * The only constructor for this class requires a Socket.
     *
     * @param socket The Socket object through which to communicate.
     */
    public RequestHandler(Socket socket) {
        this.socket = socket;
    } // end constructor 

    /**
     * Because we implement Runnable, we must override the run() method This is
     * where we perform the actual program logic.
     */
    @Override
    public void run() {
        if (null != socket) {
            try {
                // Display the IP address 
                InetAddress inetAddress = socket.getInetAddress();
                System.out.println("\n\tConnection from: "
                        + inetAddress.getAddress());

                // Get the streams for reading and writing 
                ObjectInputStream inputStream = new ObjectInputStream(socket.getInputStream());
                ObjectOutputStream outputStream = new ObjectOutputStream(socket.getOutputStream());
                MessageState empId = (MessageState) inputStream.readObject();

               

                switch (empId.getState()) {
                    case PUNCHIN:
                        outputStream.writeObject(empId);
                        outputStream.flush();
                        break;
                    case EMPID:

                        break;

                    case SERVERERROR:

                        break;
                    case GOOD:

                        break;
                }

                inputStream.close();
                outputStream.close();

            } catch (SocketTimeoutException ste) {
                System.out.println("\tSocket connection timed out."
                        + "\n\tSocket process ending.");
            } catch (IOException ioe) {
                System.out.println("\tIO ERROR: " + ioe.getMessage());
            } catch (Exception ex) {
                System.out.println("\tERROR: " + ex.getMessage());
            }
        } // end if socket not null
    }
} // end class RequestHandler

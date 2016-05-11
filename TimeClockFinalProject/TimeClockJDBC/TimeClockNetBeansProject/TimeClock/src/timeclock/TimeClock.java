package timeclock;

import timeclock.mohammed.data.DatabaseType;
import timeclock.mohammed.employee.Employee;
import timeclock.mohammed.employee.EmployeeDAO;
import timeclock.mohammed.timepunch.TimePunchDAO;
import java.sql.SQLException;
import java.util.HashSet;

/**
 *
 * @author Nasr
 */
public class TimeClock {

    private static final String dbUrl = "localhost";
    private static final String dbName = "timeclock";
    private static final String dbUserName = "timeclockuser";
    private static final String dbPassword = "password_1234";
    
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) throws ClassNotFoundException {
        
        
        /**
         * Make sure there is an employee ID
         */
        if(args == null || args.length < 1) {
            showError();
            System.exit(-1);
        }
        
        /**
         * See if the user requested usage information
         */
        if("-?".equals(args[0])  || "-h".equals(args[0])  || "-help".equals(args[0]) ){
            showUsage();
            System.exit(0);
        }
        
        /**
         * Set the employeeId to the value in args[0]
         */
        String employeeId = args[0];
        
        EmployeeDAO employeeDao = new EmployeeDAO();
        employeeDao.setDbUrl(TimeClock.dbUrl);
        employeeDao.setDbName(TimeClock.dbName);
        employeeDao.setDbUserName(TimeClock.dbUserName);
        employeeDao.setDbUserPassword(TimeClock.dbPassword);
        
        Employee employee = null;
        
        try {
            employee = employeeDao.getEmployeeById(employeeId);
        
        } catch(SQLException | ClassNotFoundException ex) {
            System.out.println("ERROR: Something went wrong whhile getting the"
                                +" employee data.\n" 
                                + ex.getMessage());
            System.out.println("Program ending.");
            System.exit(-1);
        }
        if(employee != null) {
            // save time stamp
            TimePunchDAO timePunchDao = new TimePunchDAO();
            timePunchDao.setDbUrl(TimeClock.dbUrl);
            timePunchDao.setDbName(TimeClock.dbName);
            timePunchDao.setDbUserName(TimeClock.dbUserName);
            timePunchDao.setDbUserPassword(TimeClock.dbPassword);
            try{
                timePunchDao.recordTimePunch(employee, "TimeClock");
                System.out.println("Time punch recorded for " + employeeId + ".");
            } catch(SQLException ex){
                System.out.println("ERROR: Something went wrong while recording"
                                    + " the time punch record.\n" 
                                    + ex.getMessage());
            }
        } else {
            System.out.println("The employee ID (" + employeeId  
                                                + ") was not found.");
        }
        
        System.out.println("Program complete.");
        
    }
    
    /**
     * Displays the usage information for the user.
     */
    public static void showUsage() {
        System.out.println("USAGE: java TimeClock <employee ID>");
    }
    
    /**
     * There was no employee ID provided, so show an error message and the 
     * usage information
     */
    public static void showError() {
        System.out.println("ERROR: No employee ID was provided.");
        showUsage();
    }
    
}

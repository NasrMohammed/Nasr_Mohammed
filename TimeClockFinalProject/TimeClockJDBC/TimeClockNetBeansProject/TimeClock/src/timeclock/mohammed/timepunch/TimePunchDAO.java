package timeclock.mohammed.timepunch;

//import static com.sun.org.apache.xalan.internal.lib.ExsltDatetime.date;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.util.ArrayList;
import timeclock.mohammed.data.DatabaseConnectionFactory;
import timeclock.mohammed.data.DatabaseType;
import timeclock.mohammed.employee.Employee;
import java.util.Date;
import java.text.DateFormat;
import java.sql.SQLException;
import java.text.SimpleDateFormat;
/**
 * The TimePunch Data Access Object handles persistent storage of data related
 * to TimePunch objects.
 *
 * @author Nasr
 */
public class TimePunchDAO {

    /**
     * The URL for the database holding the Employee data.
     */
    private String dbUrl;

    /**
     * The name of the database holding the Employee data.
     */
    private String dbName;

    /**
     * The database user name to use when connecting to the database.
     */
    private String dbUserName;

    /**
     * The password for the database user.
     */
    private String dbUserPassword;

    /**
     * Records a time punch with the specified employeeId and source, using the
     * current time.
     *
     * @param employeeId
     * @param source
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    public void recordTimePunch(String employeeId, String source)
            throws SQLException, ClassNotFoundException {
        
        java.util.Date myDate = new java.util.Date();
        String stringDate = new SimpleDateFormat("yyyy-MM-dd").format(myDate);
        
        //TimePunch time = null;
            
        dbName = "timeclock";
        dbUserName = "timeclockuser";
        dbUserPassword = "password_1234";

        Connection conn = null;
        DatabaseConnectionFactory factory = DatabaseConnectionFactory.getInstance();
        conn = factory.getConnection(DatabaseType.MYSQL, dbName, dbUserName, dbUserPassword);

        String queryString = "{call sp_RecordTimePunch(?,? ,?)}";

        CallableStatement callableStatement = conn.prepareCall(queryString);
        
        //sql start counting from 1
        callableStatement.setString(1, employeeId);
        callableStatement.setString(2,stringDate);
        callableStatement.setString(3, source);

        callableStatement.executeQuery();


       /* if (resultSet.next()) {
            //time = new TimePunch();

            String employeeID = time.getEmployeeId();
            Date punchTime = time.getPunchTime();
            String empSource = time.getSource();
            
            //System.out.println("The time is" + employeeID + punchTime + empSource);
        }*/
        conn.close();

    }

    /**
     * Records a time punch with the specified Employee and source, using the
     * current time.
     *
     * @param employee
     * @param source
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    //java.util.Date myDate = new java.util.Date();
       //java.sql.Date dateNow = new java.sql.Date(myDate.getTime()- 1000);
        //TimePunch time = null;
    public void recordTimePunch(Employee employee, String source)
            throws SQLException, ClassNotFoundException {

        
        //String stringDate = new SimpleDateFormat("yyyy-MM-dd").format(dateNow);
       // java.util.Date today = new java.
       DateFormat dateFormat = new SimpleDateFormat("yyyy/MM/dd HH:mm:ss");
       Date stringDate = new Date();
    
        dbName = "timeclock";
        dbUserName = "timeclockuser";
        dbUserPassword = "password_1234";

        Connection conn = null;
        DatabaseConnectionFactory factory = DatabaseConnectionFactory.getInstance();
        conn = factory.getConnection(DatabaseType.MYSQL, dbName, dbUserName, dbUserPassword);

        String queryString = "{call sp_RecordTimePunch(?,? ,?)}";

        CallableStatement callableStatement = conn.prepareCall(queryString);
        
        //sql start counting from 1
        callableStatement.setString(1, employee.getEmployeeId());
        callableStatement.setString(2,dateFormat.format(stringDate));
        callableStatement.setString(3, source);

        callableStatement.executeQuery();
        
        conn.close();
        
    }

    /**
     * Marks a time punch record as invalid.
     *
     * @param employeeId
     * @param punchTime
     * @param invalidatedBy
     * @param invalidatedReason
     * @throws java.sql.SQLException
     */
    public void invalidateTimePunch(String employeeId, Date punchTime, String invalidatedBy, String invalidatedReason)
            throws SQLException {

    }

    /**
     * Returns a list of the time punch records between start and end dates.
     *
     * @param startDate
     * @param endDate
     * @return
     * @throws SQLException
     */
    public ArrayList<TimePunch> getTimePunchsByDateRange(Date startDate, Date endDate) throws SQLException {
        return null;
    }

    /**
     * Returns a list of the time punch records between start and end dates.
     *
     * @param startDate
     * @param endDate
     * @return
     * @throws SQLException
     */
    public ArrayList<TimePunch> getTimePunchsByDateRange(String startDate, String endDate) throws SQLException {
        return null;
    }

    /**
     * Returns a list of the time punch records between start and end dates for
     * the specified employee.
     *
     * @param employee
     * @param startDate
     * @param endDate
     * @return
     * @throws SQLException
     */
    public ArrayList<TimePunch> getTimePunchsByEmployeeDateRange(
            Employee employee, Date startDate, Date endDate) throws SQLException {
        return null;
    }

    /**
     * Returns a list of the time punch records between start and end dates for
     * the specified employee ID.
     *
     * @param employeeId
     * @param startDate
     * @param endDate
     * @return
     * @throws SQLException
     */
    public ArrayList<TimePunch> getTimePunchsByEmployeeDateRange(
            String employeeId, String startDate, String endDate) throws SQLException {
        return null;
    }

    /**
     * The URL for the database holding the Employee data.
     *
     * @return the dbUrl
     */
    public String getDbUrl() {
        return dbUrl;
    }

    /**
     * The URL for the database holding the Employee data.
     *
     * @param dbUrl the dbUrl to set
     */
    public void setDbUrl(String dbUrl) {
        this.dbUrl = dbUrl;
    }

    /**
     * The name of the database holding the Employee data.
     *
     * @return the dbName
     */
    public String getDbName() {
        return dbName;
    }

    /**
     * The name of the database holding the Employee data.
     *
     * @param dbName the dbName to set
     */
    public void setDbName(String dbName) {
        this.dbName = dbName;
    }

    /**
     * The database user name to use when connecting to the database.
     *
     * @return the dbUserName
     */
    public String getDbUserName() {
        return dbUserName;
    }

    /**
     * The database user name to use when connecting to the database.
     *
     * @param dbUserName the dbUserName to set
     */
    public void setDbUserName(String dbUserName) {
        this.dbUserName = dbUserName;
    }

    /**
     * The password for the database user.
     *
     * @return the dbUserPassword
     */
    public String getDbUserPassword() {
        return dbUserPassword;
    }

    /**
     * The password for the database user.
     *
     * @param dbUserPassword the dbUserPassword to set
     */
    public void setDbUserPassword(String dbUserPassword) {
        this.dbUserPassword = dbUserPassword;
    }

}

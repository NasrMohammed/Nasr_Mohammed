package server;

import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;
import java.util.ArrayList;
import server.DataConnectorBuilder;
import server.DataConnectorBuilderMySQL;
import server.DatabaseConnectionFactory;
import server.DatabaseType;

/**
 * The Employee Data Access Object handles persistent storage of data related to
 * Employee objects.
 */
public class EmployeeDAO {
    /* {author=Bob Trapp, version=1.0}*/

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
     * Creates an employee record in the database.
     *
     * @param employee
     * @throws java.sql.SQLException
     */
    public void createEmployee(Employee employee)
            throws SQLException, ClassNotFoundException {
        dbName = "timeclock";
        dbUserName = "timeclockuser";
        dbUserPassword = "password_1234";
        DatabaseConnectionFactory factory = DatabaseConnectionFactory.getInstance();
        Connection conn = factory.getConnection(DatabaseType.MYSQL, dbName, dbUserName, dbUserPassword);

    }

    /**
     * Returns an employee record based on the employee ID.
     *
     * @param employeeID
     * @return
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    public Employee getEmployeeById(String employeeID)
            throws SQLException, ClassNotFoundException {

        // Employee emp = new Employee();
        Employee emp = null;
        dbName = "timeclock";
        dbUserName = "timeclockuser";
        dbUserPassword = "password_1234";

        Connection conn = null;
        DatabaseConnectionFactory factory = DatabaseConnectionFactory.getInstance();
        conn = factory.getConnection(DatabaseType.MYSQL, dbName, dbUserName, dbUserPassword);

        String queryString = "{call sp_GetEmployee(?)}";

        CallableStatement callableStatement = conn.prepareCall(queryString);

        //sql start counting from 1
        callableStatement.setString(1, employeeID);

        ResultSet resultSet = callableStatement.executeQuery();

        if (resultSet.next()) {
            emp = new Employee();
           emp.setEmployeeId(resultSet.getString(1));   
           emp.setLastName(resultSet.getString(2));
           emp.setFirstName(resultSet.getString(3)); 
           emp.setStartDate(resultSet.getDate(5)); 
           emp.setTermDate(resultSet.getDate(6)); 
            // System.out.println(employeeId + ": " + lastName
            //    + ", " + firstName + ": " + departmentId);
        }
        conn.close();
        return emp;
    }

    /**
     * Returns a collection of Employees in the database that are assigned to
     * the specified department ID.
     *
     * @param departmentId
     * @return
     * @throws java.sql.SQLException
     */
    public ArrayList<Employee> getEmployeesByDepartmentId(String departmentId)
            throws SQLException {

        return null;
    }

    /**
     * Returns a collection of all Employees in the database.
     *
     * @return
     * @throws java.sql.SQLException
     */
    public ArrayList<Employee> getEmployees()
            throws SQLException {
        return null;
    }

    /**
     * Uses the data in the Employee object to update the associated record in
     * the database
     *
     * @param employee
     * @throws java.sql.SQLException
     */
    public void updateEmployee(Employee employee)
            throws SQLException {
    }

    /**
     * Removes the Employee record from the database.
     *
     * @param employee
     * @throws java.sql.SQLException
     */
    public void deleteEmployee(Employee employee)
            throws SQLException {
    }

    /**
     * Removes the associated Employee record from the database.
     *
     * @param employeeId
     * @throws java.sql.SQLException
     */
    public void deleteEmployee(String employeeId)
            throws SQLException {
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

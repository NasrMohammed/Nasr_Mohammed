package timeclock.mohammed.data;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

/**
 * This utility class extends the DataConnectorBuilder interface but only for
 * the MySQL databases.
 *
 * @author Nasr
 */
public class DataConnectorBuilderMySQL implements DataConnectorBuilder {

    /**
     *
     * @param databaseName The name of the database to which to connect
     * @param userName The name of the user allowed to connect
     * @param password The password of the database user
     * @return A SQL Connection object
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    public Connection getConnection(String databaseName, String userName, String password) throws SQLException, ClassNotFoundException, IllegalArgumentException {

        Connection conn = null;

        Class.forName("com.mysql.jdbc.Driver");
        conn = DriverManager.getConnection("jdbc:mysql://localhost/" + databaseName + "?noAccessToProcedureBodies=true", userName, password);

        return conn;
    }

    /**
     *
     * @param databaseUrl The URL for the host of the DBMS
     * @param databaseName The name of the database to which to connect
     * @param userName The name of the user allowed to connect
     * @param password The password of the database user
     * @return A SQL Connection object
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    public Connection getConnection(String databaseUrl, String databaseName, String userName, String password)
            throws SQLException, ClassNotFoundException, IllegalArgumentException {
        Connection conn = null;

        Class.forName("com.mysql.jdbc.Driver");
        conn = DriverManager.getConnection("jdbc:mysql://" + databaseUrl + "/" + databaseName, userName, password);

        return conn;
    }

    /**
     *
     * @param databaseUrl The URL for the host of the DBMS
     * @param databasePort The port for the DBMS on its host
     * @param databaseName The name of the database to which to connect
     * @param userName The name of the user allowed to connect
     * @param password The password of the database user
     * @return A SQL Connection object
     * @throws java.sql.SQLException
     * @throws java.lang.ClassNotFoundException
     */
    public Connection getConnection(String databaseUrl, Integer databasePort, String databaseName, String userName, String password) throws SQLException, ClassNotFoundException, IllegalArgumentException {
        Connection conn = null;

        Class.forName("com.mysql.jdbc.Driver");
        conn = DriverManager.getConnection("jdbc:mysql://" + databaseUrl + ":" + databasePort + "/" + databaseName, userName, password);

        return conn;
    }

}

package Insurance.DataBase;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

/**
 * Provides a convenient way to get a database Connection for the appropriate 
 * database.  Note that this uses the Singleton pattern.
 * 
 * @author Bob
 */
public class DatabaseConnectionFactory {

    /** 
     *  This is the current instance of the DatabaseConnectionFactory.  It is 
     * held here as part of the Singleton pattern.
     */
    private static DatabaseConnectionFactory instance;


    /** 
     * Instead of instantiating a new instance of the DatabaseConnectionFactory, 
     * client objects will use the getInstance() method to get access to the 
     * only instance of this object.
     * 
     * @return 
     */
    public static  DatabaseConnectionFactory getInstance() {
        if(null == instance){
            instance = new DatabaseConnectionFactory();
        }
        
        return instance;
    }
    /** 
     * Note that the constructor for DatabaseConnectionFactory is private.  
     * Nothing outside of the class can instantiate one.  Instead, the first 
     * time something calls the getInstance() method, it will determine whether 
     * an instance must be instantiated and will take care of doing so.
     */
    private DatabaseConnectionFactory() {
    }

    /** 
     * The simplest form of this method, assumes that it should use default 
     * values for the type of database.
     * @param databaseType
     * @param databaseName
     * @param userName
     * @param password
     * @return 
     */
    public static  Connection getConnection(DatabaseType databaseType, String databaseName
                                            , String userName, String password) throws SQLException
                                                                                , ClassNotFoundException , IllegalArgumentException{
        Connection conn = null;   
        if(databaseType == DatabaseType.MYSQL){
               DataConnectorBuilderMySQL mySQL = new DataConnectorBuilderMySQL();
               conn = mySQL.getConnection(databaseName, userName, password);               
           }
        
        
            return conn;
      
        
    }

    /**
     * 
     * @param databaseType
     * @param databaseUrl
     * @param databaseName
     * @param userName
     * @param password
     * @return 
     */
    public Connection getConnection(DatabaseType databaseType, String databaseUrl
                    , String databaseName, String userName, String password)throws SQLException, ClassNotFoundException , IllegalArgumentException{
        Connection conn = null;   
        if(databaseType == DatabaseType.MYSQL){
               DataConnectorBuilderMySQL mySQL = new DataConnectorBuilderMySQL();
               conn = mySQL.getConnection(databaseUrl,databaseName, userName, password);               
           }
        
        
            return conn;
    }

    /**
     * 
     * @param databaseType
     * @param databaseUrl
     * @param dataabasePort
     * @param databaseName
     * @param userName
     * @param password
     * @return 
     */
    public Connection getConnection(DatabaseType databaseType, String databaseUrl
                    , Integer dataabasePort, String databaseName, String userName
                    , String password) {
        return null;
    }

}

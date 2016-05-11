/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

package InsuranceDAO;

import Insurance.DataBase.DatabaseConnectionFactory;
import Insurance.DataBase.DatabaseType;
import Insurance_Project.User;
import java.sql.CallableStatement;
import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.HashSet;
import java.util.Set;

/**
 *
 * @author NH228U16
 */
public class WebsiteDAO {
 
     /**
     * The URL for the database holding the Employee data.
     */
    private String dbUrl;//= "jdbc:mysql://localhost/"
    
    /**
     * The name of the database holding the Employee data.
     */
    private String dbName;//= "InsuranceDB"
    
    /**
     * The database user name to use when connecting to the database.
     */
    private String dbUserName; //= "timeclockuser"
    
    /**
     * The password for the database user.
     */
    private String dbUserPassword;//= "password_1234"
    
    public User logInCheck(String Username, String Password) throws SQLException, ClassNotFoundException{
        User usr = null;
        
        
           DatabaseConnectionFactory connectionFactory = DatabaseConnectionFactory.getInstance();
           Connection conn = connectionFactory.getConnection(DatabaseType.MYSQL,dbUrl, dbName, dbUserName,dbUserPassword);     
           CallableStatement cs = conn.prepareCall("{call SP_GetUser_By_Username(?)}");            
           cs.setString(1, Username);// setting the input param for our stored procedure
           cs.setString(2, Password);
           
           ResultSet resultSet = cs.executeQuery();
            /** looping through the results set if an employee was returned and prompting the user if one was not returned */
            if(!resultSet.isBeforeFirst()){ 
               
                return usr;
                
            }else{                
                 /** loop for getting employee information that was returned by the stored procedure */
                while(resultSet.next()){
                    usr.setUsername(resultSet.getString(0));
                    usr.setFirstName(resultSet.getString(1));
                    usr.setLastName(resultSet.getString(2));
                    usr.setAddress(resultSet.getString(3));
                    
                }
            }
        
         return usr;
}
    
    public boolean CreateUserInDB(User usr) throws SQLException, ClassNotFoundException{
         
        DatabaseConnectionFactory connectionFactory = DatabaseConnectionFactory.getInstance();
        Connection conn = connectionFactory.getConnection(DatabaseType.MYSQL,dbUrl, dbName, dbUserName,dbUserPassword);     
        CallableStatement cs = conn.prepareCall("{call SP_AddUser(?)}");          
        cs.setString(1, usr.getFirstName());
        cs.setString(2, usr.getUsername());
        cs.setString(3, usr.getLastName());
        cs.setString(4, usr.getAddress());
        cs.setString(5, usr.getPassword());
        
        ResultSet resultSet = cs.executeQuery();
        return resultSet.isBeforeFirst();
        
    }
    
    
     public boolean addUserPolicy(String Username, String Policy) throws SQLException, ClassNotFoundException{
         
        DatabaseConnectionFactory connectionFactory = DatabaseConnectionFactory.getInstance();
        Connection conn = connectionFactory.getConnection(DatabaseType.MYSQL,dbUrl, dbName, dbUserName,dbUserPassword);     
        CallableStatement cs = conn.prepareCall("{call SP_AddUserPolicy(?)}");         
        cs.setString(1, Username);// setting the input param for our stored procedure
        cs.setString(2, Policy);
        
        ResultSet resultSet = cs.executeQuery();
        return resultSet.isBeforeFirst();
        
        
    }
    
    
    
    
    
    
    
    
    
    
    
    
    /**
     * Returns an employee record based on the employee ID.
     *
     * @param employeeId
     * @return
     * @throws java.sql.SQLException
     */
//    public Employee getEmployeeById(String employeeId) 
//                                throws SQLException{
//        Employee resultEmp = new Employee();
//        String empID = employeeId;
//        try{
//            DatabaseConnectionFactory connectionFactory = DatabaseConnectionFactory.getInstance();
//            Connection conn = connectionFactory.getConnection(DatabaseType.MYSQL,dbUrl, dbName, dbUserName,dbUserPassword);                    
//            CallableStatement cs = conn.prepareCall("{call sp_GetEmployee(?)}");            
//            cs.setString(1, empID);// setting the input param for our stored procedure
//            
//            ResultSet resultSet = cs.executeQuery();
//            /** looping through the results set if an employee was returned and prompting the user if one was not returned */
//            if(!resultSet.isBeforeFirst()){ 
//                System.out.println("found nothing");
//                
//            }else{                
//                 /** loop for getting employee information that was returned by the stored procedure */
//                while(resultSet.next()){
//                  resultEmp.setEmployeeId(resultSet.getString(1));
//                   
//                   resultEmp.setLastName( resultSet.getString(2));
//                   // this if statment is used to check for nulls in the last column read by the result set
//                   if(resultSet.wasNull()){
//                       resultEmp.setLastName(""); 
//                   }
//                   resultEmp.setFirstName(resultSet.getString(3));
//                   // this if statment is used to check for nulls in the last column read by the result set
//                   if(resultSet.wasNull()){
//                      resultEmp.setFirstName("");
//                   }
//                   resultEmp.setDepartment(resultSet.getString(4));
//                   // this if statment is used to check for nulls in the last column read by the result set
//                   if(resultSet.wasNull()){
//                      resultEmp.setDepartment("");
//                   }
//                   resultEmp.setStartDate(resultSet.getDate(5));
//                   
//                   resultEmp.setTermDate(resultSet.getDate(6));
//                   // this if statment is used to check for nulls in the last column read by the result set
//                   if(resultSet.wasNull()){
//                      resultEmp.setTermDate(null);                      
//                   }
//                   
//                }
//            }
//        }
//        catch(Exception ex){
//           ex.getMessage();
//        }
//        
//       return resultEmp;
//        
//    }
}

package Insurance_Project;

/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletException;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import InsuranceDAO.WebsiteDAO;

/**
 *
 * @author NH228U03
 */
public class RequestHandler extends HttpServlet {

    AccessToken at = null;
    /**
     * Processes requests for both HTTP <code>GET</code> and <code>POST</code>
     * methods.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    protected void processRequest(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        
        /// if logging in get info and send it to log in method
        if(null != request.getParameter("username") && null != request.getParameter("password")){
            String username = request.getParameter("username");
            String password = request.getParameter("password");
            at.setUsr(processLogin(username,password,request,response));
            
//            if(null !=at.getUsr()){
//                getRolesForUser(at);
//            }
        }else /// if trying to create account check for null feilds, build user object and pass to create account method 
            if(null != request.getParameter("firstName") && null != request.getParameter("lastName") && null != request.getParameter("userName")){
            User usr = new User();
            String password = request.getParameter("password");
            String password1 = request.getParameter("password2");
            if(password.equals(password1)){
                usr.setFirstName(request.getParameter("firstName"));
                usr.setLastName(request.getParameter("lastName"));
                usr.setPassword(password);
                usr.setUsername(request.getParameter("userName"));
                if(request.getParameter("social") != null){
                    int social;
                    try{
                        social = Integer.parseInt(request.getParameter("social"));
                    }
                    catch(NumberFormatException nfe){
                        social = 0;
                    }
                    usr.setSocial(social);
                }
                if(null != request.getParameter("address")){
                    usr.setAddress(request.getParameter("address"));
                }
                if(null != request.getParameter("zip")){
                    int zip;
                    try{
                        zip = Integer.parseInt(request.getParameter("zip"));
                    }
                    catch(NumberFormatException nfe){
                        zip = 0;
                    }
                    usr.setZipcode(zip);
                }
                createAccount(usr, request, response);
                
            }
        }else if(null != request.getParameter("Policy")){
                AddUserPolicy(at.getUsr(), request.getParameter("Policy"),request,response);
        }
        
        String nextLocation = null;

        String nextLocationText = request.getParameter("task");

        switch (nextLocationText) {
            case "verifyAccount":
                nextLocation = "/VerifyAccount.jsp";
                break;
            case "addPolicies":
                nextLocation = "/AddPolicies.jsp";
                break;
            case "LogIn":
                nextLocation = "/LogIn.jsp";
                break;
            case "createAccount":
                nextLocation = "/CreateAccount.jsp";
                break;
            case "policies":
                nextLocation = "/Policies.jsp";
                break;
            default:
                nextLocation = "/index.jsp";
        }
        
        if(nextLocation.equals("/Policies.jsp")){
            Policy policy = new Policy();
            request.setAttribute("policy", policy);
            request.getRequestDispatcher(nextLocation).forward(request,response);
        }else if(nextLocation.equals("/CreateAccount.jsp")){
            User user = new User();
            request.setAttribute("user", user);
            request.getRequestDispatcher(nextLocation).forward(request,response);
        }else {
            request.getRequestDispatcher(nextLocation).forward(request,response);
        }
        
    }

// <editor-fold defaultstate="collapsed" desc="HttpServlet methods. Click on the + sign on the left to edit the code.">
/**
 * Handles the HTTP <code>GET</code> method.
 *
 * @param request servlet request
 * @param response servlet response
 * @throws ServletException if a servlet-specific error occurs
 * @throws IOException if an I/O error occurs
 */
@Override
        protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
    }

    /**
     * Handles the HTTP <code>POST</code> method.
     *
     * @param request servlet request
     * @param response servlet response
     * @throws ServletException if a servlet-specific error occurs
     * @throws IOException if an I/O error occurs
     */
    @Override
        protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        processRequest(request, response);
        
        
        
    }

    /**
     * Returns a short description of the servlet.
     *
     * @return a String containing servlet description
     */
    @Override
        public String getServletInfo() {
        return "Short description";
    }// </editor-fold>

        
    private User processLogin(String username, String password, HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        WebsiteDAO wda = new WebsiteDAO();
        User usr = null;
        try{
            usr = wda.logInCheck(username, password);
        }catch(Exception ex){
            request.getRequestDispatcher("/LogIn.jsp").forward(request,response);
        }
        return usr;
    }
    
        
    private boolean createAccount(User usr, HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        WebsiteDAO wda = new WebsiteDAO();
        try{
            return wda.CreateUserInDB(usr);
        }catch(Exception ex){
            request.getRequestDispatcher("/CreateAccount.jsp").forward(request,response);
        }
        return false;
    }
    

    private void getRolesForUser(AccessToken at) {
        throw new UnsupportedOperationException("Not supported yet."); //To change body of generated methods, choose Tools | Templates.
    }

    private void AddUserPolicy(User usr, String Policy, HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        String Username = usr.getUsername();
        String policy = Policy;       
        WebsiteDAO wda = new WebsiteDAO();
        try{
            wda.addUserPolicy(Username, policy);
        }catch(Exception ex){
            request.getRequestDispatcher("/Policies.jsp").forward(request,response);            
        }        
    }

}

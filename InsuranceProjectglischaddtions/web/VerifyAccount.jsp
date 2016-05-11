<%-- 
    Document   : VerifyAccount
    Created on : Apr 26, 2016, 1:50:05 PM
    Author     : nh228u19
--%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="wrapper4">
    <div id="createAccount">
        <h1>Verify Account!</h1>
        <form action="index.jsp" method="Post">
            <p>Please enter your first name</p>
            <input type="text" name="firstName">
            <br>
            <p>Please enter your last name</p>
            <input type="text" name="firstName">
            <br>
            <p>Please enter your Social Security</p>
            <input type="text" name="socialSecurity">    
            <br><br>
            <input type="submit" value="submit">
        </form>
    </div>
    </div>
</body>
<jsp:include page="includes/pagebottom.html"/>
</html>

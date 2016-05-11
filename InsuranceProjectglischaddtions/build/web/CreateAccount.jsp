<%-- 
    Document   : CreateAccount
    Created on : Apr 21, 2016, 1:00:44 PM
    Author     : NH228U03
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="wrapper4">
        <div id="createAccount">
            <form action="index.jsp" method="Post"><!--Action and method to be determined-->
                <p>Please enter your first name</p>
                <input type="text" name="firstName">
                <br>
                <p>Please enter your last name</p>
                <input type="text" name="lastName">
                <br>
                <p>Please enter your desired username</p>
                <input type="text" name="userName">
                <br>
                <p>Please enter your desired password</p>
                <input type="password" name="password">
                <br>
                <p>Re-type password</p>
                <input type="password" name="password2">
                <br>
                <p>Please enter your address</p>
                <input type="text" name="address">                
                <br>
                <p>Please enter your zip code</p>
                <input type="text" name="zip"> 
                <p>Please enter your Social Security Number</p>
                <input type="text" name="social">
                <br><br>
                <input type="submit" value="submit">
            </form>
        </div>
    </div>
</body>
<jsp:include page="includes/pagebottom.html"/>
</html>

<%-- 
    Document   : LogIn
    Created on : Apr 21, 2016, 1:00:20 PM
    Author     : NH228U03
--%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="wrapper3">
        <div id="login">
            <h1>Please Log in to your account</h1>
            <br>
            <form action="index.jsp" method="Post"> 
                <p>Please enter your user name</p>
                <input type="text" name="username">
                <br>
                <p>Please enter your password</p>
                <input type="password" name="password">
                <br><br>
                <input type="submit" value="Submit">
            </form>
        </div>
    </div>
</body>
<jsp:include page="includes/pagebottom.html"/>


<%-- 
    Document   : index
    Created on : Apr 21, 2016, 12:44:40 PM
    Author     : NH228U03
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="bannerImage">
        <img src="images/gotInsurance.png" width="1000" height="250">
    </div>
    <div id="wrapper">
        <div id="divOne">
            <h3>View Our Policies</h3>
            <br><br><br><br>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=policies" >Policies</a></li>
            </ul>
        </div>
        <div id="divTwo">
            <h3>New Customer?</h3>
            <h3>Create account today!</h3>
            <br><br>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=createAccount" >Create Account</a></li>
            </ul>
        </div>
    </div>
</body>

<br><br>
<jsp:include page="includes/pagebottom.html"/>
</html>

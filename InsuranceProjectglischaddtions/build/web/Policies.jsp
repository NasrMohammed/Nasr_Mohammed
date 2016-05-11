<%-- 
    Document   : Policies
    Created on : Apr 21, 2016, 1:01:01 PM
    Author     : NH228U03
--%>

<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="wrapper2">
        <div id="home">
            <h3>Home Insurance</h3>
            <p>One of the most flexible and complete policies you will find.</p>
            <p>We pride ourselves in providing the most intuitive policies in
                the tri-state area</p>
            <p>Our coverage ranges from:</p>
            <ul>
                <li>Fire</li>
                <li>Tornado and other weather damages</li>
                <li>Damages caused from faulty infrastructure</li>
                <li>Theft and burglary</li>    
            </ul>
            <p>Do <strong>not</strong> hesitate to apply for our policy!</p>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=addPolicies" >Add Policy!</a></li>
            </ul>
        </div>
        <div id="auto">
            <h3>Auto Insurance</h3>
            <p>Protect your auto investment with our renown auto insurance!<p>
            <p>We insure anything at a reasonable price! Including rare sports cars!</p>
            <p>We have several ranges of coverage including:</p>
            <ul>
                <li>Liability</li>
                <li>Entry Complete</li>
                <li>Complete Coverage</li>
                <li>Enthusiast Coverage</li>    
            </ul>
            <p>Apply today!</p>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=addPolicies" >Add Policy!</a></li>
            </ul>
        </div>
        <div id="life">
            <h3>Life Insurance</h3>
            <p>We have comprehensive life policies to fit your needs.</p>
            <p>Commitment to helping families and creating fitting policies
                is something we truly take pride in.</p>
            <p>Please, do not wait any longer. Apply today and see how we
                can help you and your family</p>
            <br><br><br><br><br>
            <div id="placeButton">
                <p>
                <ul class="ulButton">
                    <li><a href="RequestHandler?task=addPolicies" >Add Policy!</a></li>
                </ul>
            </div>
        </div>
    </div>
</body>
<jsp:include page="includes/pagebottom.html"/>
</html>
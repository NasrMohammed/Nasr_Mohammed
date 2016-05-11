<%-- 
    Document   : AddPolocies
    Created on : Apr 26, 2016, 12:38:05 PM
    Author     : nh228u19
--%>
<%@page contentType="text/html" pageEncoding="UTF-8"%>
<jsp:include page="/includes/pagetop.html"/>
<jsp:include page="/includes/nav.html"/>
<body>
    <div id="wrapper5">
        <h1>Auto</h1>
        <div class="auto">
            <h3>Liability Coverage</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Not at fault accident</li>
                <li>Non insured accident</li>
                <li>Hit and run</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=LiabilityCoverage" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="auto">
            <h3>Entry Coverage</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Liability</li>
                <li>Weather Damage</li>
                <li>Road - Debris Damage</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=EntryCoverage" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="auto">
            <h3>Complete Coverage</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Entry and Liability</li>
                <li>Mechanical Failure</li>
                <li>Vehicle Break - ins</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteCoverageAuto" >Add Policy!</a></li>
            </ul>
        </div>
        <h1>Property</h1>
        <div class="home">
            <h3>Beginning Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Weather</li>
                <li>Incidentals</li>
                <li>Robbery</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="home">
            <h3>Standard Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Beginning Policy</li>
                <li>Personal Injury</li>
                <li>Maintenence costs</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="home">
            <h3>Complete Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Beginning and Standard</li>
                <li>Update Costs</li>
                <li>Eligible for rebates</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
        <h1>Life</h1>
        <div class="life">
            <h3 >Complete Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Beginning and Standard Policy</li>
                <li>Update Costs</li>
                <li>Eligible for policy rebates</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="life">
            <h3>Complete Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Beginning and Standard Policy</li>
                <li>Update Costs</li>
                <li>Eligible for policy rebates</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
        <div class="life">
            <h3>Complete Homeowners</h3>
            <p>Whats covered:</p>
            <ul>
                <li>Beginning and Standard Policy</li>
                <li>Update Costs</li>
                <li>Eligible for policy rebates</li>
            </ul>
            <ul class="ulButton">
                <li><a href="RequestHandler?task=verifyAccount&policy=CompleteHomeOwners" >Add Policy!</a></li>
            </ul>
        </div>
    </div>
</body>

<jsp:include page="includes/pagebottom.html"/>
</html>
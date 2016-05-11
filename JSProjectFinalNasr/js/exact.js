
console.log("javaScript is Working");

var clickStateOn = false;
$(document).ready(function(){

	console.log("JQuery is ready.");
	
	$("p").css("font-family", "courier");
	$(".blue").css("color", "#04F");
	
	$("#spreadsheet tr:odd").css("background-color", "aqua");
	$("#spreadsheet tr:even").css("background-color", "yellow");
	
	$("#spreadsheet tr:first").css("color", "white").css("background-color", "black");
	$("#spreadsheet tr:last").css("color", "yellow").css("background-color", "brown");
	
	$("#spreadsheet td:contains(4)").css("color", "white").css("background-color", "magenta");



	
	$("#secondline").css("cursor","pointer");
	$("#secondline").click(function() {
	
		$(this).toggleClass("highlighted");
	});
	
	
		$("#headline").css("cursor","pointer");
	$("#headline").click(function() { 
	
		if (clickStateOn == false ) {
			$("#headline").css("color", "red").css("background-color","yellow");
			clickStateOn = true;
		} else {
		
			$("#headline").css("color", "black").css("background-color","white");
			clickStateOn = false;
		}
		
		
	
	});

});

console.log("Javascript is available....");

$(document).ready(function(){
	console.log("jQuery is ready....");

	// declarative code goes here 
	$('.hidden').hide();
	
	$('input[type="button"]').button();
	$('#tabs').tabs( {
	 disabled: [1,2,3,4,5 ]
	});
	$("#tabForm1").validate();
	$("#tabForm2").validate();
	$("#tabForm3").validate();
	$("#tabForm4").validate();
	$("#tabForm5").validate();
	$("#tabForm6").validate();

	
	$("input:first").focus();
	
	// variables to hold all the form input values
	var info = "";
	var edu = "";
	var ref = "";
	var emp ="";
	var mil ="";
	var sign ="";
	
	
	
	// event handlers go here
	$("#continue1").click(function() {
		if ($("#tabForm1").valid() ==true) {
		//info = $("#info").val();
		//console.log("tabForm1 form is validated. name is" + info);
		
		$( "#tabs" ).tabs( "enable", 1 );
		$( "#tabs" ).tabs( "option", "active", 1 );
		$( "#tabs" ).tabs( "disable", 0 );
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	$("#back2").click(function () {
		$( "#tabs" ).tabs( "enable", 0 );
		$( "#tabs" ).tabs( "option", "active", 0 );
		$( "#tabs" ).tabs( "disable", 1 );
		
		$("#info").val(info);
		$("input:first").focus();
	});
	$("#continue2").click(function() {
		if ($("#tabForm2").valid() ==true) {
		edu = $("#edu").val();
		console.log("tabForm1 form is validated. name is" + edu);
		
		$( "#tabs" ).tabs( "enable", 2 );
		$( "#tabs" ).tabs( "option", "active", 2 );
		$( "#tabs" ).tabs( "disable", 1 );
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	$("#back3").click(function () {
		$( "#tabs" ).tabs( "enable", 1 );
		$( "#tabs" ).tabs( "option", "active", 1 );
		$( "#tabs" ).tabs( "disable", 2 );
		
		$("#edu").val(edu);
		$("input:first").focus();
	});
	$("#continue3").click(function() {
		if ($("#tabForm3").valid() ==true) {
		ref = $("#ref").val();
		console.log("tabForm1 form is validated. name is" + ref);
		//$( "#dialog-confirm" ).dialog("open");
		$( "#tabs" ).tabs( "enable", 3 );
		$( "#tabs" ).tabs( "option", "active", 3 );
		$( "#tabs" ).tabs( "disable", 2 );
		// show a dialog box to confirm submission
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	
	$("#back4").click(function () {
		$( "#tabs" ).tabs( "enable", 2 );
		$( "#tabs" ).tabs( "option", "active", 2);
		$( "#tabs" ).tabs( "disable", 3 );
		
		$("#ref").val(ref);
		$("input:first").focus();
	});
	
		$("#continue4").click(function() {
		if ($("#tabForm4").valid() ==true) {
		emp = $("#emp").val();
		console.log("tabForm1 form is validated. name is" + emp);
		//$( "#dialog-confirm" ).dialog("open");
		$( "#tabs" ).tabs( "enable", 4 );
		$( "#tabs" ).tabs( "option", "active", 4 );
		$( "#tabs" ).tabs( "disable", 3 );
		// show a dialog box to confirm submission
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	
	$("#back5").click(function () {
		$( "#tabs" ).tabs( "enable", 3 );
		$( "#tabs" ).tabs( "option", "active", 3);
		$( "#tabs" ).tabs( "disable", 4 );
		
		$("#emp").val(emp);
		$("input:first").focus();
	});
	
	$("#continue5").click(function() {
		if ($("#tabForm5").valid() ==true) {
		mil = $("#mil").val();
		console.log("tabForm1 form is validated. name is" + mil);
		//$( "#dialog-confirm" ).dialog("open");
		$( "#tabs" ).tabs( "enable", 5 );
		$( "#tabs" ).tabs( "option", "active", 5 );
		$( "#tabs" ).tabs( "disable", 4 );
		// show a dialog box to confirm submission
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	
	$("#back6").click(function () {
		$( "#tabs" ).tabs( "enable", 4 );
		$( "#tabs" ).tabs( "option", "active", 4);
		$( "#tabs" ).tabs( "disable", 5 );
		
		$("#mil").val(mil);
		$("input:first").focus();
	});
	
	$("#continue6").click(function() {
		if ($("#tabForm6").valid() ==true) {
		sign = $("#sign").val();
		console.log("tabForm1 form is validated. name is" + sign);
		$( "#dialog-confirm" ).dialog("open");
		$( "#tabs" ).tabs( "enable", 6 );
		$( "#tabs" ).tabs( "option", "active", 6 );
		$( "#tabs" ).tabs( "disable", 5 );
		// show a dialog box to confirm submission
		
			} else {
			console.log("tabForm1 has errors");
			
			}
	});
	
	
	$( "#dialog-confirm" ).dialog({
      resizable: false,
	  autoOpen: false,
      height:140,
      modal: true,
      buttons: {
        "Submit": function() {
          $( this ).dialog( "close" );
        },
        Cancel: function() {
          $( this ).dialog( "close" );
        }
      }
    });
	
	var citizen = "";
	
	$('input[name="citizen"]').click(function(){
		citizen = $(this).val();
		if(citizen == 'yes') {
			$("#no").prop("checked",false);
			$('#authorized').slideUp();
		    $('#work').slideDown();
	
		} 
		else 
		{
			$("#yes").prop("checked",false);
			$('#authorized').slideDown();	
			$('#work').slideUp();			
			
		}
		
		
	});
	
	var authorized = "";
	
	$('input[name="legal"]').click(function(){
		authorized = $(this).val();
		if(authorized == 'yes') {
			$("#no1").prop("checked",false);
			$('#work').slideDown();
			
				document.getElementById("continue1").disabled = false;

			
		} 
		else
		{
			$("#yes1").prop("checked",false);
			$('#work').slideUp();	
			
			
			window.alert("Dude! you cant work here man, it's illegal");
			document.getElementById("continue1").disabled = true;
		
		}
		
		
	});
	
	
	var work = "";
	
	$('input[name="le"]').click(function(){
		work = $(this).val();
		if(work == 'yes') {			
		
			
			$("#n").prop("checked",false);
			$('#auth').slideDown();	
		} 
		else 
		{
				
			$("#y").prop("checked",false);
			$('#auth').slideUp();
		}	
		
	});
	
	var work2 = "";
	
	$('input[name="lee"]').click(function(){
		work2 = $(this).val();
		if(work2 == 'yes') {						
			$("#n4").prop("checked",false);
			$('#auth2').slideDown();	
		} 
		else 
		{				
			$("#y4").prop("checked",false);
			$('#auth2').slideUp();
		}	
		
	});
	
	var work3 = "";
	
	$('input[name="leee"]').click(function(){
		work3 = $(this).val();
		if(work3 == 'yes') {						
			$("#n5").prop("checked",false);
			$('#auth3').slideDown();	
		} 
		else 
		{				
			$("#y5").prop("checked",false);
			$('#auth3').slideUp();
		}	
		
	});
	var work4 = "";
	
	$('input[name="leeee"]').click(function(){
		work4 = $(this).val();
		if(work4 == 'yes') {						
			$("#n6").prop("checked",false);
			$('#auth4').slideDown();	
		} 
		else 
		{				
			$("#y6").prop("checked",false);
			$('#auth4').slideUp();
		}	
		
	});
	var work5 = "";
	
	$('input[name="ls"]').click(function(){
		work5 = $(this).val();
		if(work5 == 'yes') {						
			$("#n7").prop("checked",false);
			$('#auth5').slideDown();	
		} 
		else 
		{				
			$("#y7").prop("checked",false);
			$('#auth5').slideUp();
		}	
		
	});
	var work6 = "";
	
	$('input[name="lss"]').click(function(){
		work6 = $(this).val();
		if(work6 == 'yes') {						
			$("#n8").prop("checked",false);	
						
		} 
		else 
		{				
			$("#y8").prop("checked",false);			
		}	
		
	});
	var work7 = "";
	
	$('input[name="lsss"]').click(function(){
		work7 = $(this).val();
		if(work7 == 'yes') {						
			$("#n9").prop("checked",false);	
			$('#auth7').slideDown();			
		} 
		else 
		{				
			$("#y9").prop("checked",false);	
			$('#auth7').slideUp();
			document.getElementById("continue6").disabled = true;
			
		}	
		
	});
	
});



















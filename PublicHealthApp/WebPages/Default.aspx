<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PublicHealthApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

<h1> ImmuData</h1>
<h3> (Team 29 Public Health App)</h3>
  <!--  <a href="#" id="dialog-link" class="ui-state-default ui-corner-all"><span class="ui-icon ui-icon-newwin"></span>Information Regarding Data Sources</a>-->
    <br /><br />

    For detailed information on how to use this site, refer to the
     <a href="UserGuide.aspx" class="ui-state-default ui-corner-all"> User Guide </a>.
        <br /><br />

   <!-- Tabs -->
<%--<h2 class="demoHeaders">Tabs</h2>--%>

<div id="tabs" style="height:inherit">
	<ul>
		<li><a href="#tabs-1">The Problem</a></li>
		<li><a href="#tabs-2">Our Solution</a></li>
        <li><a href="#tabs-3">Potential Users and Benefits</a></li>
		<li><a href="#tabs-4">Project Considerations</a></li>
        <li><a href="#tabs-5">Data Sources</a></li>
	</ul>
	<div id="tabs-1" style="min-height:300px;margin-top:10px">
             Public health policy and administration of vaccines are limited by the complexity and lack of knowledge regarding immunization data.
            <br /><br /> Leveraging immunization data repositories opens up a large opportunity to improve public health policy on a policy level and can affect practitioner activities.
            <br /><br /> Additionally, because of this lack of knowledge regarding population immunization and their potential affect on specific diseases leaves a huge opportunity to evaluate the state of public health with an additional goal of being able to easily share and distribute this information.
    </div>
	<div id="tabs-2" style="min-height:300px;margin-top:10px">
        This application provides querying capability for immunization data sources and a user-friendly graphical front end for visualizing data. 
        <br /><br />In this instance we have captured CDC immunization data in the past 5 years (2010-2014) in order to expose immunization trends. 
        <br /><br />Key query elements are provided to better understand the relationship between vaccines, geographical location, gender, race and patient age groups.  Additionally, this application has various exporting available to the user.
    </div>
	<div id="tabs-3" style="min-height:300px;margin-top:10px"> Users such as public health officials, practitioners and pharmacists that administer vaccines will directly benefit from a simplified interface and data aggregation engine. 
        <br /><br />For example, the downward trend of the flu vaccine in a particular state may warrant policies to counter flu.
        <br /> <br />Similarly, primary care physicians and pediatricians can make more informed decisions with immunization data insight that provides value from having access to a vast amount of data available in immunization registries.
    </div> 
    <div id="tabs-4" style="min-height:300px;margin-top:10px">
        Use of FHIR - <br />The team evaluated the use of GT FHIR server v1.0 but this initial release only provided the following resources which did not provide all of the necessary information.
        <br /><br />
        Visualization - <br/> The team evaluated several graphing options and decided upon the use of Highcharts for its rich built-in feature set, ease of integration using javascript libraries and use of plugins for additional functionality. 
    </div>
    <div id="tabs-5" style="min-height:300px;margin-top:10px">
       Datasets used in this application were obtained from the National Immunization Survey at <a href="www.cdc.gov/nchs/nis.htm">www.cdc.gov/nchs/nis.htm </a> .
    </div> 
</div>






<script>

$( "#accordion" ).accordion();

var availableTags = [
	"ActionScript",
	"AppleScript",
	"Asp",
	"BASIC",
	"C",
	"C++",
	"Clojure",
	"COBOL",
	"ColdFusion",
	"Erlang",
	"Fortran",
	"Groovy",
	"Haskell",
	"Java",
	"JavaScript",
	"Lisp",
	"Perl",
	"PHP",
	"Python",
	"Ruby",
	"Scala",
	"Scheme"
];
$( "#autocomplete" ).autocomplete({
	source: availableTags
});

$( "#button" ).button();
$( "#radioset" ).buttonset();
$( "#tabs" ).tabs();
$( "#dialog" ).dialog({
	autoOpen: false,
	width: 400,
	buttons: [
		{
			text: "Ok",
			click: function() {
				$( this ).dialog( "close" );
			}
		}
        //,
		//{
		//	text: "Cancel",
		//	click: function() {
		//		$( this ).dialog( "close" );
		//	}
		//}
	]
});

// Link to open the dialog
$( "#dialog-link" ).click(function( event ) {
	$( "#dialog" ).dialog( "open" );
	event.preventDefault();
});

$( "#datepicker" ).datepicker({
	inline: true
});

$( "#slider" ).slider({
	range: true,
	values: [ 17, 67 ]
});

$( "#progressbar" ).progressbar({
	value: 20
});

$( "#spinner" ).spinner();

$( "#menu" ).menu();

$( "#tooltip" ).tooltip();

$( "#selectmenu" ).selectmenu();


// Hover states on the static widgets
$( "#dialog-link, #icons li" ).hover(
	function() {
		$( this ).addClass( "ui-state-hover" );
	},
	function() {
		$( this ).removeClass( "ui-state-hover" );
	}
);
     







</script>


</asp:Content>

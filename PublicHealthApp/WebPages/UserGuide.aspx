<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UserGuide.aspx.cs" Inherits="PublicHealthApp.WebPages.UserGuide" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>ImmuData User Guide</h2>

   <!-- outer border-->
        <div class="vhouterborderLg" > 
            <!-- inner border-->
            <div class ="vhinnerborderLg" >
                <!-- text area -->
                <div style="min-height:300px" class="vhtextareaLg">

    <h3>Overview</h3>
    This guide outlines how to navigate and use the ImmuData application.
            <h3>Navigation</h3>
            <img src="../Content/images/header2.png" style="width:486px;height:50px" />
            <br />
    
            
        <ul style="list-style-type:none">    
        <li> The ImmuData web application provides navigation to the Vaccinations, User Guide, Contributors and Home pages from the header on the top of all screens.</li></ul>
                 
   
    
    <ul style="list-style-type:disc">    
        <li>The Vaccinations page provides the query interface tool and data visualization from the query results.</li>
        <li>The User Guide link provides this convenient online reference to the system.</li>
        <li>The Contributors page lists the development team and designated titles for this project.</li></ul>
 
  
        <h3>Vaccinations Page</h3>  
            <br /> 
        Clicking "Vaccinations" on the top navigation bar displays the Vaccinations page’s Report Query Builder. 
            <br /> 
            <br />
            
    
<ul style="list-style-type:none">        
        <li><h4>QUERY BUILDER</h4>
        <br /> 
        <img src="../Content/images/querybuilder.png"/>
        <br />
        <br />
        <li>The Report Query Builder displays the available query options for viewing data for a single selected vaccine or all vaccines in the database.  Query options default to include all values in the database. Selection of an option filters result.</li>
        <br />
        <li>Available options for selection include a single value or inclusion of all values: </li>
        <br />

    <li><h4>Show (Vaccine name): </h4>
    <ul style="list-style-type:disc">
        <li>41 vaccine selections</li>
    </ul>
    </li>
    <li><h4>Administered in (State or US Territory):</h4> 
    <ul style="list-style-type:disc">
        <li>50 states, the District of Columbia and 3 US territories</li>
    </ul>
    </li>
    <li><h4>Poverty status:</h4>
    <ul style="list-style-type:disc">
        <li>Above poverty (<= 75K)</li>
        <li>Above poverty (> 75K)</li>
        <li>Below poverty</li>
        <li>Unknown</li>
    </ul>
    </li>
    <li><h4>Gender: </h4>
    <ul style="list-style-type:disc">
        <li>Female</li>
        <li>Male</li>
    </ul>
    </li>
    <li><h4>Race:</h4>
    <ul style="list-style-type:disc">
        <li>Hispanic</li>
        <li>Non-Hispanic (Black only)</li>
        <li>Non-Hispanic (Other + Multiple race)</li>
        <li>Non-Hispanic (White only)</li>
    </ul>
    </li>
    <li><h4>Age: </h4>
    <ul style="list-style-type:disc">
        <li>19 – 23 months</li>
        <li>24 – 29 months</li>
        <li>30 – 35 months</li>
    </ul>
    </li>
    <li><h4>Mother’s marital status:</h4>
    <ul style="list-style-type:disc">
        <li>Married</li>
        <li>Never married/Widowed/Divorced/Separated/Deceased</li> 
    </ul>
    </li>
    <li><h4>Survey year:</h4>
    <ul style="list-style-type:disc">
        <li>2010</li>
        <li>2011</li>
        <li>2012</li>
        <li>2013</li>
        <li>2014</li>
    </ul>
    </li>
    <br />
     <li>After selecting desired query options, pressing the “Run Query” button displays a data table of summaries by year and a graph of data points for the selected options.
        </li>
    <li><h4>GRAPHING</h4></li>
    <li> The graph features:
     <ul style="list-style-type:disc">
        <li>a display of totals </li>
        <li>exporting/printing options</li>
    </ul>
    <br />
    </li>
    <li>To verify totals, hover over the data points to see detail.</li>
    <br />
    <br />
    <li><img src="../Content/images/hover.png"/></li>
    <br />
    <li> To access exporting/printing options, click the 3 horizontal bars at the top right of the graph and select a print or download option:
    <ul style="list-style-type:disc">
        <li>Print chart</li>
        <li>Download PNG, JPG, PDF, SVG vector image files</li>
	 
    </ul>
       
        <br />
        <img src="../Content/images/exporting.png"/>
        <br />
         <br />
        Selecting "Print chart" will display the system print dialog and selecting one of the download options will send a copy of the graph (in the specified format) to your downloads folder.
    </li>
</ul>

        </div>
    </div>
</div>

<!--</div>-->

</asp:Content>

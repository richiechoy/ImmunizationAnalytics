<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="VaccinationsPage.aspx.cs" Inherits="PublicHealthApp.WebPages.VaccinationsPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
<h2 >Vaccination Report Query Builder</h2>
        
    <hr />

        <h3> Select the desired query options:</h3>
    
      <asp:Panel runat="server" >
        <asp:Literal runat ="server" ID="ltrChart"></asp:Literal>
   </asp:Panel>
       <asp:Panel runat="server" style="width:400px; float:left">
       
        <!-- outer border-->
        <div class="vhouterborder" > 
            <!-- inner border-->
            <div class ="vhinnerborder" >
                <!-- text area -->
                <div style="min-height:300px" class="vhmenuarea">
                    <!-- query options table-->
                <table>

            <tr>
                <!-- Select Menu -->
                <td class="vhoptionlabel">
                Show:
                </td>
                <td class="vhoptionlabel">
                    <asp:DropDownList ID ="vaccinemenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="Choose a vaccine:" Value="" />
                        <asp:ListItem Text="All Vaccines" Value="" />
                    </asp:DropDownList>                 
                </td>
                </tr>
                <tr>
                <td class="vhoptionlabel">Administered in:</td>
                <td class="vhoptionlabel">
                    <asp:DropDownList ID ="statemenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All States" Value="" />
                    </asp:DropDownList>
                    
                </td>                      
            </tr>
             <tr>
                 <td class="vhoptionlabel">
                    Poverty status:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="povertymenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Statuses" Value="" />
                    </asp:DropDownList>                 
                </td>
                 </tr>
                <tr>
                 <td class="vhoptionlabel">
                    Gender:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="gendermenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Genders" Value="" />
                    </asp:DropDownList>                 
                </td>
             </tr>
             <tr>
                 <td class="vhoptionlabel">
                    Race:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="racemenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Races" Value="" />
                    </asp:DropDownList>                 
                </td>
                 </tr>
                <tr>
                 <td class="vhoptionlabel">
                    Age:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="agemenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Ages" Value="" />
                    </asp:DropDownList>                 
                </td>
             </tr>
             <tr>
                 <td class="vhoptionlabel">
                    Mother's marital status:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="maritalmenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Statuses" Value="" />
                    </asp:DropDownList>                 
                </td>
                 </tr>
                <tr>
                 <td class="vhoptionlabel">
                    Survey year:
                 </td>
                 <td class="vhoptionlabel">
                    <asp:DropDownList ID ="yearmenu" runat="server" AppendDataBoundItems="true" CssClass="vhcustomdd">
                        <asp:ListItem Text="All Available Years" Value="0" />
                    </asp:DropDownList>                 
                </td>
             </tr>
<!--             <tr>
                 <td>
                       Date range :
                 </td>
                <td colspan="3">     
                  
                     <input id="datepickerStart" type="text" />
                     through
                    <input id="datepickerEnd" type="text" />
                 </td>
             </tr>
             -->
                    <tr><td style="min-height:10px"></td></tr>
<tr style="padding-top:20px; margin-top:20px"><td></td>
    <td style="text-align:center;height:50px"><asp:Button runat="server" id="btnQry" text="Run Query"/></td></tr>
                      
            </table>
            <!--<asp:GridView runat="server" ID="placeHolderGrid"></asp:GridView>-->
</div>
        
    </div>
</div>
</asp:Panel>

    <br />
   <!-- <button id="btnRun" onclick="return false;">Show Graph</button>-->
  

                    <div id="container" style="min-width: 310px; max-width: 800px; height: 400px; margin: 0 auto">
                        
                    </div>


    <script>
        $(document).ready(function () {
            //debugger;
            });

        $(".ddfilter").selectmenu();
        $("#radioset1").buttonset();
        $("#radioset2").buttonset();
        $("#radioset3").buttonset();
        //$("#datepickerStart").datepicker({
        //    inline: true,
        //    dateFormat: "mm/dd/yy",
        //    beforeShow: function (input) {
        //        $(input).css('background-color', '#eaf0ce');
        //    },
        //    onSelect: function (dateText, obj) {
        //        $(this).css('background-color', '');
        //    },
        //    onClose: function (dateText, obj) {
        //        $(this).css('background-color', '');
        //    }
        //});
        //$("#datepickerEnd").datepicker({
           
        //    inline: true,
        //    dateFormat: "mm/dd/yy",
        //    beforeShow: function(input){    
        //        $(input).css('background-color','#eaf0ce');
        //    },
        //    onSelect: function(dateText, obj) {
        //        $(this).css('background-color','');
        //    },
        //    onClose: function (dateText, obj) {
        //        $(this).css('background-color', '');
        //    }
        //});
       
        $("#btnRun").button();

        $("#btnQry").button();

    //    $("#btnRun").click(function () {
        //          $('#container').highcharts({

        //      colors: ['#443850', '#000000', '#bbbe64', '#000000', '#eaf0ce', '#64E572', '#FF9655', '#FFF263', '#6AF9C4'],
        //      chart: {
        //          zoomType: 'xy'
        //      },
        //      title: {
        //          text: 'Vaccine Preventable Diseases'
        //      },
        //      subtitle: {
        //          text: 'Graphing proof of concept'
        //      },
        //      xAxis: [{
        //          categories: ['Hepatitis A', 'Hepatitis B', 'Hib', 'HPV', 'Influenza', 'Meningococcal', 'MMR', 'Pneumococcal (PCV)', 'Pneumococcal (PPSV)', 'Polio', 'Rotavirus', 'DTap/Td/Tdap', 'Varicella (chickenpox)', 'Zoster'],
        //          crosshair: true
        //      }],
        //      yAxis: [{ // Primary yAxis
        //       labels: {
        //              format: '{value}',
        //              style: {
        //                  //color: Highcharts.getOptions().colors[1]
        //                  color: "#443850"
        //              }
        //          },
        //           title: {
        //               text: '',
        //              style: {
        //                  //color: Highcharts.getOptions().colors[1]
        //                  color: "#443850"
        //              }
        //          }
        //  //  //      },

        //        { // Secondary yAxis
        //          title: {
        //              text: 'Population Counts',
        //              style: {
        //                  //color: Highcharts.getOptions().colors[0]
        //                  color:"#bbbe64"
        //              }
        //          },
        //          labels: {
        //              format: '{value}',
        //              style: {
        //                  //color: Highcharts.getOptions().colors[0]
        //  //                  color:"#bbbe64"
        //          }
        //          },
        //          opposite: true
        //      },
        // 
        //  //  // 
        //          { // Primary yAxis
        //           labels: {
        //               format: '{value}',
        //               style: {
        //                   //color: Highcharts.getOptions().colors[1]
        //                   color: "#443850"
        //               }
        //           },
        //           title: {
        //               text: '# Occurences',
        //               style: {
        //                  //color: Highcharts.getOptions().colors[1]
        //                     color: "#443850"
        //               }
        //           }
        //       }

        //      ],
        //      tooltip: {
        //          shared: true
        //      },
        //      legend: {
        //          layout: 'vertical',
        //           align: 'left',
        //         x: 120,
        //          verticalAlign: 'top',
        //          y: 100,
        //          floating: true,
        //          backgroundColor: (Highcharts.theme && Highcharts.theme.legendBackgroundColor) || '#FFFFFF'
        //      },
        //      series: [{
        //          name: 'Adult',
        //          type: 'column',
        //          yAxis: 1,
        //          data: [49.9, 71.5, 106.4, 129.2, 144.0, 176.0, 135.6, 148.5, 216.4, 194.1, 95.6, 54.4],

        //      }, {
        //          name: '# Occurences',
        //          type: 'spline',
        //          data: [7, 6, 9, 14, 18, 21, 25, 26, 23, 18, 13, 9],
        //      },
        //      {
        //          name: 'Children',
        //          type: 'column',
        //          yAxis: 1,
        //          data: [29.2, 51.0, 66.3, 109.2, 74.0, 76.0, 115.6, 128.5, 186.4, 154.1, 75.6, 84.4],
        //      }]
        //  });
        // });
       
        
        // $.datepicker.setDefaults({
        //  showOn: "both",
        //  buttonImageOnly: true,
        //  buttonImage: "calendar.gif",
        //  buttonText: "Calendar"
        // });-->
  
		</script>  

</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contributors.aspx.cs" Inherits="PublicHealthApp.WebPages.Contributors" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div>
        <h2>Contributors</h2>
    </div>

    <br /><br />
    <div class="vhouterborderLg" > 
            <!-- inner border-->
            <div class ="vhinnerborderLg" >
                <!-- text area -->
                <div style="min-height:300px;text-align:center;vertical-align:middle" class="vhtextareaLg">
   
          <asp:Image id="Image1" runat="server"
           AlternateText="Image of contributor names"
           ImageAlign="Middle"
           ImageUrl="~/Content/Contributors.JPG" style="max-width:1000px"/>
                    
        </div>
    </div>
</div>

</asp:Content>

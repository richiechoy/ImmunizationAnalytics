<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DataImport.aspx.cs" Inherits="PublicHealthApp.WebPages.DataImport" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="File Path: "></asp:Label>
        <asp:TextBox ID="txtFilePath" runat="server" Width="250px"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Row Start: (min 1) "></asp:Label>
        <asp:TextBox ID="txtRowStart" runat="server">1</asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Row Limit (0 for all): "></asp:Label>
        <asp:TextBox ID="txtRowLimit" runat="server">100</asp:TextBox>
        <br />
        <asp:Button ID="btnImport" runat="server" OnClick="btnImport_Click" Text="Import From File" />
    
        <br />
        <asp:Label ID="lblOutput" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>

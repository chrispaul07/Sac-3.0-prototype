<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Sac_3._0_prototype.Models.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bible Verse</title>
</head>
<body background="~/Content/Images/" >
    
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="retrieve" runat="server" Text="Retrieve" OnClick="retrieve_Click" />
            <br />     
    </form>
     </div>
        <div id="result" >
            <h1 style="font-size:3vw"><%=variable %></h1>  
        </div>
</body>
</html>

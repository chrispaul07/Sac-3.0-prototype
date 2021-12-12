<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Sac_3._0_prototype.Models.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bible Verse</title>
    <style> 
         .content{
            background-image:url(1.jpg);
            width:70%;
            height:70%;
            background-repeat:no-repeat;
            background-color:red;
            background-size:cover;
         }
    </style>
</head>
<body>

    <form id="form1" runat="server">
        <div id="result" >
            <h1 style="font-size:3vw"><%=variable %></h1>
            <p style="font-size:3vw">&nbsp;</p>
            <p style="font-size:3vw">&nbsp;</p>
            <p style="font-size:3vw">&nbsp;</p>
            <p style="font-size:3vw">&nbsp;</p>
            <p style="font-size:3vw">&nbsp;</p>
            <p style="font-size:3vw">&nbsp;</p>
            <asp:Button ID="retrieve" runat="server" Text="Retrieve" OnClick="retrieve_Click" CssClass="special" Style="margin-left:auto; display:block;" />
        </div>
        <p>
            &nbsp;</p>
    </form>
</body>
</html>

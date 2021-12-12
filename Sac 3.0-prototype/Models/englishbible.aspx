<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="englishbible.aspx.cs" Inherits="Sac_3._0_prototype.Models.englishbible" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
       .all_btn{display: inline-block; margin-left: 1200px; font-size:0px;}
       .text{display: inline-block; margin-left: 1200px;}
    </style>
</head>
<body style="height: 651px; width: 1356px; color: #FFFFFF; position: relative;background-color: #000000;">
    <form id="form1" runat="server">
    <div>
            <h2 align="center">Bible Verse</h2>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">
                &nbsp;</p>
            <p align="center">
                &nbsp;</p>
            <p>
                &nbsp;</p>
            <p align="center">
                &nbsp;</p>
            <p align="center">
                &nbsp;</p>
            <p align="center">
                &nbsp;</p>
    </div> 
        <p align="left">
                
            </p>
        <div class="text">
            <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        </div>
        <div class="all_btn" >
            <asp:Button ID="Button1" runat="server" Text="+" />
            <asp:Button ID="Button2" runat="server" Text="-" />
            <asp:Button ID="Button3" runat="server" Text="*" />
            <asp:Button ID="Button4" runat="server" Text="/" />
            <asp:Button ID="Button5" runat="server" Text="[" />
            <asp:Button ID="Button6" runat="server" Text="]" />

        </div>
           
           
    </form>
     
    </body>
</html>

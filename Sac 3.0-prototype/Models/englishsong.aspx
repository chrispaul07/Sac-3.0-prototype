<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="englishsong.aspx.cs" Inherits="Sac_3._0_prototype.Models.englishsong" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Songs</title>
    <script>    
  function funfordefautenterkey1(btn, event) {    
      if (document.all) {    
          if (event.keyCode == 13) {    
              event.returnValue = false;    
              event.cancel = true;    
              btn.click();    
          }    
     }                    
    </script> 
    <style>
       .all_btn{display: inline-block; margin-left: 1200px; font-size:0px;}
       .text{display: inline-block; margin-left: 1200px;}
       .textAlign{
                text-align:center;
            }
    </style>
</head>
<body scroll="no" style="overflow: hidden; height: 651px; width: 1356px; color: #000000; position: relative;background-color: #CCCCCC; ">
    <form id="form1" runat="server">
    <div>
            <h2 align="center">Songs</h2>
            <hr />
            <asp:Label ID="header" runat="server" Font-Bold="true" Font-Size="XX-Large" ></asp:Label> <br />
             <p align="center">&nbsp;</p>
            <asp:Label ID="message" runat="server" Font-Bold="true" Font-Size="XX-Large" ></asp:Label> 
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
            <p align="center">&nbsp;</p>
           
    </div> 
        <p align="left">
                
            </p>
        <div class="text">
            <asp:TextBox ID="TextBox" runat="server" ></asp:TextBox>
            <asp:Button ID="Button4" runat="server" Text="Submit1" OnClick="ButtonIN_Click" ></asp:Button>
        </div>
        <div class="all_btn" >
            <asp:Button ID="Button1" runat="server" Text="1"  OnClick="ButtonIN_Click1"/>
            <asp:Button ID="Button2" runat="server" Text="2" OnClick="ButtonIN_Click2" />
            <asp:Button ID="Button3" runat="server" Text="3" OnClick="ButtonIN_Click3" />
        </div>
           
           
    </form>
     
    </body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="tamilbible.aspx.cs" Inherits="Sac_3._0_prototype.Models.tamilbible" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>வேத வசனம்</title>
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
       .all_btn{display: inline-block;  font-size:0px;}
       .text{display: inline-block;}
       .textAlign{
                text-align:center;
            }
    </style>
</head>
<body scroll="no" style=" height: 651px; width: 1356px; color: #000000; position: relative;background-color: #CCCCCC; ">
    <form id="form1" runat="server">
    <div>  
        <table width="100%">
            <tr>
                <td width="25%">&nbsp;</td>
                <td width="50%"><h2 align="center">வேத வசனம்</h2></td>
                <td width="25%">
                    <asp:TextBox ID="TextBox" runat="server" ></asp:TextBox>
                    <asp:Button ID="Button7" runat="server" Text="Get Verse" OnClick="ButtonIN_Click" ></asp:Button>
        </div>
        <div class="all_btn" >
            <asp:Button ID="Button1" runat="server" Text="+" />
            <asp:Button ID="Button2" runat="server" Text="-" />
            <asp:Button ID="Button3" runat="server" Text="*" />
            <asp:Button ID="Button4" runat="server" Text="/" />
            <asp:Button ID="Button5" runat="server" Text="[" />
            <asp:Button ID="Button6" runat="server" Text="]" />

        </div>
                </td>
            </tr>
        </table>
            
            <hr />
        

            <asp:Label ID="header" runat="server" Font-Bold="true" Font-Size="XX-Large" ></asp:Label> <br />
            <asp:Label ID="message" runat="server" Font-Bold="true" Font-Size="XX-Large"  Height="200"></asp:Label> 
            
           
    </div> 
        <p align="left">
                
            </p>
        
           
           
    </form>
     
    </body>
</html>

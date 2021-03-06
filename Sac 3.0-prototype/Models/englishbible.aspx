<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="englishbible.aspx.cs" Inherits="Sac_3._0_prototype.Models.englishbible" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bible Verse</title>
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
     <style type="text/css">
     .all_btn{
           display: inline-block; 
           font-size:0px;

     }
     .text{
           display: inline-block;

     }
     .textAlign{
                text-align:center;
     }
     .auto-style1 {
            font-weight: normal;
     }
     .navbar{
    list-style-type: none;
    background-color: #005172;
    color: #fff;
    height: 130px;
    width: 100%;
    position: fixed;
    top: 0px;
    z-index: 1;
    }
    .navbar li{
        float: left;
        width: 100%;
        text-align: center;
    }
    .navbar a{
        display: block;
        color: #ffffff;
        text-decoration: none;
        line-height: 49px;
        font-size: 20px;
    }
    .navbar a:hover{
        background-color: #aa0000;
        font-weight: bold;
    }
    .header {
      width: 100%; 
      position: relative; 
      background-color: #005172;
      color: #fff;
      top: 0;
      left: 0;
      z-index: 1;
    }
    table{
        border:none;
    }

    @media screen and (max-height: 450px) {
      .header {margin-bottom: 2%;}
    }

    .container{
        background-color: #fff;
        width: 90%;
        min-width: 480px;
        padding: 35px 50px;
        transform: translate(-50%,-50%);
        position: fixed;
        left: 50%;
        top: 55%;
        border-radius: 10px;
        box-shadow: 35px 35px 35px 35px rgba(0,0,0,0.15);
    }
    </style>
</head>
<body scroll="no" style=" height: 651px; width: 1356px; color: #000000; position: relative;background-color: #CCCCCC; ">
    <form id="form1" runat="server">
    <div>
        <ul class="header navbar">
            <li><h3>Bible Verse</h3></li>
            <li><asp:TextBox ID="TextBox" runat="server" Width="109px" ></asp:TextBox><br />
                    <asp:Button ID="Button7" runat="server" Text="Get Verse" OnClick="Get_Verse" Width="121px" ></asp:Button><br />
                    <div class ="all_btn">
                    <asp:Button ID="Button1" runat="server" Text="+" OnClick="Next_Verse"/>
                    <asp:Button ID="Button2" runat="server" Text="-" OnClick="Prev_Verse"/>
                    <asp:Button ID="Button3" runat="server" Text="*" OnClick="Next_Chapter"/>
                    <asp:Button ID="Button4" runat="server" Text="/" OnClick="Prev_Chapter"/>
                    </div></li>
        </ul>    
        <table>
             <tr>
                <td width="100%" class="container">
                    <asp:Label ID="header" runat="server" Font-Bold="true" Font-Size="XX-Large" ></asp:Label> <br /><br />
                    <asp:Label ID="message" runat="server" Font-Bold="True" Font-Size="XX-Large"  Height="200px" Width="1239px"></asp:Label> 
                </td>
            </tr>
        </table>
        <hr />
    </div> 
    </form>
</body>
</html>

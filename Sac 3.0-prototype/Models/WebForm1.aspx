<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Sac_3._0_prototype.Models.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="retrieve" runat="server" Text="Retrieve" OnClick="retrieve_Click" />
            <br />
            <asp:GridView ID="GridView1" runat="server" HorizontalAlign="Center"></asp:GridView>
        </div>
    </form>
</body>
</html>

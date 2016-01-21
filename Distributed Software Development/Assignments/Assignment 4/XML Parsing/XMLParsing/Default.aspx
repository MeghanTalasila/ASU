<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <br />
        <br />
        <br />
        Load the xml file:
        <asp:TextBox ID="TextBox1" runat="server" Width="370px"></asp:TextBox>
&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Parse" />
        <br />
        <br />
        <asp:TextBox ID="TextBox2" runat="server" Height="175px" TextMode="MultiLine" Width="558px"></asp:TextBox>
&nbsp;<br />
        <asp:TextBox ID="TextBox3" runat="server" Height="188px" TextMode="MultiLine" Width="554px"></asp:TextBox>
    
    </div>
    </form>
</body>
</html>

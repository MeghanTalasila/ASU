<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TryIT.aspx.cs" Inherits="TryIT" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    &nbsp;XML TRASFORMATION<br />
        <br />
        Enter URL of XML(.xml) File:
        <asp:TextBox ID="TextBox4" runat="server" Width="301px"></asp:TextBox>
        <br />
        Enter URL of XSL(.xsl) File:
        <asp:TextBox ID="TextBox5" runat="server" Width="304px"></asp:TextBox>
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Generate" Width="81px" />
        <br />
        <br />
&nbsp;<br />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <asp:Panel ID="Panel1" runat="server" Width="605px">
            XML VERIFICATION&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
            <br />
            Enter URL of XMLS (.xsd) File:
            <asp:TextBox ID="TextBox1" runat="server" Width="304px"></asp:TextBox>
            <br />
            Enter URL of XML(.xml) File:
            <asp:TextBox ID="TextBox2" runat="server" Width="295px"></asp:TextBox>
            <br />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Validates" Width="109px" />
            <br />
            <br />
            <asp:TextBox ID="TextBox3" runat="server" Height="109px" TextMode="MultiLine" Width="411px"></asp:TextBox>
            <br />
        </asp:Panel>
    
    </div>
    </form>
</body>
</html>


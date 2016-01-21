<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UserControl.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<%@ Register TagPrefix = "header" TagName="LoginControl" src="WebUserControl.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"> <title>User Control</title> </head>
<body>
		<form id="Form1" runat = "server" style="align-content:flex-start">
     			 <header:LoginControl ID="MyTable" BackColor="#ccccff" RunAt="server" />
		         <br />
          
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Weather Fore Cast<br />
        <br />
        Zip Code:<asp:TextBox ID="TextBox1" runat="server" style="margin-left: 14px"></asp:TextBox>
&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="get forecast" Width="108px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label1" runat="server"></asp:Label>
        <br />
        <br />
        Temperature in Fahrenheit<br />
        Day 1:<asp:TextBox ID="TextBox2" runat="server" Height="16px" style="margin-left: 53px" Width="629px"></asp:TextBox>
        <br />
        Day 2:<asp:TextBox ID="TextBox3" runat="server" style="margin-left: 53px" Width="628px"></asp:TextBox>
        <br />
        Day 3:<asp:TextBox ID="TextBox4" runat="server" style="margin-left: 53px" Width="629px"></asp:TextBox>
        <br />
        Day 4:<asp:TextBox ID="TextBox5" runat="server" style="margin-left: 54px" Width="630px"></asp:TextBox>
        <br />
        Day 5:<asp:TextBox ID="TextBox6" runat="server" style="margin-left: 53px" Width="628px"></asp:TextBox>
        <br />
        <br /> 
  
		</form>
	   
</body>
</html>


<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TryIt.aspx.cs" Inherits="weatherForecastService.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Function: Takes &quot;Zip Code&quot; as input and displays weather information for 5 days in that location<br />
        <br />
        URL: <a href="Service1.svc?wsdl">http://localhost:65115/Service1.svc?wsdl</a><br />
        <br />
        Service Name: Weather Service<br />
        Operation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; List&lt;string&gt; weatherService(String zipcode)<br />
        Input&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; a U.S. zip code<br />
        Output&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; A List o strings, storing 5 -day weather forecast for the given zipcode<br />
        <br />
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
    
    </div>
    </form>
</body>
</html>

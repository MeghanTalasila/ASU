<%@ Page Language="C#" AutoEventWireup="true" CodeFile="default.aspx.cs" Inherits="TryIT" %>

<!DOCTYPE html>
<%@ Register TagPrefix = "header" TagName="LoginControl" src="WebUserControl.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
         <header:LoginControl ID="MyTable" BackColor="#ccccff" RunAt="server" />
    <div>
        <h1> HOME PAGE </h1>
    Function: User Control
        <br />
        A header for the entire application and a marquee displaying the date, time and details of our team 
        along with the weather fore cast service has been displayed in user control<br />
    Input: Zip code
        <br />
        Output: weather forecast for 5 days
        <br />
        Service: <a href="http://webstrar40.fulton.asu.edu/Page5/WeatherForeCastService1.svc?wsdl">http://webstrar40.fulton.asu.edu/Page5/WeatherForeCastService1.svc?wsdl</a>
        <br />
        Link to user control:
    <a href="UserControl.aspx">User Control</a>
        <br />
        <br />

    Function: Server Control
        <br />
        Code to send email is written in the script tag.
        <br />
        Input: Detials of the users who is sending mail and recieving mail
        <br />
        Output: Success/ Failure
        <br />
        Link to Server Control:<a href="ServerControl.aspx">Server Control</a>
    </div>
    </form>
</body>
</html>

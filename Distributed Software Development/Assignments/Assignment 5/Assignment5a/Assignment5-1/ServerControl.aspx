<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ServerControl.aspx.cs" Inherits="partB" %>

<!DOCTYPE html>
<%@ Register TagPrefix = "header" TagName="LoginControl" src="WebUserControl.ascx" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   	<form id="form1" runat = "server" style="align-content:flex-start">
     			 <header:LoginControl ID="MyTable" BackColor="#ccccff" RunAt="server" />
    <div>
    <table id="emailTable" runat="server">
        <tr>
            <td>Email ID:</td>
            <td><input id="Text3" type="text" RunAt = "Server" width="200 px" /></td>
        </tr>
        <tr>
            <td>Password:</td>
            <td><input id="Text4" type="password" RunAt = "Server" width="220 px"/></td>
        </tr>
        <tr>
            <td>To:</td>
            <td><input id="Text1" type="text" RunAt = "Server" width="200 px"/></td>
        </tr>
        <tr>
            <td>Subject:</td>
            <td><input id="Text2" type="text" RunAt = "Server" width="200 px"/></td>
        </tr>
        <tr>
            <td>Body:</td>
            <td><textarea id="textarea1" runat="server" rows="6" width="150 px"></textarea></td>
        </tr>
        <tr>
            <td colspan="2"><input type="submit" value= "submit" ID = "submit" OnServerClick = "sendEmail" 	RunAt = "Server" /></td>
        </tr>
    </table>

    <h4><asp:Label ID="mailStatus" runat="server"></asp:Label></h4>
    </div>
    </form>
</body>
</html>
<script language= "C#" runat="server">
	void sendEmail (Object sender, EventArgs e) {
        String to = Text1.Value;
        String subject = Text2.Value;
        String userName = Text3.Value;
        String password = Text4.Value;
        String body = textarea1.Value;
        Int16 flag = 0;
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            System.Net.Mail.SmtpClient SmtpServer = new System.Net.Mail.SmtpClient("smtp.gmail.com");

            mail.From = new System.Net.Mail.MailAddress(userName);
            mail.To.Add(to);
            mail.Subject = subject;
            mail.Body = body;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(userName, password);
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);
        }
        catch (Exception ex)
        {
            mailStatus.Text = "Mail not sent" + ex;
            flag = 1;
        }
        if (flag == 0)
            mailStatus.Text = "Mail Delivered Successfully";
        else
            mailStatus.Text = "Mail is not delivered";
        Text1.Value = "";
        Text2.Value = "";
        Text3.Value = "";
             
	}
</script>

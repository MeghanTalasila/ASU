<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>

<style type="text/css">
    .auto-style1 {
        height: 103px;
    }
</style>
<body style="align-content:center">
<table id="MainTable" cellpadding="4" RunAt="server" style="align-content:flex-start;vertical-align:central">
  	<tr style="align-content:center;vertical-align:central">
          <td class="auto-style1">
              <asp:Image ID="Image" runat="server" AlternateText="Arizona State" Height="60px" ImageUrl="~/Images/AS.gif" Width="60px" ImageAlign="Left"/>
          </td>
          <td style="vertical-align:central" class="auto-style1">
              <asp:Label ID="Label1" runat="server" Text="HOSPITAL MANAGEMENT SYSTEM"  Height="42px" Font-Size="XX-Large" ForeColor="Maroon" CssClass="newStyle1" style="margin-top: 18px; font-family: 'times New Roman', Times, serif; font-size: 35px; font-weight: bolder"></asp:Label>
          </td>
          <td class="auto-style1"></td>
          <td class="auto-style1" >
              <table id="MyTable" runat="server">
                   <tr> <td>User Name:</td>
         	            <td><asp:Label ID="MyUserName" RunAt="server" /></td>
	                </tr>
                    <tr>	<td>Category:</td> 
               	            <td><asp:Label ID="MyCategory" RunAt="server" />  </td>
  	                </tr>
              </table>
          </td>
          <td><a href="default.aspx">HOME</a></td>
  	</tr>
</table>
<marquee direction="right" scrollamount="5" loop="true" width="100%" bgcolor="#ffffff" >
<table runat="server" style="text-align:end;align-content:flex-end">
 <tr> 
        <td>@ Team SMS, Distributed Software Development, Fall 2014</td> 
        <td><asp:Label id="DateandTime" runat="server"></asp:Label></td>
    </tr>
</table></marquee>
</body>
<script language="C#" RunAt="server">
  	public string BackColor	{	get { return MyTable.BgColor; }
     							set { MyTable.BgColor = value; }	} 
  	public string UserName 	{	get { return MyUserName.Text; }
      							set { MyUserName.Text = value; }	} 
  	public string Password 	{	get { return MyCategory.Text; }
      							set { MyCategory.Text = value; }	}
</script>

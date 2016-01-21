<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolarTryIt.aspx.cs" Inherits="Search_Service.TryIt" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Function: Takes &quot;category&quot; as input and sends list of items as output<br />
        <br />
        URL: <a href="Service1.svc?wsdl">http://localhost:52733/Service1.svc?wsdl</a><br />
        <br />
        Service Name: Search Doctors by Specialization<br />
        Operation&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; List<string> searchCategory(string category)<br />
        Input&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; caategory<br />
        Output&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp; List of items of that category<br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Search by Category<br />
        Search Doctors by Category:&nbsp;
        <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
            <asp:ListItem Text="Cardiology" Value="Cardiology"></asp:ListItem>
            <asp:ListItem Text="Neurology" Value="Neurology"></asp:ListItem>
            <asp:ListItem Text="Gynocology" Value="Gynocology"></asp:ListItem>
        </asp:DropDownList>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="margin-left: 44px" Text="Search" Width="126px" />
        <br />
        <br />
        Table showing list of doctors and their experience<br />
        <asp:Table ID="Table1" runat="server" Width="376px" BorderStyle="Solid" GridLines="Both">
            <asp:TableHeaderRow>
                <asp:TableHeaderCell Text="Name"></asp:TableHeaderCell>
                <asp:TableHeaderCell Text="Years of Experience"></asp:TableHeaderCell>
            </asp:TableHeaderRow>
        </asp:Table>
    
    </div>
    </form>
</body>
</html>

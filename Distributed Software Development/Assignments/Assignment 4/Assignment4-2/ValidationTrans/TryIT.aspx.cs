using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ServiceReference1;

public partial class TryIT : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Service1Client sc = new Service1Client();
        TextBox3.Text = "";

        TextBox3.Text = sc.VerificationXML(TextBox1.Text, TextBox2.Text);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Label1.Text = "";
        Service1Client sc = new Service1Client();
        Label1.Text = sc.TransformationXML(TextBox4.Text, TextBox5.Text);
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Send_Email
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1 emailService = new Service1();
            string to = TextBox1.Text;
            string from = TextBox2.Text;
            string sub = TextBox3.Text;
            string text = TextBox4.Text;
            string FName = TextBox5.Text;

            string sucess = emailService.sendEmail(to, from, sub, text, FName);

            if(sucess.Equals("true"))
            {
                Label1.Text = "Email devlivered Sucessfully!!!!!!";
            }
            else
            {
                Label1.Text = "Email not devlivered";
            }
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
        }
    }
}
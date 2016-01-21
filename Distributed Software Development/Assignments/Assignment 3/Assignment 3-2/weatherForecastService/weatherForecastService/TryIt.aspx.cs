using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace weatherForecastService
{
    public partial class TryIt : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> TempInfo = new List<string>();
            Service1 weatherForeCast = new Service1();
            TextBox2.Text = "";
            TextBox3.Text = "";
            TextBox4.Text = "";
            TextBox5.Text = "";
            TextBox6.Text = "";
            Label1.Text = "";
            if (TextBox1.Text == null)
            {

            }
            else
            {
                TempInfo = weatherForeCast.weatherService(TextBox1.Text);
            }
            if (TempInfo.Count > 0)
            {
                if (TempInfo[0] != null)
                    TextBox2.Text = TempInfo[0];
                if (TempInfo[1] != null)
                    TextBox3.Text = TempInfo[1];
                if (TempInfo[2] != null)
                    TextBox4.Text = TempInfo[2];
                if (TempInfo[3] != null)
                    TextBox5.Text = TempInfo[3];
                if (TempInfo[4] != null)
                    TextBox6.Text = TempInfo[4];
            }
            else
            {
                Label1.Text = "Please enter valid zip code";
            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
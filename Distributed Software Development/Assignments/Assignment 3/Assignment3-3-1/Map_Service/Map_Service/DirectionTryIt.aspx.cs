using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Map_Service
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Service1 directionService = new Service1();
            string direction = directionService.GetDirections(TextBox1.Text, TextBox2.Text);
            TextBox3.Text = direction;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        String Date = DateTime.Now.ToLongDateString();
        String Time = DateTime.Now.ToLongTimeString();
        DateandTime.Text = Date + "," + Time;

        MyUserName.Text = "Madhu Meghana Talasila";
        MyCategory.Text = "Developer";
    }

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        TempServiceRef.Service1Client tsr = new TempServiceRef.Service1Client();
        double celsiusTemp = Convert.ToDouble(CG.Text);
        double fahrenheitTemp = tsr.C2F(celsiusTemp);
        FO.Text = fahrenheitTemp.ToString();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        TempServiceRef.Service1Client tsr = new TempServiceRef.Service1Client();
        double fahrenheitTemp = Convert.ToDouble(FG.Text);
        double celsiusTemp = tsr.F2C(fahrenheitTemp);
        CO.Text = celsiusTemp.ToString(); 
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        CG.Text = "";
        CO.Text = "";
        FG.Text = "";
        FO.Text = "";
    }
}
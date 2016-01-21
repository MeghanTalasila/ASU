using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KeyWordSearch
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox2.Text = "";
            Service1 url = new Service1();
            string urlString = "";
            List<string> urlTemp = new List<string>();
            if (TextBox1.Text != null)
            {
                string[] urlList = TextBox1.Text.Split(',');
                //To call for given number of inputs
                foreach (string value in urlList)
                {
                    string[] temp = url.GetURL(value);
                    urlTemp = temp.ToList();
                    if (urlTemp != null)
                    {
                        for (int i = 0; i < urlTemp.Count(); i++)
                        {
                            urlString = urlString + urlTemp[i] + System.Environment.NewLine;
                        }
                    }
                }

                TextBox2.Text = urlString;

            }
        }
    }
}
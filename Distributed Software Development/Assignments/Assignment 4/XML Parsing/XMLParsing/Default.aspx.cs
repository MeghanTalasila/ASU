using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string url = TextBox1.Text;
        string defaultUrl = System.Web.Hosting.HostingEnvironment.ApplicationPhysicalPath + "\\HotelXML.xml";
          System.Xml.XmlTextReader reader;
        if (!url.Equals(""))
        {
            var temp = url.Split('\\');
            string newUrl = "";
            for (int i=0;i<temp.Count();i++)
            {
                newUrl = newUrl + temp[i];
                if(i != temp.Count() - 1 && i != temp.Count() - 2)
                {
                    newUrl = newUrl + "\\";
                }
                if(i == temp.Count() - 2)
                {
                    newUrl = newUrl + "\\\\";
                }
            }
            reader = new System.Xml.XmlTextReader(newUrl);
        }
        else
        {
            reader = new System.Xml.XmlTextReader(defaultUrl);
        }
        
        string attribute = "";
        string element = "";
        while (reader.Read())
        {
            switch (reader.NodeType)
            {
                case System.Xml.XmlNodeType.Element: // The node is an element.
                    element = element + reader.Name;
                    while (reader.MoveToNextAttribute())
                    {// Read the attributes.
                        attribute = attribute + reader.Name + "=" + reader.Value + System.Environment.NewLine;
                    }
                    break;
                case System.Xml.XmlNodeType.Text: //Display the text in each element.
                     element = element + "=" + reader.Value + System.Environment.NewLine;
                    break;
                case System.Xml.XmlNodeType.EndElement: //Display the end of the element.
                   
                    
                    break;
            }
        }
        TextBox2.Text = element;
        TextBox3.Text = attribute;
    }
}
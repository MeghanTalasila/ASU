using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Web.Services;
using System.Net;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Solar_Energy_Service
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string MapURL;
            string EnergyXML;
            MapURL = "http://localhost:57717/SolarEnergryService.svc/GetSolarEnergy?Lat=" + TextBox2.Text + "&Lon=" + TextBox3.Text;
            //creating a httpWebRequest for the MapURL to get the data
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MapURL);

            //fetching the web data and storing it in httpWebResponse
            HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //converting the httpWebResponse to a stream of data
            StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream());

            //storing the stream in directionXml
            EnergyXML = streamReader.ReadToEnd();

            //parsing the XML Readaer
            XmlReader xread = XmlReader.Create(new StringReader(EnergyXML));

            xread.ReadToFollowing("string");
            string avgSolarEnergy = xread.ReadString();

            if (avgSolarEnergy.Equals(""))
                Label2.Text = "Enter valid latitude and longitude";
            else
                Label2.Text = avgSolarEnergy;
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
    }
}
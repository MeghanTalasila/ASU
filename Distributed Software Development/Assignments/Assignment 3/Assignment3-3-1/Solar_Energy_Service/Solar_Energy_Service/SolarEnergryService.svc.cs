using System;
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

namespace Solar_Energy_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : SolarEnergyIService
    {
        private string MapURL;
        string URLString = "";
        string URLXML;
        public string GetSolarEnergy(string Lat,string Lon)
        {
            try
            {
                MapURL = "http://developer.nrel.gov/api/solar/solar_resource/v1.xml?api_key=4khMUOuGDoijGqsGvU9M3MwvpoCxywWzUL2NAK9W&lat=" + Lat + "&lon=" + Lon;
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MapURL);
                HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new System.IO.StreamReader(webResponse.GetResponseStream());
                URLXML = streamReader.ReadToEnd();

                XmlReader xread = XmlReader.Create(new StringReader(URLXML));
              
                xread = XmlReader.Create(new StringReader(URLXML));

                while (xread.Read())
                {
                    xread.ReadToFollowing("avg-dni");
                    if ((xread.NodeType == XmlNodeType.Element) && (xread.NodeType != XmlNodeType.EndElement))
                    {
                        xread.ReadToFollowing("annual");
                        URLString = xread.ReadString();
                    }
                }

                return URLString;
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}

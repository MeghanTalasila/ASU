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

namespace Map_Service
{
   
    public class Service1 : DirectionIService1
    {
        private string MapURL;         
        string direction = "";
        string directionXml;   
        public string GetDirections(string source, string destination)
        {
            try
            {
                //the below statement implements maps api
                MapURL = "http://maps.googleapis.com/maps/api/directions/xml?origin=" + source + "&destination=" + destination;

                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MapURL);
                HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream());
                directionXml = streamReader.ReadToEnd();
                XmlReader xread = XmlReader.Create(new StringReader(directionXml));
                
                xread = XmlReader.Create(new StringReader(directionXml));
                int count = 1;
                while (xread.Read())
                {
                    xread.ReadToFollowing("step");

                    if ((xread.NodeType == XmlNodeType.Element) && (xread.NodeType != XmlNodeType.EndElement))
                    {
                        xread.ReadToFollowing("html_instructions");
                        direction = direction + count + ".";
                        direction = direction + xread.ReadString() + Environment.NewLine;
                        count++;
                    }
                }


                //Replace html tags in string with empty character
                direction = Regex.Replace(direction, "<.*?>", string.Empty);
                
                return direction;
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}

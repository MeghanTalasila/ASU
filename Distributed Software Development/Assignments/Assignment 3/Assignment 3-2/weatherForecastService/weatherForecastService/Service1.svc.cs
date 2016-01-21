
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

namespace weatherForecastService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        List<string> tempInfo = new List<string>(); //To store the temperature
        private string MapURL;         //to store the url
        string weatherXml;
         
        public List<string> weatherService(String zipcode)
        {
            try
            {
                //weather forecast API
            MapURL = "http://xml.weather.yahoo.com/forecastrss/" + zipcode + "_f.xml";

            //creating a webrequest for the MapURL to get the data
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MapURL);

            //fetching the web data and storing it in mapresponse
            HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

            //converting the webesponse to a stream of data
            StreamReader streamReader = new System.IO.StreamReader(webResponse.GetResponseStream());

            //storing the stream in XML string
            weatherXml = streamReader.ReadToEnd();

            //xmlreader for parsing
            XmlReader xread = XmlReader.Create(new StringReader(weatherXml));

            string temp = "";
            while (xread.Read())
            {
                if ((xread.NodeType == XmlNodeType.Element) && (xread.Name == "yweather:forecast"))
                {
                    if (xread.HasAttributes)
                    {
                        temp = "";
                        temp = temp + "Day:" + xread.GetAttribute("day");
                        temp = temp + ", Date:" + xread.GetAttribute("date");
                        temp = temp + ", Low Temp :" + xread.GetAttribute("low");
                        temp = temp + ", High Temp :" + xread.GetAttribute("high");
                        temp = temp + ", Weather:" + xread.GetAttribute("text");
                        
                        tempInfo.Add(temp); // Adding items to list
                    }
                        
                }
            }

            return tempInfo; //returning list
        }
             catch (Exception e)
            {
                tempInfo = new List<string>();
                tempInfo.Add(e.ToString());
                return tempInfo;
            }
        }

       
    }
}

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

namespace KeyWordSearch
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        private string MapURL;
        string URLString = "";
        List<string> temp = new List<string>();

        string URLXML;
        int i = 0;

        public string[] GetURL(string keyword)
        {
            try
            {
                //keyword search api
                MapURL = "http://lookup.dbpedia.org/api/search/KeywordSearch?QueryString=" + keyword;

                //creating a webrequest for the MapURL to get the data
                HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(MapURL);

                //fetching the web data and storing it in mapresponse
                HttpWebResponse webResponse = (HttpWebResponse)httpWebRequest.GetResponse();

                //converting the webesponse to a stream of data
                StreamReader streamReader = new System.IO.StreamReader(webResponse.GetResponseStream());

                //storing the stream in XML string
                URLXML = streamReader.ReadToEnd();

                //creating a an xmlreader for parsing
                XmlReader xread = XmlReader.Create(new StringReader(URLXML));


                xread.ReadToFollowing("Label");

                if ((xread.NodeType == XmlNodeType.Element) && (xread.NodeType != XmlNodeType.EndElement))
                {
                    //  URLString = xread.ReadString() + System.Environment.NewLine;
                    temp.Add(xread.ReadString());

                }

                xread.ReadToFollowing("URI");

                if ((xread.NodeType == XmlNodeType.Element) && (xread.NodeType != XmlNodeType.EndElement))
                {
                    temp.Add(xread.ReadString());
                }


                xread = XmlReader.Create(new StringReader(URLXML));

                //fetching the urls
                while (xread.Read())
                {
                    xread.ReadToFollowing("Class");

                    //checking that the node is of type element and not an end node
                    if ((xread.NodeType == XmlNodeType.Element) && (xread.NodeType != XmlNodeType.EndElement))
                    {
                        xread.ReadToFollowing("URI");
                        temp.Add(xread.ReadString());
                    }
                }

                string[] temp2 = temp.ToArray();


                return temp2;
            }
            catch (Exception e)
            {
                string[] temp = new string[] { e.ToString() };
                return temp;
            }
        }
    }
}

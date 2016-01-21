using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Xml;
using System.Xml.Schema;
using System.Xml.XPath;
using System.Xml.Xsl;


namespace ValidationTransformation
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static string returnMsg = "No Error";


        public string VerificationXML(string xsdURL, string xmlURL)
        {
            returnMsg = "No Error";

            //create XmlSchemaSet class.
            XmlSchemaSet sc = new XmlSchemaSet();

            //Add the schema to the collection before performing validation
            sc.Add(null, xsdURL);

            //Set the validation settings
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);

            //Create XMLReader object 
            XmlReader reader = XmlReader.Create(xmlURL, settings);
            try
            {
                //Parse the file 
                while (reader.Read()) { }
            }
            catch (Exception e)
            {
                returnMsg = e.Message.ToString();
            }

            return returnMsg;


        }

        // Display any validation errors 
        public static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            returnMsg = e.Message;
        }

        public string TransformationXML(string xmlURL, string xslURL)
        {
            try
            {
                StringWriter sw = new StringWriter();
                XPathDocument doc = new XPathDocument(xmlURL);
                XslCompiledTransform xslt = new XslCompiledTransform();
                xslt.Load(xslURL);
                xslt.Transform(doc.CreateNavigator(), null, sw);
                return sw.ToString();
            }

            catch (Exception ex)
            {
                return ex.Message;
            }

        }
    }
}

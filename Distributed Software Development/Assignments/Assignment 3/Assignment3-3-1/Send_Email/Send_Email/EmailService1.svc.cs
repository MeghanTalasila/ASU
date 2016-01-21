using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Net;
using System.Net.Mail;
using SendGrid;

namespace Send_Email
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : EmailIService1
    {
         
        public string sendEmail(string from, string to, string sub, string text,string FName)
        {
            try
            {
                // Create the email object first, then add the properties.
                var myMessage = new SendGridMessage();
                List<String> recipients = new List<String>();
                string[] temp = to.Split('#');
                //Adding recipients
                for (int i = 0; i < temp.Length; i++)
                {
                    recipients.Add(@temp[i]);
                }
                myMessage.AddTo(recipients);
                myMessage.From = new MailAddress(from, FName);
                myMessage.Subject = sub;
                myMessage.Text = text;

                // Create credentials, specifying your user name and password.
                var credentials = new NetworkCredential("talasila.meghana", "Talasila@123");

                // Create an Web transport for sending email.
                var transportWeb = new Web(credentials);

                // Send the email.
                transportWeb.Deliver(myMessage);
                return "true";
            }
            catch(Exception e)
            {
                return "false";
            }
        }

    }
}

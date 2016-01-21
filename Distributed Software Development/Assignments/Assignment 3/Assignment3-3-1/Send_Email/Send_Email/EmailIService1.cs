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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface EmailIService1
    {

        [OperationContract]
        string sendEmail(string to, string from, string sub, string text, string FName);
    }
}

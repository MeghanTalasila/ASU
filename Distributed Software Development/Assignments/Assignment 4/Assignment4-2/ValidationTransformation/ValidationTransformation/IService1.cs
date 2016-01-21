using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ValidationTransformation
{

    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string VerificationXML(string xsdURL, string xmlURL);

        [OperationContract]
        string TransformationXML(string xmlURL, string xslURL);


        // TODO: Add your service operations here
    }

}

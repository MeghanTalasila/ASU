using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1_Temperature
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        //Service operation contract for C2F
        [OperationContract]
        Double C2F(Double celsiusTemp);

        //Service operation contract for F2C
        [OperationContract]
        Double F2C(Double fahrenheitTemp);
        
    }
}

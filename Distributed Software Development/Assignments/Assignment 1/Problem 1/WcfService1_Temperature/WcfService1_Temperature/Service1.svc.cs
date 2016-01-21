using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService1_Temperature
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Temperature : IService1
    {
        //Operation to convert Celsius Temperature to Fahrenheit Temperature
        public Double C2F(Double celsiusTemp)
        {
            return (((celsiusTemp * 9) / 5) + 32);
        }

        //Operation to convert Fahrenheit Temperature to Celsius Temperature
        public Double F2C(Double fahrenheitTemp)
        {
            return (((fahrenheitTemp - 32) * 5) / 9);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Solar_Energy_Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface SolarEnergyIService
    {

        [OperationContract]
        [WebGet(UriTemplate = "GetSolarEnergy?Lat={Lat}&Lon={Lon}")]             
        string GetSolarEnergy(string Lat, string Lon);

    }
}

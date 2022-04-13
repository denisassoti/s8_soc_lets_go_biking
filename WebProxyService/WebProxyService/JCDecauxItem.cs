using System;
using System.Collections.Generic;
using System.Linq; 
using System.Text;
using System.Threading.Tasks;
using WebProxyService.ReferenceObjects;

namespace WebProxyService
{
    public class JCDecauxItem
    {
        JCDecauxHttpRequests request = new JCDecauxHttpRequests();
        public DynamicStation station { get; set; }

        public JCDecauxItem(string key)
        {
            string[] identifiers = key.Split('_');
            int stationNumber = int.Parse(identifiers[0]);
            string contractName = identifiers[1];

            station = request.GetStationAvailabilitiesRequest(stationNumber, contractName).Result;
        }
    }
}

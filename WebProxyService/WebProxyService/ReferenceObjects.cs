using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace WebProxyService.ReferenceObjects
{
    // Station myDeserializedClass = JsonConvert.DeserializeObject<Station>(myJsonResponse);

    [DataContract]
    public class Position
    {
        [DataMember] 
        public double latitude { get; set; }

        [DataMember]
        public double longitude { get; set; }

        public Position(double lat, double lng)
        {
            this.latitude = lat;
            this.longitude = lng;
        }
    }

    [DataContract]
    public class Availabilities
    {
        [DataMember]
        public int bikes { get; set; }

        [DataMember]
        public int stands { get; set; }

        [DataMember]
        public int mechanicalBikes { get; set; }

        [DataMember]
        public int electricalBikes { get; set; }

        [DataMember]
        public int electricalInternalBatteryBikes { get; set; }

        [DataMember]
        public int electricalRemovableBatteryBikes { get; set; }
    }

    [DataContract]
    public class TotalStands
    {
        [DataMember]
        public Availabilities availabilities { get; set; }

        [DataMember]
        public int capacity { get; set; }
    }

    [DataContract]
    public class MainStands
    {
        [DataMember]
        public Availabilities availabilities { get; set; }

        [DataMember]
        public int capacity { get; set; }
    }

    [DataContract]
    public class StaticStation
    {
        [DataMember]
        public int number { get; set; }

        [DataMember]
        public string contractName { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public Position position { get; set; }

        public StaticStation(string contract_name)
        {
            this.contractName = contract_name;
        }

    }

    [DataContract]
    public class DynamicStation
    {
        [DataMember]
        public int number { get; set; }

        [DataMember]
        public string contractName { get; set; }

        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string address { get; set; }

        [DataMember]
        public Position position { get; set; }

        [DataMember]
        public string status { get; set; }

        [DataMember]
        public string lastUpdate { get; set; }

        [DataMember]
        public TotalStands totalStands { get; set; }

    }

    [DataContract]
    public class Contract
    {
        [DataMember]
        public string name { get; set; }

        [DataMember]
        public string commercial_name { get; set; }

        [DataMember]
        public List<string> cities { get; set; }

        [DataMember]
        public string country_code { get; set; }
    }

}

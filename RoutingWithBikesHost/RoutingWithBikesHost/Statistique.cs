using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace RoutingWithBikesHost
{

    public enum Usage
    {
        DEPART,
        ARRIVEE
    }


    [DataContract]
    public class Statistique
    {
        [DataMember]
        public int id { get; set; }

        [DataMember]
        public string contractName { get; set; }

        [DataMember]
        public string stationName { get; set; }

        [DataMember]
        public DateTime date { get; set; }

        [DataMember]
        public string usage { get; set; }

        private static int cpt;

        public Statistique(string contractName, string stationName, Usage usage)
        {
            cpt++;
            this.id = cpt;
            this.date = DateTime.Now;
            this.stationName = stationName;
            this.usage = usage.ToString();
            this.contractName = contractName;
        }
    }
}

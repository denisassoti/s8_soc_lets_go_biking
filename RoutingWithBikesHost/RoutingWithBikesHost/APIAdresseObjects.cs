using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoutingWithBikesHost
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Geometry
    {
        public string type { get; set; }
        public List<double> coordinates { get; set; }
    }

    public class Properties
    {
        public string label { get; set; }
        public double score { get; set; }
        public string housenumber { get; set; }
        public string id { get; set; }
        public string name { get; set; }
        public string postcode { get; set; }
        public string citycode { get; set; }
        public double x { get; set; }
        public double y { get; set; }
        public string city { get; set; }
        public string context { get; set; }
        public string type { get; set; }
        public double importance { get; set; }
        public string street { get; set; }
    }

    public class Feature
    {
        public string type { get; set; }
        public Geometry geometry { get; set; }
        public Properties properties { get; set; }
    }

    public class APIAdresse
    {
        public string type { get; set; }
        public string version { get; set; }
        public List<Feature> features { get; set; }
        public string attribution { get; set; }
        public string licence { get; set; }
        public string query { get; set; }
        public int limit { get; set; }
    }

    public class Distance
    {
        public List<List<double>> distances { get; set; }
    }

    public class DistancePayload
    {
        public List<List<double>> locations { get; set; }
        public List<string> metrics { get; set; }
        public string units { get; set; }
        public List<int> destinations { get; set; }
    }


    public class City
    {
        public int code { get; set; }
        public string city { get; set; }
    }

    public class CheckCities
    {
       // public string input { get; set; }
        public List<City> cities { get; set; }
    }

}

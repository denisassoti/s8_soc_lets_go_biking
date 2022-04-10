using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using RoutingWithBikesHost.OpenRouteServiceAPI;
using System.Globalization;
using System.Linq;
using System.IO;
using System.Text;
using System.Net.Http.Headers;

namespace RoutingWithBikesHost
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" à la fois dans le code et le fichier de configuration.
    public class RoutingService : IRoutingService
    {
        static readonly HttpClient client = new HttpClient();
        const string URL = "https://api-adresse.data.gouv.fr";
        //string token2 = "5b3ce3597851110001cf6248456b77127eb844aa95851057438e4686";
        string token = "5b3ce3597851110001cf62487cdad0be1db44f0fbb7027c16c5ef438";
        //foot-walking cycling-electric cycling-road
        string OpenServiceURL = "https://api.openrouteservice.org/v2";

        static WebProxy.ProxyCacheServiceClient proxy = new WebProxy.ProxyCacheServiceClient();

        WebProxy.StaticStation[] stations = proxy.GetStations();

        WebProxy.Contract[] contracts = proxy.GetCities();

        private async Task<OpenRouteService> GetDirections(List<double> depart, List<double> arrivee)
        {
            //CultureInfo.InvariantCulture pour eviter que le float a un , a la place de . exp : 10.6 au lieu de 10,6
            string start = depart[0].ToString(CultureInfo.InvariantCulture) + "," + depart[1].ToString(CultureInfo.InvariantCulture);
            string end = arrivee[0].ToString(CultureInfo.InvariantCulture) + "," + arrivee[1].ToString(CultureInfo.InvariantCulture);
            try
            {

                HttpResponseMessage response = await client.GetAsync(OpenServiceURL + "/directions/cycling-road?api_key=" + token + "&start=" + start + "&end=" + end);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                OpenRouteService direction = JsonConvert.DeserializeObject<OpenRouteService>(responseBody);
                return direction;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("log2.log", true))
                {
                    writer.WriteLine(ex.ToString());
                    writer.WriteLine(OpenServiceURL + token + "&start=" + start + "&end=" + end);
                }
                return null;
            }
        }

        private async Task<CheckCities> GetCitiesFromCP(int cp)
        {
            try
            {
                //API permettant de retrouver les villes d'une adresse postale
                HttpResponseMessage response = await client.GetAsync("https://vicopo.selfbuild.fr/cherche/" + cp);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                CheckCities tab = JsonConvert.DeserializeObject<CheckCities>(responseBody);
                return tab;
            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("log.log", true))
                {
                    writer.WriteLine(ex.ToString());
                }
                return null;
            }
        }
        //should return Itineraire
        public async Task<Itineraire> GetItineraire(string depart, string arrivee)
        {
            try
            {
                APIAdresse adresseDepart = await ConvertAddressToCoordinates(depart);
                APIAdresse adresseArrivee = await ConvertAddressToCoordinates(arrivee);

                //recuperer les coordonnees [lat, long] du depart et de l'arrivee
                List<double> depart_coords = adresseDepart.features[0].geometry.coordinates;
                List<double> arrivee_coords = adresseArrivee.features[0].geometry.coordinates;

                //recuperer la ville de depart et d'arrivee
                string villeDepart = String.Empty;
                string villeArrivee = String.Empty;

                //get the two first digit of the citycode 
                int villeDepart_CP = int.Parse(adresseDepart.features[0].properties.citycode.Substring(0, 2));
                int villeArrivee_CP = int.Parse(adresseArrivee.features[0].properties.citycode.Substring(0, 2));

                CheckCities checkCities_D = await this.GetCitiesFromCP(villeDepart_CP);
                CheckCities checkCities_A = await this.GetCitiesFromCP(villeArrivee_CP);

                Console.WriteLine(villeDepart_CP);
                Console.WriteLine(villeArrivee_CP);

                //verifier  que les villes de depart et d'arrivee possedent des stations jcdecaux

                List<string> jcDeceauxVilles = this.GetContracts();

                int test = 0;
                foreach (City city in checkCities_D.cities)
                {
                    if (jcDeceauxVilles.Contains(city.city.ToLower()))
                    {
                        villeDepart = city.city.ToLower();
                        test++;
                        break;
                    }
                }

                foreach (City city in checkCities_A.cities)
                {
                    if (jcDeceauxVilles.Contains(city.city.ToLower()))
                    {
                        villeArrivee = city.city.ToLower();
                        test++;
                        break;
                    }
                }

                Console.WriteLine(test);

                if (test != 2)
                {
                    return null;
                }

                //trouver les stations de depart et d'arrivee
                WebProxy.DynamicStation station_depart = this.GetStartStationWithDisponibleBikes(depart_coords, villeDepart);
                WebProxy.DynamicStation station_arrivee = this.GetEndStationWithDisponibleStands(arrivee_coords, villeArrivee);

                // OpenService position = [lng, lat]
                List<double> sD_coords = new List<double> { station_depart.position.longitude, station_depart.position.latitude };
                List<double> sA_coords = new List<double> { station_arrivee.position.longitude, station_arrivee.position.latitude };


                //itineraire entre depart et stationDepart
                OpenRouteService oprD_sD = await GetDirections(depart_coords, sD_coords);

                //itineraire entre stationdepart et stationArrivee
                OpenRouteService oprsD_sA = await GetDirections(sD_coords, sA_coords);

                //itineraire entre stationArrivee et arrivee
                OpenRouteService oprsA_A = await GetDirections(sA_coords, arrivee_coords);

                Itineraire route = new Itineraire();
                route.depart_stationDepart = oprD_sD;
                route.stationDepart_stationArrivee = oprsD_sA;
                route.stationArrivee_arrivee = oprsA_A;
                route.stationDepart = station_depart.name;
                route.stationArrivee = station_arrivee.name;
                //Console.WriteLine("yooooooo");
                return route;

            }
            catch (Exception ex)
            {
                using (StreamWriter writer = new StreamWriter("log.log", true))
                {
                    writer.WriteLine(ex.ToString());
                }
                return null;
            }
        }

        public WebProxy.StaticStation[] GetStations()
        {
            return this.stations;
        }

        public List<string> GetContracts()
        {
            List<string> villes = new List<string>();

            foreach (WebProxy.Contract contract in this.contracts)
            {
                // Console.WriteLine(contract.name);
                villes.Add(contract.name);
            }
            return villes;
        }

        //public async Task<Position> GetPositionForAddress(string address)
        public async Task<APIAdresse> ConvertAddressToCoordinates(string address)
        {
            //appel a l'api adresse.data.gouv.fr pour retrouver les coordonnees d'une adresse

            HttpResponseMessage response = await client.GetAsync(URL + "/search?q=" + address);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            APIAdresse tab = JsonConvert.DeserializeObject<APIAdresse>(responseBody);

            //return tab.features[0].geometry.coordinates;
            return tab;
        }

        //permet de trouver la station de depart la plus proche (status="OPEN" et totalStands.availabilities.bikes>0)
        public WebProxy.DynamicStation GetStartStationWithDisponibleBikes(List<double> depart_coords, string ville)
        {
            WebProxy.Position depart_position = new WebProxy.Position();
            depart_position.latitude = depart_coords[0];
            depart_position.longitude = depart_coords[1];

            WebProxy.StaticStation staticStation = null;
            List<double> distances = new List<double>();

            //resuperer toutes les stations de la ville avec requete Linq
            List<WebProxy.StaticStation> ville_stations = this.stations.Where(station => station.contractName.ToLower() == ville).ToList();

            foreach (WebProxy.StaticStation station in ville_stations)
            {
                double distance = this.GetDistanceBetween2GpsCoordinates(depart_position, station.position);
                distances.Add(distance);
            }
            //Console.WriteLine(distances.Count);

            WebProxy.DynamicStation dynamicStation = null;
             while (dynamicStation == null)
             {
                 int index = distances.IndexOf(distances.Min());
                 staticStation = ville_stations[index];
                 dynamicStation = proxy.GetOneStation(staticStation.number, staticStation.contractName);
                Console.WriteLine(dynamicStation.name);

                 if (dynamicStation.status == "OPEN" && dynamicStation.totalStands.availabilities.bikes > 0)
                     return dynamicStation;

                 distances.RemoveAt(index);
                 dynamicStation = null;
             }
            return null;
        }

        //permet de trouver la station de d'arrivee la plus proche (status="OPEN" et totalStands.availabilities.stands>0)
        public WebProxy.DynamicStation GetEndStationWithDisponibleStands(List<double> arrivee_coords, string ville)
        {
            WebProxy.Position arrivee_position = new WebProxy.Position();
            arrivee_position.latitude = arrivee_coords[0];
            arrivee_position.longitude = arrivee_coords[1];

            WebProxy.StaticStation staticStation = null;
            List<double> distances = new List<double>();

            List<WebProxy.StaticStation> ville_stations = this.stations.Where(station => station.contractName.ToLower() == ville).ToList();

            foreach (WebProxy.StaticStation station in ville_stations)
            {
                double distance = this.GetDistanceBetween2GpsCoordinates(arrivee_position, station.position);
                distances.Add(distance);
            }

            WebProxy.DynamicStation dynamicStation = null;
             while (dynamicStation == null)
             {
                 int index = distances.IndexOf(distances.Min());
                 staticStation = ville_stations[index];
                 dynamicStation = proxy.GetOneStation(staticStation.number, staticStation.contractName);

                 if (dynamicStation.status == "OPEN" && dynamicStation.totalStands.availabilities.stands > 0)
                     return dynamicStation;

                 distances.RemoveAt(index);
                 dynamicStation = null;
             }
            return null;
        }


        //distance en km
        // private double GetDistanceBetween2GpsCoordinates(WebProxy.Position p1, WebProxy.Position p2)
        private double GetDistanceBetween2GpsCoordinates(WebProxy.Position p1, WebProxy.Position p2)
        {
            var rlat1 = Math.PI * p1.longitude / 180;
            var rlat2 = Math.PI * p2.latitude / 180;
            var rlon1 = Math.PI * p1.latitude / 180;
            var rlon2 = Math.PI * p2.longitude / 180;

            var theta = p1.latitude - p2.longitude;
            var rtheta = Math.PI * theta / 180;

            var dist = Math.Sin(rlat1) * Math.Sin(rlat2) + Math.Cos(rlat1) * Math.Cos(rlat2) * Math.Cos(rtheta);
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            dist = dist * 1.609344;
            return dist;
        }


        //[lng, lat] foot-walking distance
        /* private async Task<double> GetDistanceBetween2GpsCoordinates(WebProxy.Position p1, WebProxy.Position p2)
         {

             string p1_lat = p1.latitude.ToString(CultureInfo.InvariantCulture);
             string p1_lon = p1.longitude.ToString(CultureInfo.InvariantCulture);
             string p2_lat = p2.latitude.ToString(CultureInfo.InvariantCulture);
             string p2_lon = p2.longitude.ToString(CultureInfo.InvariantCulture); 

             DistancePayload distancePayload = new DistancePayload();
             distancePayload.units = "km";
             distancePayload.metrics = new List<string> { "distance" };
             distancePayload.locations = new List<List<double>> { new List<double>() { p1.latitude, p1.longitude }, new List<double> {p2.longitude, p2.latitude } };

             var  payload = JsonConvert.SerializeObject(distancePayload);


             //var payload2 = "{\"locations\":[[" + p1_lat + "," + p1_lon + "],[" + p2_lon + "," + p2_lat + "]],\"metrics\":[\"distance\"],\"units\":\"km\"}";
             //payload = JsonConvert.DeserializeObject(payload);
             try
             {

                 client.DefaultRequestHeaders.Accept.Clear();
                 client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token2);

                 client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                // client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Authorization", "xxx");


                 HttpContent content = new StringContent(payload, Encoding.UTF8, "application/json");

                 HttpResponseMessage response = await client.PostAsync(OpenServiceURL + "/matrix/driving-car", content);
                 response.EnsureSuccessStatusCode();
                 var responseBody = await response.Content.ReadAsStringAsync();

                 Distance distance = JsonConvert.DeserializeObject<Distance>(responseBody);
                 return distance.distances[0][1];
             }
             catch (Exception ex)
             {
                 using (StreamWriter writer = new StreamWriter("log7.log", true))
                 {
                     writer.WriteLine(ex.ToString());
                     writer.WriteLine(payload);
                     //writer.WriteLine(OpenServiceURL + "/matrix/foot-walking");
                 }
                 return double.NaN;
             } */

        // }
    }
}

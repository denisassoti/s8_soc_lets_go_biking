using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WebProxyService.ReferenceObjects;
//using System.Text.Json;

namespace WebProxyService
{
    public class JCDecauxHttpRequests
    {
        private const string URL = "https://api.jcdecaux.com/vls/v3";
        private const string API_KEY = "f2fb1e333e073677b8625ed9cc3c414e5edfa940";
        private static readonly HttpClient client = new HttpClient();

        public async Task<List<StaticStation>> GetAllStationsRequest()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/stations?apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                List<StaticStation> stations = JsonConvert.DeserializeObject<List<StaticStation>>(responseBody);

                return stations;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
            }

            return null;
        }

        public async Task<DynamicStation> GetStationAvailabilitiesRequest(int stationNumber, string contractName)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/stations/"+stationNumber+"?contract="+contractName+"&apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                DynamicStation station = JsonConvert.DeserializeObject<DynamicStation>(responseBody);

                return station;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }
        }

        public async Task<List<Contract>> GetAllCities()
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync(URL + "/contracts?apiKey=" + API_KEY);
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();

                List<Contract> cities = JsonConvert.DeserializeObject<List<Contract>>(responseBody);

                return cities;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("\nException Caught!");
                Console.WriteLine("Message :{0} ", e.Message);
                return null;
            }

        }
    }
}

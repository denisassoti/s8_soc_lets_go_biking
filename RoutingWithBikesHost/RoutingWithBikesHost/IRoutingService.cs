using RoutingWithBikesHost.OpenRouteServiceAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace RoutingWithBikesHost
{
    [ServiceContract]
    public interface IRoutingService
    {

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "stations")]
        WebProxy.StaticStation[] GetStations(); //a l'initialisation du serveur pour recuperer toutes les stations

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "contracts")]
        List<string> GetContracts(); //a l'initialisation du serveur pour recuperer toutes les villes

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "itineraire?depart={depart}&arrivee={arrivee}")]
        Task<OpenRouteServiceAPI.Itineraire> GetItineraire(string depart, string arrivee);

       /* [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped, UriTemplate = "convert_address_to_coordinates?address={address}")]
        Task<List<double>> ConvertAddressToCoordinates(string address); */

    }

}

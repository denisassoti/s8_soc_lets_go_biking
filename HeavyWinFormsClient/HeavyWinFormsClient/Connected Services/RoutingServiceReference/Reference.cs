﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Ce code a été généré par un outil.
//
//     Les changements apportés à ce fichier peuvent provoquer un comportement incorrect et seront perdus si
//     le code est regénéré.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RoutingServiceReference
{
    using System.Runtime.Serialization;
    
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="StaticStation", Namespace="http://schemas.datacontract.org/2004/07/WebProxyService.ReferenceObjects")]
    public partial class StaticStation : object
    {
        
        private string addressField;
        
        private string contractNameField;
        
        private string nameField;
        
        private int numberField;
        
        private RoutingServiceReference.Position positionField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string address
        {
            get
            {
                return this.addressField;
            }
            set
            {
                this.addressField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string contractName
        {
            get
            {
                return this.contractNameField;
            }
            set
            {
                this.contractNameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int number
        {
            get
            {
                return this.numberField;
            }
            set
            {
                this.numberField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Position position
        {
            get
            {
                return this.positionField;
            }
            set
            {
                this.positionField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Position", Namespace="http://schemas.datacontract.org/2004/07/WebProxyService.ReferenceObjects")]
    public partial class Position : object
    {
        
        private double latitudeField;
        
        private double longitudeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double latitude
        {
            get
            {
                return this.latitudeField;
            }
            set
            {
                this.latitudeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double longitude
        {
            get
            {
                return this.longitudeField;
            }
            set
            {
                this.longitudeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Itineraire", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Itineraire : object
    {
        
        private RoutingServiceReference.OpenRouteService depart_stationDepartField;
        
        private string stationArriveeField;
        
        private RoutingServiceReference.OpenRouteService stationArrivee_arriveeField;
        
        private string stationDepartField;
        
        private RoutingServiceReference.OpenRouteService stationDepart_stationArriveeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.OpenRouteService depart_stationDepart
        {
            get
            {
                return this.depart_stationDepartField;
            }
            set
            {
                this.depart_stationDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string stationArrivee
        {
            get
            {
                return this.stationArriveeField;
            }
            set
            {
                this.stationArriveeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.OpenRouteService stationArrivee_arrivee
        {
            get
            {
                return this.stationArrivee_arriveeField;
            }
            set
            {
                this.stationArrivee_arriveeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string stationDepart
        {
            get
            {
                return this.stationDepartField;
            }
            set
            {
                this.stationDepartField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.OpenRouteService stationDepart_stationArrivee
        {
            get
            {
                return this.stationDepart_stationArriveeField;
            }
            set
            {
                this.stationDepart_stationArriveeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="OpenRouteService", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class OpenRouteService : object
    {
        
        private double[] bboxField;
        
        private RoutingServiceReference.Feature[] featuresField;
        
        private string typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] bbox
        {
            get
            {
                return this.bboxField;
            }
            set
            {
                this.bboxField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Feature[] features
        {
            get
            {
                return this.featuresField;
            }
            set
            {
                this.featuresField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Feature", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Feature : object
    {
        
        private double[] bboxField;
        
        private RoutingServiceReference.Geometry geometryField;
        
        private RoutingServiceReference.Properties propertiesField;
        
        private string typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[] bbox
        {
            get
            {
                return this.bboxField;
            }
            set
            {
                this.bboxField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Geometry geometry
        {
            get
            {
                return this.geometryField;
            }
            set
            {
                this.geometryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Properties properties
        {
            get
            {
                return this.propertiesField;
            }
            set
            {
                this.propertiesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Geometry", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Geometry : object
    {
        
        private double[][] coordinatesField;
        
        private string typeField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double[][] coordinates
        {
            get
            {
                return this.coordinatesField;
            }
            set
            {
                this.coordinatesField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Properties", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Properties : object
    {
        
        private RoutingServiceReference.Segment[] segmentsField;
        
        private RoutingServiceReference.Summary summaryField;
        
        private int[] way_pointsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Segment[] segments
        {
            get
            {
                return this.segmentsField;
            }
            set
            {
                this.segmentsField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Summary summary
        {
            get
            {
                return this.summaryField;
            }
            set
            {
                this.summaryField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] way_points
        {
            get
            {
                return this.way_pointsField;
            }
            set
            {
                this.way_pointsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Summary", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Summary : object
    {
        
        private double distanceField;
        
        private double durationField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Segment", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Segment : object
    {
        
        private double distanceField;
        
        private double durationField;
        
        private RoutingServiceReference.Step[] stepsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public RoutingServiceReference.Step[] steps
        {
            get
            {
                return this.stepsField;
            }
            set
            {
                this.stepsField = value;
            }
        }
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.Runtime.Serialization.DataContractAttribute(Name="Step", Namespace="http://schemas.datacontract.org/2004/07/RoutingWithBikesHost.OpenRouteServiceAPI")]
    public partial class Step : object
    {
        
        private double distanceField;
        
        private double durationField;
        
        private string instructionField;
        
        private string nameField;
        
        private int typeField;
        
        private int[] way_pointsField;
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public double duration
        {
            get
            {
                return this.durationField;
            }
            set
            {
                this.durationField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string instruction
        {
            get
            {
                return this.instructionField;
            }
            set
            {
                this.instructionField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }
        
        [System.Runtime.Serialization.DataMemberAttribute()]
        public int[] way_points
        {
            get
            {
                return this.way_pointsField;
            }
            set
            {
                this.way_pointsField = value;
            }
        }
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    [System.ServiceModel.ServiceContractAttribute(ConfigurationName="RoutingServiceReference.IRoutingService")]
    public interface IRoutingService
    {
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/GetStations", ReplyAction="http://tempuri.org/IRoutingService/GetStationsResponse")]
        RoutingServiceReference.StaticStation[] GetStations();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/GetStations", ReplyAction="http://tempuri.org/IRoutingService/GetStationsResponse")]
        System.Threading.Tasks.Task<RoutingServiceReference.StaticStation[]> GetStationsAsync();
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/GetItineraire", ReplyAction="http://tempuri.org/IRoutingService/GetItineraireResponse")]
        RoutingServiceReference.Itineraire GetItineraire(string depart, string arrivee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/GetItineraire", ReplyAction="http://tempuri.org/IRoutingService/GetItineraireResponse")]
        System.Threading.Tasks.Task<RoutingServiceReference.Itineraire> GetItineraireAsync(string depart, string arrivee);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/ConvertAddressToCoordinates", ReplyAction="http://tempuri.org/IRoutingService/ConvertAddressToCoordinatesResponse")]
        double[] ConvertAddressToCoordinates(string address);
        
        [System.ServiceModel.OperationContractAttribute(Action="http://tempuri.org/IRoutingService/ConvertAddressToCoordinates", ReplyAction="http://tempuri.org/IRoutingService/ConvertAddressToCoordinatesResponse")]
        System.Threading.Tasks.Task<double[]> ConvertAddressToCoordinatesAsync(string address);
    }
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public interface IRoutingServiceChannel : RoutingServiceReference.IRoutingService, System.ServiceModel.IClientChannel
    {
    }
    
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
    public partial class RoutingServiceClient : System.ServiceModel.ClientBase<RoutingServiceReference.IRoutingService>, RoutingServiceReference.IRoutingService
    {
        
        /// <summary>
        /// Implémentez cette méthode partielle pour configurer le point de terminaison de service.
        /// </summary>
        /// <param name="serviceEndpoint">Point de terminaison à configurer</param>
        /// <param name="clientCredentials">Informations d'identification du client</param>
        static partial void ConfigureEndpoint(System.ServiceModel.Description.ServiceEndpoint serviceEndpoint, System.ServiceModel.Description.ClientCredentials clientCredentials);
        
        public RoutingServiceClient() : 
                base(RoutingServiceClient.GetDefaultBinding(), RoutingServiceClient.GetDefaultEndpointAddress())
        {
            this.Endpoint.Name = EndpointConfiguration.BasicHttpBinding_IRoutingService.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingServiceClient(EndpointConfiguration endpointConfiguration) : 
                base(RoutingServiceClient.GetBindingForEndpoint(endpointConfiguration), RoutingServiceClient.GetEndpointAddress(endpointConfiguration))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingServiceClient(EndpointConfiguration endpointConfiguration, string remoteAddress) : 
                base(RoutingServiceClient.GetBindingForEndpoint(endpointConfiguration), new System.ServiceModel.EndpointAddress(remoteAddress))
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingServiceClient(EndpointConfiguration endpointConfiguration, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(RoutingServiceClient.GetBindingForEndpoint(endpointConfiguration), remoteAddress)
        {
            this.Endpoint.Name = endpointConfiguration.ToString();
            ConfigureEndpoint(this.Endpoint, this.ClientCredentials);
        }
        
        public RoutingServiceClient(System.ServiceModel.Channels.Binding binding, System.ServiceModel.EndpointAddress remoteAddress) : 
                base(binding, remoteAddress)
        {
        }
        
        public RoutingServiceReference.StaticStation[] GetStations()
        {
            return base.Channel.GetStations();
        }
        
        public System.Threading.Tasks.Task<RoutingServiceReference.StaticStation[]> GetStationsAsync()
        {
            return base.Channel.GetStationsAsync();
        }
        
        public RoutingServiceReference.Itineraire GetItineraire(string depart, string arrivee)
        {
            return base.Channel.GetItineraire(depart, arrivee);
        }
        
        public System.Threading.Tasks.Task<RoutingServiceReference.Itineraire> GetItineraireAsync(string depart, string arrivee)
        {
            return base.Channel.GetItineraireAsync(depart, arrivee);
        }
        
        public double[] ConvertAddressToCoordinates(string address)
        {
            return base.Channel.ConvertAddressToCoordinates(address);
        }
        
        public System.Threading.Tasks.Task<double[]> ConvertAddressToCoordinatesAsync(string address)
        {
            return base.Channel.ConvertAddressToCoordinatesAsync(address);
        }
        
        public virtual System.Threading.Tasks.Task OpenAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginOpen(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndOpen));
        }
        
        public virtual System.Threading.Tasks.Task CloseAsync()
        {
            return System.Threading.Tasks.Task.Factory.FromAsync(((System.ServiceModel.ICommunicationObject)(this)).BeginClose(null, null), new System.Action<System.IAsyncResult>(((System.ServiceModel.ICommunicationObject)(this)).EndClose));
        }
        
        private static System.ServiceModel.Channels.Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRoutingService))
            {
                System.ServiceModel.BasicHttpBinding result = new System.ServiceModel.BasicHttpBinding();
                result.MaxBufferSize = int.MaxValue;
                result.ReaderQuotas = System.Xml.XmlDictionaryReaderQuotas.Max;
                result.MaxReceivedMessageSize = int.MaxValue;
                result.AllowCookies = true;
                return result;
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
        {
            if ((endpointConfiguration == EndpointConfiguration.BasicHttpBinding_IRoutingService))
            {
                return new System.ServiceModel.EndpointAddress("http://localhost:8733/Design_Time_Addresses/RoutingWithBikesHost/RoutingService/");
            }
            throw new System.InvalidOperationException(string.Format("Le point de terminaison nommé \'{0}\' est introuvable.", endpointConfiguration));
        }
        
        private static System.ServiceModel.Channels.Binding GetDefaultBinding()
        {
            return RoutingServiceClient.GetBindingForEndpoint(EndpointConfiguration.BasicHttpBinding_IRoutingService);
        }
        
        private static System.ServiceModel.EndpointAddress GetDefaultEndpointAddress()
        {
            return RoutingServiceClient.GetEndpointAddress(EndpointConfiguration.BasicHttpBinding_IRoutingService);
        }
        
        public enum EndpointConfiguration
        {
            
            BasicHttpBinding_IRoutingService,
        }
    }
}
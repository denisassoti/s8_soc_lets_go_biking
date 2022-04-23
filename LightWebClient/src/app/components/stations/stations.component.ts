import { Component, AfterViewInit } from '@angular/core';
import * as L from 'leaflet';
import * as geojson from 'geojson';
import { ActivatedRoute } from '@angular/router';
import { Stations,  Villes} from '../../objects/objects';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-stations',
  templateUrl: './stations.component.html',
  styleUrls: ['./stations.component.css']
})
export class StationsComponent implements AfterViewInit {
  isLoading = false;
  map: any;
  stations: Stations | undefined;
  search_stations: Stations = { GetStationsResult: [] };
  formGroup: FormGroup = new FormGroup({});
  ville_search: string | undefined;
  villes: Villes = {GetContractsResult: [] };

  initializeMap() {
    //this.isLoading = false;
    this.map = L.map('map', {
      //center: L.latLng(46.227638, 2.213749),
        zoom: 6
    });
    var openStreetLayer = new    L.TileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      minZoom: 3,
      maxZoom: 18,
      attribution: '<a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>'
    });
    openStreetLayer.addTo(this.map);

    var wMaps = new L.TileLayer('http://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png', {
      minZoom: 3,
      maxZoom: 25,
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    });

    var satellite = new L.TileLayer('http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', {
      minZoom: 3,
      maxZoom: 25,
      attribution: 'Tiles &copy; Esri &mdash; Source: Esri, i-cubed, USDA, USGS, AEX, GeoEye, Getmapping, Aerogrid, IGN, IGP, UPR-EGP, and the GIS User Community'
    });


    openStreetLayer.addTo(this.map);

    var baseLayers = {
      'OpenStreetMap': openStreetLayer,
      'Wikimedia Maps': wMaps,
      'Satellite Imagery': satellite
    };

    var overlays = {
      // "Départ": this.rootObject.features[0],
      // "Arrivée": roadsLayer
    };

    L.control.layers(baseLayers, overlays).addTo(this.map);
    //markers
    var icon = L.icon({
      // iconUrl: 'leaflet/bike-marker1.png',
      iconUrl: 'leaflet/bike-marker2.png',
      shadowUrl: 'leaflet/marker-shadow.png',
      iconSize: [38, 95],
      shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
    });

    if (this.search_stations.GetStationsResult.length > 0) {
      //for (let i = 0; i < this.stations.GetStationsResult.length; i++) {
      var markerBounds = L.latLngBounds(L.latLng(this.search_stations.GetStationsResult[0].position.latitude, this.search_stations.GetStationsResult[0].position.longitude), L.latLng(this.search_stations.GetStationsResult[this.search_stations.GetStationsResult.length-1].position.latitude, this.search_stations.GetStationsResult[this.search_stations.GetStationsResult.length-1].position.longitude)); // premier et derier point de la ligne
      this.map.fitBounds(markerBounds, { padding: [0, 0], maxZoom: 30, zoom: 5 });
      for (let i = 0; i < this.search_stations.GetStationsResult.length; i++) {
        var d_sd_geojsonPoint: geojson.Point = {
            type: "Point",
            coordinates: [this.search_stations.GetStationsResult[i].position.longitude, this.search_stations.GetStationsResult[i].position.latitude],
        };
        var marker = L.geoJSON(d_sd_geojsonPoint, {
            pointToLayer: (point,latlon)=> {
              return L.marker(latlon, {icon: icon})
          }
        });
        marker.bindPopup(this.search_stations.GetStationsResult[i].address);
        marker.addTo(this.map);
      }
    }

  }

  handleSearch() {
    this.isLoading = true;
    //filter stations by sontractname
    if (this.stations != undefined) {
      this.search_stations.GetStationsResult = this.stations.GetStationsResult.filter(station => station.contractName.toLowerCase().includes(this.ville_search!.toLowerCase()));
     // console.log(this.search_stations);
      this.initializeMap();
    }
  }

  constructor(private router: ActivatedRoute) {

  }
  ngAfterViewInit(): void {
    this.router.queryParams.subscribe((params: any) => {
      this.stations = JSON.parse(params.param);
      this.villes = JSON.parse(params.villes);
      console.log(this.villes);
      //console.log(this.stations);
    });
  }
}

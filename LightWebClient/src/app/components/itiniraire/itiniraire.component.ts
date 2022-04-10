import { Component, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RootObject, Step, OpenRouteService } from '../../objects/objects';
import * as L from 'leaflet';
import * as geojson from 'geojson';

@Component({
  selector: 'app-itiniraire',
  templateUrl: './itiniraire.component.html',
  styleUrls: ['./itiniraire.component.css']
})
export class ItiniraireComponent implements AfterViewInit {

  depart: string = '';
  arrivee: string = '';
  rootObject: RootObject | undefined;

  depart_stationDepart: OpenRouteService | undefined;
  stationDepart_stationArrivee: OpenRouteService | undefined;
  stationArrivee_arrivee: OpenRouteService | undefined;

  stationDepart_name: string | undefined;
  stationArrivee_name: string | undefined;

  d_sd_steps: Step[] | undefined; //steps between depart and station depart
  sd_sa_steps: Step[] | undefined; // steps between station depart and station arrivee
  sa_a_steps: Step[] | undefined; // steps between station arrivee and arrivee

  map: any;

  initializeMap() {

    this.map = L.map('map', {
      // center: L.latLng(43.684162, 7.202457),
      zoom: 25
    });

    var openStreetLayer = new L.TileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
      minZoom: 3,
      maxZoom: 25,
      attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    });

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
     // Add custom icon
    var icon = L.icon({
      iconUrl: 'leaflet/marker.webp',
      shadowUrl: 'leaflet/marker-shadow.png',
      iconSize: [38, 95],
      shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
    });

    var red_icon = L.icon({
      iconUrl: 'leaflet/red-marker.png',
      shadowUrl: 'leaflet/marker-shadow.png',
      iconSize: [38, 95],
      shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
    });

    var bike_icon = L.icon({
      iconUrl: 'leaflet/bike-marker2.png',
      shadowUrl: 'leaflet/marker-shadow.png',
      iconSize: [38, 95],
      shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
    });

    if (this.rootObject != undefined) {

      this.depart_stationDepart = this.rootObject.GetItineraireResult.depart_stationDepart;
      this.stationDepart_stationArrivee = this.rootObject.GetItineraireResult.stationDepart_stationArrivee;
      this.stationArrivee_arrivee = this.rootObject.GetItineraireResult.stationArrivee_arrivee;

      this.d_sd_steps = this.depart_stationDepart.features[0].properties.segments[0].steps;
      this.sd_sa_steps = this.stationDepart_stationArrivee.features[0].properties.segments[0].steps;
      this.sa_a_steps = this.stationArrivee_arrivee.features[0].properties.segments[0].steps;

      this.stationDepart_name = this.rootObject.GetItineraireResult.stationDepart;
      this.stationArrivee_name = this.rootObject.GetItineraireResult.stationArrivee;

      // depart => station depart
      var d_sd_geojson_data: geojson.FeatureCollection = JSON.parse(JSON.stringify(this.depart_stationDepart));

      var d_sd_geojson = L.geoJSON(d_sd_geojson_data, {
        pointToLayer: function (feature, latlng) {
          return L.marker(latlng, { icon: icon });
        }
      });

      d_sd_geojson.addTo(this.map);
      var d_sd_coordinates = this.depart_stationDepart.features[0].geometry.coordinates;
      var d_sd_geojsonPoint1: geojson.Point = {
        type: "Point",
        coordinates: d_sd_coordinates[0],
      };

      var marker1 = L.geoJSON(d_sd_geojsonPoint1, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: icon})
      }
      });
      marker1.bindPopup("Départ : "+this.depart);
      marker1.addTo(this.map);

      var d_sd_geojsonPoint2: geojson.Point = {
        type: "Point",
        coordinates: d_sd_coordinates[d_sd_coordinates.length - 1],
      };
      var marker2 = L.geoJSON(d_sd_geojsonPoint2, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: bike_icon})
      }
      });
      marker2.bindPopup("Station de départ : "+this.stationDepart_name);
      marker2.addTo(this.map);


      // station depart => station arrivee
      var sd_sa_geojson_data: geojson.FeatureCollection = JSON.parse(JSON.stringify(this.stationDepart_stationArrivee));

      var sd_sa_geojson = L.geoJSON(sd_sa_geojson_data, {
        pointToLayer: function (feature, latlng) {
          return L.marker(latlng, { icon: icon });
        },
        style: function (feature) {
          return { color: 'red' };
        }
      });

      sd_sa_geojson.addTo(this.map);

      var sd_sa_coordinates = this.stationDepart_stationArrivee.features[0].geometry.coordinates;

      var sd_sa_geojsonPoint2: geojson.Point = {
        type: "Point",
        coordinates: sd_sa_coordinates[sd_sa_coordinates.length - 1],
      };
      var marker3 = L.geoJSON(sd_sa_geojsonPoint2, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: bike_icon})
        }
      });
      marker3.bindPopup("Station d'arrivée : "+this.stationArrivee_name);
      marker3.addTo(this.map);

      // station arrivee => arrivee
       var sa_a_geojson_data: geojson.FeatureCollection = JSON.parse(JSON.stringify(this.stationArrivee_arrivee));

      var sa_a_geojson = L.geoJSON(sa_a_geojson_data, {
        pointToLayer: function (feature, latlng) {
          return L.marker(latlng, { icon: icon });
        }
      });

      sa_a_geojson.addTo(this.map);

      var sa_a_coordinates = this.stationArrivee_arrivee.features[0].geometry.coordinates;
      var sa_a_geojsonPoint1: geojson.Point = {
        type: "Point",
        coordinates: sa_a_coordinates[sa_a_coordinates.length - 1],
      };
      var marker4 = L.geoJSON(sa_a_geojsonPoint1, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: red_icon})
        }
      });
      marker4.bindPopup("Arrivée : "+this.arrivee);
      marker4.addTo(this.map);


      var markerBounds = L.latLngBounds(L.latLng(d_sd_coordinates[0][1], d_sd_coordinates[0][0]), L.latLng(sd_sa_coordinates[sd_sa_coordinates.length - 1][1], sd_sa_coordinates[sd_sa_coordinates.length - 1][0])); // premier et derier point de la ligne
      this.map.fitBounds(markerBounds, { padding: [0, 0], maxZoom: 30, zoom: 15 });

    }
  }

  constructor(private router: ActivatedRoute) { }

  ngAfterViewInit(): void {

    this.router.queryParams.subscribe((params: any) => {

      this.rootObject = JSON.parse(params.param);
      this.depart = params.depart;
      this.arrivee = params.arrivee;

      console.log(this.rootObject);

    });
    this.initializeMap();
  }
}

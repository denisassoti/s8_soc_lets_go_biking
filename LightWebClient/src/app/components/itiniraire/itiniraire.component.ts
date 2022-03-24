import { Component, AfterViewInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RootObject, Step } from '../../objects/objects';
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
  steps: Step[] | undefined;

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
      iconUrl: 'leaflet/marker-icon.png',
      shadowUrl: 'leaflet/marker-shadow.png',
      iconSize: [38, 95],
      shadowSize: [50, 64],
      iconAnchor: [22, 94],
      shadowAnchor: [4, 62],
    });

    if (this.rootObject != undefined) {
      //console.log(this.rootObject.GetItineraireResult);
      this.steps = this.rootObject.GetItineraireResult.features[0].properties.segments[0].steps;
      console.log(this.steps);
      //innerHTML = this.steps[0].instruction;


      var geojson_data: geojson.FeatureCollection = JSON.parse(JSON.stringify(this.rootObject.GetItineraireResult));

      var geojson = L.geoJSON(geojson_data, {
        pointToLayer: function (feature, latlng) {
          return L.marker(latlng, { icon: icon });
        }
      });

      geojson.addTo(this.map);

      var coordinates = this.rootObject.GetItineraireResult.features[0].geometry.coordinates;
      //marker debut
      var geojsonPoint: geojson.Point = {
        type: "Point",
        coordinates: coordinates[0],
      };
      var marker = L.geoJSON(geojsonPoint, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: icon})
      }
      });
      //Add popup message
      marker.bindPopup(this.depart);
      marker.addTo(this.map);

      //marker fin
      var geojsonPoint2: geojson.Point = {
        type: "Point",
        coordinates: coordinates[coordinates.length - 1],
      };
      var marker2 = L.geoJSON(geojsonPoint2, {
        pointToLayer: (point,latlon)=> {
          return L.marker(latlon, {icon: icon})
      }
      });
      //Add popup message
      marker2.bindPopup(this.arrivee);
      marker2.addTo(this.map);

      var markerBounds = L.latLngBounds(L.latLng(coordinates[0][1], coordinates[0][0]), L.latLng(coordinates[coordinates.length - 1][1], coordinates[coordinates.length - 1][0])); // premier et derier point de la ligne
      this.map.fitBounds(markerBounds, { padding: [0, 0], maxZoom: 20 });

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

import { Component, OnInit } from '@angular/core';
import { icon, latLng, Map, marker, point, polyline, tileLayer } from 'leaflet';
import { ActivatedRoute } from '@angular/router';
import { RootObject } from '../../objects/objects';
import { geoJSON } from 'leaflet';

@Component({
  selector: 'app-itiniraire',
  templateUrl: './itiniraire.component.html',
  styleUrls: ['./itiniraire.component.css']
})
export class ItiniraireComponent implements OnInit {
  //? les coodrdonnees sont  entre 180 et -180

  depart: string = '';
  arrivee: string = '';
  rootObject: RootObject | undefined;

  // Define our base layers so we can reference them multiple times
  streetMaps = tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    detectRetina: true,
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
  });
  wMaps = tileLayer('http://maps.wikimedia.org/osm-intl/{z}/{x}/{y}.png', {
    detectRetina: true,
    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
  });

  satellite = tileLayer('http://server.arcgisonline.com/ArcGIS/rest/services/World_Imagery/MapServer/tile/{z}/{y}/{x}', {
    detectRetina: true,
    attribution: 'Tiles &copy; Esri &mdash; Source: Esri, i-cubed, USDA, USGS, AEX, GeoEye, Getmapping, Aerogrid, IGN, IGP, UPR-EGP, and the GIS User Community'
  });

  // // RGF93 / Lambert-93 (EPSG:2154) to WGS 84 / Pseudo-Mercator (EPSG:3857) conversion
  // convert(tab: any): void {
  //   const lat = tab[0];
  //   const lon = tab[1];

  //   const x = lon * 20037508.34 / 180;
  //   const y = Math.log(Math.tan((90 + lat) * Math.PI / 360)) / (Math.PI / 180);
  //   const y2 = y * 20037508.34 / 180;

  //   console.log(x, y, y2);
  // }

  //convert geojson to degrees
  convertGeoJson(geojson: any): any {
    let tab: any = [];
    for (let i = 0; i < geojson.length; i++) {
      tab.push(geojson[i][0]);
      tab.push(geojson[i][1]);
    }
    return tab;
  }

  //convert to degrees minutes seconds
  convert(tab: any): any {
    var lat = tab[0];
    var lon = tab[1];

    const latDeg = Math.floor(lat);
    const latMin = Math.floor((lat - latDeg) * 60);
    const latSec = Math.floor(((lat - latDeg) * 60 - latMin) * 60);

    const lonDeg = Math.floor(lon);
    const lonMin = Math.floor((lon - lonDeg) * 60);
    const lonSec = Math.floor(((lon - lonDeg) * 60 - lonMin) * 60);

    lat = lat - (latMin / 60) + (latSec / 3600);
    lon = lon - (lonMin / 60) + (lonSec / 3600);

    return [lat, lon ];
  }




  // Path from paradise to summit - most points omitted from this example for brevity
  // route = polyline([
  //   [46.78465227596462, -121.74141269177198],
  //   [ 46.80047278292477, -121.73470708541572 ],
  //   [ 46.815471360459924, -121.72521826811135 ],
  //   [ 46.8360239546746, -121.7323131300509 ],
  //   [ 46.844306448474526, -121.73327445052564 ],
  //   [ 46.84979408048093, -121.74325201660395 ],
  //   [ 46.853193528950214, -121.74823296256363 ],
  //   [ 46.85322881676257, -121.74843915738165 ],
  //   [ 46.85119913890958, -121.7519719619304 ],
  //   [ 46.85103829018772, -121.7542376741767 ],
  //   [ 46.85101557523012, -121.75431755371392 ],
  //   [ 46.85140013694763, -121.75727385096252 ],
  //   [ 46.8525277543813, -121.75995212048292 ],
  //   [ 46.85290292836726, -121.76049157977104 ],
  //   [46.8528160918504, -121.76042997278273]
  // ], {
  //   color: 'red',
  //   weight: 3,
  //   opacity: 0.65
  //   });

  route: any;
  layersControl: any;
  options: any;
  summit: any;
  paradise: any;

  onMapReady(map: Map) {
    map.fitBounds(this.route?.getBounds(), {
      padding: point(20, 20),
      maxZoom: 13,
      animate: true,
    });

    //geoJSON(this.rootObject.GetItineraireResult.features[0]).addTo(map);
  }

  initializeMap() {
    // Layers control object with our two base layers and the three overlay layers
  this.layersControl = {
    baseLayers: {
      'Street Maps': this.streetMaps,
      'Wikimedia Maps': this.wMaps,
      'Satellite Imagery': this.satellite
    },
    overlays: {
      'Mt. Rainier Summit': this.summit,
      'Mt. Rainier Paradise Start': this.paradise,
      'Mt. Rainier Climb Route': this.route
    }
  };

     // Marker for the top of Mt. Ranier
    if (this.rootObject != undefined) {
      console.log("OOOOOOOOOOOOOOOOOOOOOOOOOOOOOO")
      this.summit = marker(this.rootObject.GetItineraireResult.metadata.query.coordinates[0], {
      icon: icon({
        iconSize: [ 25, 41 ],
        iconAnchor: [ 13, 41 ],
        iconUrl: 'leaflet/marker-icon.png',
        // iconUrl: 'assets/red-marker.svg',
        shadowUrl: 'leaflet/marker-shadow.png',
      })
      });
      console.log(this.summit);

      // Marker for the parking lot at the base of Mt. Ranier trails
      this.paradise = marker(this.rootObject.GetItineraireResult.metadata.query.coordinates[1], {
        icon: icon({
          iconSize: [ 25, 41 ],
          iconAnchor: [ 13, 41 ],
          iconUrl: 'leaflet/marker-icon.png',
          // iconUrl: 'assets/blue-marker.svg',
          iconRetinaUrl: 'leaflet/marker-icon-2x.png',
          shadowUrl: 'leaflet/marker-shadow.png'
        })
      });
      console.log(this.paradise);
       // Set the initial set of displayed layers (we could also use the leafletLayers input binding for this)
      this.options = {
        layers: [ this.streetMaps, this.route, this.summit, this.paradise ],
        zoom: 7,
        center: latLng(this.rootObject.GetItineraireResult.metadata.query.coordinates[0])
      };
    }
}

  constructor(private router: ActivatedRoute) { }

  ngOnInit(): void {
    this.router.queryParams.subscribe((params: any) => {

      this.rootObject = JSON.parse(params.param);
      this.depart = params.depart;
      this.arrivee = params.arrivee;

      console.log(this.rootObject);


      if (this.rootObject != undefined) {
        console.log(this.rootObject.GetItineraireResult);

        //convert to degrees minutes seconds with map function
        // this.rootObject.GetItineraireResult.features[0].geometry.coordinates = this.rootObject.GetItineraireResult.features[0].geometry.coordinates.map(this.convert);
        // console.log(this.rootObject.GetItineraireResult.features[0].geometry.coordinates);

        this.route = polyline(this.rootObject.GetItineraireResult.features[0].geometry.coordinates, {
          color: 'red',
          weight: 3,
          opacity: 0.65
        });
      }

      this.initializeMap();

    });
  }


}

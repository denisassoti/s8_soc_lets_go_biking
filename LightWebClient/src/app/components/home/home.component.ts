import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  GeoApiGouvAddressResponse,
  GeoApiGouvAddressService,
} from "@placeme/ngx-geo-api-gouv-address";

import { environment } from '../../../environments/environment';

import axios from 'axios';
import {Router} from "@angular/router"

import { RootObject} from '../../objects/objects';


@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  routingApiUrl = environment.routingApiUrl;

  adresse_depart: string | undefined;
  adresse_arrivee: string | undefined;

  depart_address_name_list: string[] = [];
  arrivee_address_name_list: string[] = [];
  rootObject: RootObject | undefined;

  formGroup: FormGroup = new FormGroup({});
  constructor(private geoApiGouvAddressService: GeoApiGouvAddressService, private fb: FormBuilder, private router: Router) { }


  ngOnInit(): void {
    this.initForm();
  }

    initForm(){
      this.formGroup = this.fb.group({
        depart: [''],
        arrivee: ['']
      });

      this.formGroup.get('depart')?.valueChanges.subscribe(value => {
        this.retrieveDepartAddresses(value);
        this.adresse_depart = value;
      });

      this.formGroup.get('arrivee')?.valueChanges.subscribe(value => {
        this.retrieveArriveeAddresses(value);
        this.adresse_arrivee = value;
      });
    }

  handleSearch() {
    if (this.adresse_depart == this.adresse_arrivee) {
      alert('Veuillez choisir deux adresses différentes');
    }
    else {
      //fetch GET request itineraire?depart={depart}&arrivee={arrivee} with axios
      axios.get(this.routingApiUrl + '/itineraire?depart=' + this.adresse_depart + '&arrivee=' + this.adresse_arrivee)
        .then((response: any) => {
          //console.log(response.data);
          //verify if response is null
          this.rootObject = JSON.parse(JSON.stringify(response.data));
          //console.log(this.rootObject);
          if (this.rootObject?.GetItineraireResult == null) {
            alert("Aucun itinéraire n'a été trouvé. \n Assurez-vous que les adresses renseignées se trouvent dans des villes disposants de vélos JcDecaux");
          }
          else {
            //redirect to /itinraire with json body
            this.router.navigate(['/itineraire'],
              {
                queryParams: {
                  param: JSON.stringify(response.data),
                  depart: this.adresse_depart,
                  arrivee: this.adresse_arrivee
                }
              });
          }
        });
    }
  }

  retrieveDepartAddresses(e: any) {
    this.geoApiGouvAddressService
      .query({ q: e })
      .subscribe((geoApiGouvAddressResponse: GeoApiGouvAddressResponse) => {
        this.depart_address_name_list = geoApiGouvAddressResponse.features.map(
          (feature) => feature.properties.label
        );
      });
  }

  retrieveArriveeAddresses(e: any) {
    this.geoApiGouvAddressService
      .query({ q: e })
      .subscribe((geoApiGouvAddressResponse: GeoApiGouvAddressResponse) => {
        this.arrivee_address_name_list = geoApiGouvAddressResponse.features.map(
          (feature) => feature.properties.label
        );
      });
  }
}

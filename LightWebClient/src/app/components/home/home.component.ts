import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import {
  GeoApiGouvAddressResponse,
  GeoApiGouvAddressService,
} from "@placeme/ngx-geo-api-gouv-address";

import {environment} from '../../../environments/environment';



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

  formGroup: FormGroup = new FormGroup({});
  constructor(private geoApiGouvAddressService: GeoApiGouvAddressService, private fb: FormBuilder) { }


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
    console.log("D"+this.adresse_depart);
    console.log("A"+this.adresse_arrivee);

    //envoie des donnees au backend avec fetch GET request
    //fetch(this.routingApiUrl + this.adresse_depart + '/' + this.adresse_arrivee)
    //   .then(response => response.json())
    //   .then(data => {
    //     console.log(data);
    //     //redirect to /itiniraire

    //   });

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

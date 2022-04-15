import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { ItiniraireComponent } from './components/itiniraire/itiniraire.component';
import { StationsComponent } from './components/stations/stations.component';

const routes: Routes = [
  {
    path: '',
    component: HomeComponent,
  },
  {
    path: 'itineraire',
    component: ItiniraireComponent,
  },
  {
    path: 'stations',
    component: StationsComponent,
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

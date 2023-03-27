import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { EffectsModule } from '@ngrx/effects';
import { StoreModule } from '@ngrx/store';
import { AutoLoginPartialRoutesGuard } from 'angular-auth-oidc-client';
import { EntryComponent } from './containers/entry/entry.component';
import { ListComponent } from './containers/list/list.component';
import { LocationsComponent } from './locations.component';
import { locationFeature } from './state';
import { LocationEffects } from './state/effects/locations.effects';
import { ReactiveFormsModule } from '@angular/forms';
const routes: Routes = [
  {
    path: '',
    component: LocationsComponent,
    children: [
      {
        path: 'list',
        component: ListComponent,
      },
      {
        path: 'entry',
        component: EntryComponent,
        canActivate: [AutoLoginPartialRoutesGuard],
      },
      {
        path: '**',
        redirectTo: 'list',
      },
    ],
  },
];

@NgModule({
  declarations: [LocationsComponent, ListComponent, EntryComponent],
  imports: [
    CommonModule,
    RouterModule.forChild(routes),
    StoreModule.forFeature(locationFeature),
    EffectsModule.forFeature([LocationEffects]),
    HttpClientModule,
    ReactiveFormsModule
  ],
})
export class LocationsModule {}

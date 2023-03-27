import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Actions, createEffect, ofType } from '@ngrx/effects';
import { map, mergeMap, switchMap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { LocationEntity } from '..';
import {
  locationCommands,
  locationDocuments,
  locationEvents,
} from '../actions/location.actions';

@Injectable()
export class LocationEffects {
  private readonly baseUrl = environment.locationsApi + 'locations';

  saveLocation$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(locationEvents.locationCreated),
      mergeMap(({ payload }) =>
        this.client
          .post<LocationEntity>(this.baseUrl, payload)
          .pipe(map((payload) => locationDocuments.location({ payload })))
      )
    );
  });

  loadLocations$ = createEffect(() => {
    return this.actions$.pipe(
      ofType(locationCommands.load),
      switchMap(() =>
        this.client.get<{ _embedded: LocationEntity[] }>(this.baseUrl).pipe(
          map((r) => r._embedded),
          map((payload) => locationDocuments.locations({ payload }))
        )
      )
    );
  });

  constructor(
    private readonly client: HttpClient,
    private readonly actions$: Actions
  ) {}
}

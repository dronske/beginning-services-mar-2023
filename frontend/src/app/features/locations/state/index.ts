import { createFeature, createReducer, on } from '@ngrx/store';
import { locationDocuments } from './actions/location.actions';
export const featureName = 'locationsFeature';

export type LocationEntity = {
  id: string;
  name: string;
  description: string;
  addedBy: string;
  addedOn: string;
};
interface LocationState {
  locations: LocationEntity[];
  loading: boolean;
}

const initialState: LocationState = {
  locations: [],
  loading: true,
};

export const locationFeature = createFeature({
  name: featureName,
  reducer: createReducer(
    initialState,
    on(locationDocuments.locations, (s, a) => ({
      loading: false,
      locations: a.payload,
    })),
    on(locationDocuments.location, (s,a) => ({...s, locations: [a.payload, ...s.locations]}))
  ),
});

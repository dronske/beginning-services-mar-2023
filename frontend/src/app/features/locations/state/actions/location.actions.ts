import { createActionGroup, emptyProps, props } from '@ngrx/store';
import { LocationEntity } from '..';
import { LocationCreate } from '../../models';


export const locationEvents = createActionGroup({
  source: 'Location Events',
  events: {
    'Location Created': props<{payload: LocationCreate}>()
  }
})

export const locationCommands = createActionGroup({
  source: 'Location Commands',
  events: {
    load: emptyProps(),
  },
});

export const locationDocuments = createActionGroup({
  source: 'Location Documents',
  events: {
    locations: props<{ payload: LocationEntity[] }>(),
    location: props<{ payload: LocationEntity}>()
  },
});

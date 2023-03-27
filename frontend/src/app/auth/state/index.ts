import { createFeature, createReducer, on } from '@ngrx/store';
import { authDocuments } from './auth.actions';

interface AuthState {
  loggedIn: boolean;
  user: string | null;
}

const initialState: AuthState = {
  loggedIn: false,
  user: null,
};

export const authFeature = createFeature({
  name: 'authFeature',
  reducer: createReducer(
    initialState,
    on(authDocuments.user, (_, a) => ({ loggedIn: true, user: a.user })),
    on(authDocuments.nulluser, () => initialState)
  ),
});

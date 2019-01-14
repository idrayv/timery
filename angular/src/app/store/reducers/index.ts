import {
    ActionReducerMap,
    ActionReducer,
    MetaReducer,
    createFeatureSelector
} from '@ngrx/store';
import * as fromSessions from './session';

export interface State {
  session: fromSessions.SessionState;
}

export const reducers: ActionReducerMap<State> = {
  session: fromSessions.reducer
};

export function logger(reducer: ActionReducer<State>): ActionReducer<State> {
  return function (state: State, action: any): State {
    console.log(action.name);
    return reducer(state, action);
  };
}

export const metaReducers: MetaReducer<State>[] = [logger];

export const getSessionState = createFeatureSelector<fromSessions.SessionState>('session');

/* export const getSessionState = createSelector(
    fromSessions.getSessionState,
); */

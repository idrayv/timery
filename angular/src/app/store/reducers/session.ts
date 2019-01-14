import * as sessionActions from '../actions/session';

export interface SessionState {
  isLoggedIn: boolean;
}

export const intitialState: SessionState = {
  isLoggedIn: false
};

export function reducer(state = intitialState, action: sessionActions.Action) {
  switch (action.type) {
    case sessionActions.SET_ISLOGGEDIN: {
        const isLoggedIn: boolean = action.payload;
        return {
          ...state,
          isLoggedIn: isLoggedIn
        };
      }

    default:
      return state;
  }
}

export const getSessionState = (state: SessionState) => state;

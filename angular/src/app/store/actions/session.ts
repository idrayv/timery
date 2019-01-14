import { Action } from '@ngrx/store';

export const SET_ISLOGGEDIN = '[Session] SET_ISLOGGEDIN';

export class SetIsLoggedIn implements Action {
    readonly type = SET_ISLOGGEDIN;

    constructor(public payload: boolean) { }
}

export type Action = SetIsLoggedIn;

import { Component, OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import * as fromRoot from '../../store/reducers';
import { Observable } from 'rxjs';
import { SessionState } from 'src/app/store/reducers/session';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.less']
})
export class NavbarComponent implements OnInit {
  isCollapsed = true;
  sessionState$: Observable<SessionState>;

  constructor(private store: Store<fromRoot.State>) {
    this.sessionState$ = store.select(fromRoot.getSessionState);
    // this.store.dispatch(new sessionAction.SetIsLoggedIn(true));
  }

  ngOnInit() {
  }
}

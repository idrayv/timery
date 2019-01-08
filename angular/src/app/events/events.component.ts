import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import { Observable } from 'rxjs';
import { EventsQuery, CategoryEvent } from './events.models';

import { map } from 'rxjs/operators';
import gql from 'graphql-tag';

@Component({
  selector: 'app-events',
  templateUrl: './events.component.html',
  styleUrls: ['./events.component.less']
})
export class EventsComponent implements OnInit {
  events: Observable<CategoryEvent[]>;

  constructor(private apollo: Apollo) {
  }

  ngOnInit() {
    this.events = this.apollo.watchQuery<EventsQuery>({
      query: gql`
        query TimeryQuery {
          events {
            id,
            category {
              name
            }
          }
        }
      `,
    })
      .valueChanges
      .pipe(
        map(result => result.data.events)
      );
  }
}

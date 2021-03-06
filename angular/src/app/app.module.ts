import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
import { Apollo, ApolloModule } from 'apollo-angular';
import { HttpLink, HttpLinkModule } from 'apollo-angular-link-http';
import { StoreModule } from '@ngrx/store';
import { reducers, metaReducers } from './store/reducers';
import { StoreDevtoolsModule } from '@ngrx/store-devtools';
import { InMemoryCache } from 'apollo-cache-inmemory';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AppBootstrapModule } from './shared/modules/app.bootstrap.module';
import { EventsComponent } from './events/events.component';
import { SettingsComponent } from './settings/settings.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { environment } from '../environments/environment';

@NgModule({
  declarations: [
    AppComponent,
    EventsComponent,
    SettingsComponent,
    NavbarComponent
  ],
  imports: [
    BrowserModule,
    AppBootstrapModule,
    AppRoutingModule,
    HttpClientModule,
    ApolloModule,
    HttpLinkModule,
    StoreModule.forRoot(reducers, { metaReducers }),
    StoreDevtoolsModule.instrument()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule {
  constructor(apollo: Apollo, httpLink: HttpLink) {
    apollo.create({
      // TODO: take uri from environment settings
      link: httpLink.create({ uri: environment.graphqlUrl }),
      cache: new InMemoryCache()
    });
  }
}

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from './shared/modules/material.module';
import { SignupComponent } from './signup/signup.component';
import { LeagueComponent } from './league/league.component';
import { MainHeaderComponent } from './shared/components/main-header/main-header.component';
import { MatchesComponent } from './matches/matches.component';
import { SquadComponent } from './squad/squad.component';
import { MatchComponent } from './matches/match/match.component';
import { JwtInterceptor } from './shared/guards/jwt.interceptor';
import { ErrorInterceptor } from './shared/guards/error.interceptor';
import { registerLocaleData } from '@angular/common';
import localePt from '@angular/common/locales/pt';
import { MarketComponent } from './market/market.component';


registerLocaleData(localePt);
@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    LeagueComponent,
    MainHeaderComponent,
    MatchesComponent,
    SquadComponent,
    MatchComponent,
    MarketComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule,
    HttpClientModule,
  ],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
    { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { MaterialModule } from './shared/modules/material.module';
import { SignupComponent } from './signup/signup.component';
import { LeagueComponent } from './league/league.component';
import { MainHeaderComponent } from './shared/components/main-header/main-header.component';
import { MatchesComponent } from './matches/matches.component';
import { SquadComponent } from './squad/squad.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    SignupComponent,
    LeagueComponent,
    MainHeaderComponent,
    MatchesComponent,
    SquadComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    MaterialModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

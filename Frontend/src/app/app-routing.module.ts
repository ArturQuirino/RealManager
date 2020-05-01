import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { SignupComponent } from './signup/signup.component';
import { LeagueComponent } from './league/league.component';
import { MainHeaderComponent } from './shared/components/main-header/main-header.component';
import { MatchesComponent } from './matches/matches.component';
import { SquadComponent } from './squad/squad.component';
import { MatchComponent } from './matches/match/match.component';
import { AuthGuard } from './shared/guards/auth.guard';


const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  {
    path: 'main',
    component: MainHeaderComponent,
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'league',
        pathMatch: 'full'
      },
      {
        path: 'league',
        component: LeagueComponent
      },
      {
        path: 'matches',
        component: MatchesComponent
      },
      {
        path: 'matches/:id',
            component: MatchComponent
      },
      {
        path: 'squad',
        component: SquadComponent
      }
    ]
  },
  {
    path: '',
    canActivate: [AuthGuard],
    redirectTo: '/main',
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
exports: [RouterModule]
})
export class AppRoutingModule { }

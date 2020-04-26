import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface LeagueTeamApi {
  idLeague: string;
  teamId: string;
  teamName: string;
  matches: number;
  points: number;
  won: number;
  drawn: number;
  lost: number;
  goalsFor: number;
  goalsAgainst: number;
  goalDifference: number;
  position: number;
}



@Injectable({
  providedIn: 'root'
})
export class LeagueApiService {

  constructor(private http: HttpClient) { }

  getLeagueByTeam(teamId: string): Observable<LeagueTeamApi[]> {
    return this.http.get<LeagueTeamApi[]>('https://localhost:44349/api/League/Team/' + teamId);
  }
}

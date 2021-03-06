import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

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

  getLeagueByTeam(): Observable<LeagueTeamApi[]> {
    return this.http.get<LeagueTeamApi[]>(`${environment.apiUrl}/api/League/Team`);
  }
}

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface PlayerApi {
  id: string;
  position: number;
  name: string;
  overall: number;
  pace: number;
  shoot: number;
  pass: number;
  drible: number;
  defence: number;
  physical: number;
  teamId: string;
}

export interface TeamApi {
  id: string;
  name: string;
  players: PlayerApi[];
  starters: PlayerApi[];
}

@Injectable({
  providedIn: 'root'
})
export class TeamApiService {

  constructor(private http: HttpClient) { }

  getTeam(): Observable<TeamApi> {
    return this.http.get<TeamApi>('https://localhost:44349/api/Team/');
  }

  updateTeam(teamApi: TeamApi): Observable<TeamApi> {
    return this.http.put<TeamApi>('https://localhost:44349/api/Team', teamApi);
  }
}

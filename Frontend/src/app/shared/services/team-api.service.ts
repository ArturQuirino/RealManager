import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

export interface PlayerApi {
  id: string;
  position: Position;
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

export enum Position {
  GK, DF, MF, ATA
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
    return this.http.get<TeamApi>(`${environment.apiUrl}/api/Team/`);
  }

  updateTeam(teamApi: TeamApi): Observable<TeamApi> {
    return this.http.put<TeamApi>(`${environment.apiUrl}/api/Team`, teamApi);
  }
}

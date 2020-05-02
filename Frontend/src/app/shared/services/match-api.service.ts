import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { environment } from 'src/environments/environment';

export interface MatchEventApi {
  homeGoals: number;
  awayGoals: number;
  description: MatchEventDescriptionApi[];
}

export interface MatchEventDescriptionApi {
  description: string;
  position: number;
}

export interface MatchApi {
  homeTeamName: string;
  finalResult: string;
  awayTeamName: string;
  id: string;
  events: MatchEventApi[];
  homeGoals: number;
  awayGoals: number;
}

@Injectable({
  providedIn: 'root'
})
export class MatchApiService {

  constructor(private http: HttpClient) { }

  getMatchesByTeamId(): Observable<MatchApi[]> {
    return this.http.get<MatchApi[]>(`${environment.apiUrl}/api/Match/Team`);
  }

  getMatchById(matchId: string): Observable<MatchApi> {
    return this.http.get<MatchApi>(`${environment.apiUrl}/api/Match/` + matchId);
  }
}

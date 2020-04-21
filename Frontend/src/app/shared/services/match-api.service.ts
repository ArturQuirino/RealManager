import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

export interface MatchEventApi {
  homeGoals: number;
  awayGoals: number;
  description: string[];
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

  getMatchesByTeamId(teamId: string): Observable<MatchApi[]> {
    return this.http.get<MatchApi[]>('https://localhost:44349/api/Match/Team/' + teamId);
  }

  getMatchById(matchId: string): Observable<MatchApi> {
    return this.http.get<MatchApi>('https://localhost:44349/api/Match/' + matchId);
  }
}

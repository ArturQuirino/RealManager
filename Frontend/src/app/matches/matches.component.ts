import { Component, OnInit } from '@angular/core';
import { MatchApiService, MatchApi } from '../shared/services/match-api.service';

export interface Match {
  homeTeam: string;
  finalResult: string;
  awayTeam: string;
  homeGoals: number;
  awayGoals: number;
  id: string;
}

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {
  teamId = '8FBEC11C-FED1-42B0-96B8-1000D0D33BB2';
  displayedColumns: string[] = ['matchSum'];
  matchesDataSource: Match[];

  constructor(private matchApiService: MatchApiService) { }

  ngOnInit(): void {
    this.matchApiService.getMatchesByTeamId(this.teamId).subscribe((matchesApi: MatchApi[]) => {
      const matches: Match[] = [];
      matchesApi.forEach((matchApi) => {
        matches.push({
          awayTeam: matchApi.awayTeamName,
          homeTeam: matchApi.homeTeamName,
          finalResult: matchApi.finalResult,
          id: matchApi.id,
          awayGoals: matchApi.awayGoals,
          homeGoals: matchApi.homeGoals
        });
      });

      this.matchesDataSource = matches;

    });
  }

}

import { Component, OnInit } from '@angular/core';
import { LeagueApiService, LeagueTeamApi } from '../shared/services/league-api.service';

@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.scss']
})
export class LeagueComponent implements OnInit {
  division: number;

  displayedColumns: string[] = ['position', 'teamName', 'matches', 'won', 'drawn',
    'lost', 'goalsFor', 'goalsAgainst', 'goalDifference', 'points'];

  leagueDataSource: LeagueTeamApi[];
  constructor(private leagueApiService: LeagueApiService) { }

  ngOnInit(): void {
    this.getDivisionInformation();
  }

  getDivisionInformation(): void {
    this.division = 1;
    this.leagueApiService.getLeagueByTeam().subscribe((leagueTeamsApi: LeagueTeamApi[]) => {

      this.leagueDataSource = leagueTeamsApi
        .sort((a, b) => a.position - b.position);
    });
  }
}

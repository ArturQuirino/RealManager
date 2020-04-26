import { Component, OnInit } from '@angular/core';
import { LeagueApiService, LeagueTeamApi } from '../shared/services/league-api.service';

export interface TeamLeague extends LeagueTeamApi {}


@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.scss']
})
export class LeagueComponent implements OnInit {
  division: number;

  displayedColumns: string[] = ['position', 'teamName', 'matches', 'won', 'drawn',
  'lost', 'goalsFor', 'goalsAgainst', 'goalDifference', 'points'];

  leagueDataSource: TeamLeague[];
  constructor(private leagueApiService: LeagueApiService) { }

  ngOnInit(): void {
    this.getDivisionInformation('44B89D7F-3212-42E2-9CE7-1FEDD666C63F');
  }

  getDivisionInformation(teamId: string): void {
    this.division = 1;
    this.leagueApiService.getLeagueByTeam(teamId).subscribe((leagueTeamsApi: LeagueTeamApi[]) => {

      this.leagueDataSource = leagueTeamsApi.sort((a, b) => a.position - b.position);
    });
  }

}

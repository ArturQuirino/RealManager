import { Component, OnInit } from '@angular/core';

export interface TeamLeague {
  position: number;
  teamName: string;
  matches: number;
  points: number;
  won: number;
  drawn: number;
  lost: number;
  goalsFor: number;
  goalsAgainst: number;
  goalDiference: number;
}

const LEAGUE_TABLE_DATA: TeamLeague[] = [
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 2, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 3, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 4, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 5, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 6, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 7, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 8, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 9, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 10, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
];


@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.scss']
})
export class LeagueComponent implements OnInit {
  division: number;

  displayedColumns: string[] = ['position', 'teamName', 'matches', 'won', 'drawn',
  'lost', 'goalsFor', 'goalsAgainst', 'goalDiference', 'points'];

  leagueDataSource: TeamLeague[];
  constructor() { }

  ngOnInit(): void {
    this.getDivisionInformation(1);
  }

  getDivisionInformation(teamId: number): void {
    this.division = 1;
    this.leagueDataSource = LEAGUE_TABLE_DATA;
  }

}

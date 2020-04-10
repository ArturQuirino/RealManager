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
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
  {position: 1, teamName: 'The best team', matches: 10, points: 30, drawn: 0,
  won: 10, lost: 0, goalsFor: 30, goalsAgainst: 10, goalDiference: 20},
];


@Component({
  selector: 'app-league',
  templateUrl: './league.component.html',
  styleUrls: ['./league.component.scss']
})
export class LeagueComponent implements OnInit {

  displayedColumns: string[] = ['position', 'teamName', 'matches', 'won', 'drawn',
  'lost', 'goalsFor', 'goalsAgainst', 'goalDiference', 'points'];
  leagueDataSource = LEAGUE_TABLE_DATA;
  constructor() { }

  ngOnInit(): void {
  }

}

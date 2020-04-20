import { Component, OnInit } from '@angular/core';

export interface Matches {
  homeTeam: string;
  finalResult: string;
  awayTeam: string;
  id: string;
}

const matches: Matches[] = [
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'},
  {homeTeam: 'IGTI', awayTeam: 'PUC', finalResult: '2 x 0', id: '1'}
];

@Component({
  selector: 'app-matches',
  templateUrl: './matches.component.html',
  styleUrls: ['./matches.component.scss']
})
export class MatchesComponent implements OnInit {

  displayedColumns: string[] = ['homeTeam'];
  matchesDataSource = matches;

  constructor() { }

  ngOnInit(): void {
  }

  navigateMatchDetails(row): void {
    console.log(row);
  }

}

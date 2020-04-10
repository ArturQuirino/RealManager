import { Component, OnInit } from '@angular/core';

export interface Player {
  starter: boolean;
  position: string;
  name: string;
  overall: number;
  pace: number;
  shoot: number;
  pass: number;
  drible: number;
  defence: number;
  physical: number;
}

const TEAM_PLAYERS: Player[] = [
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
  {starter: false, position: 'GK', name: 'Dida', overall: 88, pace: 88,
  shoot: 88, pass: 88, drible: 88, defence: 88, physical: 88},
];

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  starter = false;
  squadDataSource = TEAM_PLAYERS;
  displayedColumns = ['starter', 'position', 'name', 'overall', 'pace', 'shoot', 'pass', 'drible', 'defence', 'physical'];
  constructor() { }

  ngOnInit(): void {
  }

}

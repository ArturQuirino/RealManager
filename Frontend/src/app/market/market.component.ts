import { Component, OnInit } from '@angular/core';
import { PlayerApi, Position } from '../shared/services/team-api.service';

@Component({
  selector: 'app-market',
  templateUrl: './market.component.html',
  styleUrls: ['./market.component.scss']
})
export class MarketComponent implements OnInit {

  availableMoney: number;
  playerInformation: PlayerApi;
  playerValue: number;
  playerExpiration: Date;
  playerPositionDescription: string;

  constructor() { }

  ngOnInit(): void {
    this.availableMoney = 100000;
    this.playerValue = 1000;
    this.playerExpiration = new Date();
    this.playerInformation = {
      defence: 80,
      drible: 80,
      name: 'Artur',
      id: '123456',
      overall: 80,
      pace: 80,
      pass: 80,
      physical: 80,
      position: Position.ATA,
      shoot: 80,
      teamId: undefined
    };

    this.playerPositionDescription = Position[this.playerInformation.position];

  }

}

import { Component, OnInit } from '@angular/core';

export interface MatchEvents {
  description: string;
}

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.scss']
})
export class MatchComponent implements OnInit {

  matchEvents: MatchEvents[] = [
    {description: 'Goal Goal Goal'},
    {description: 'He is going to shoot'},
    {description: 'He pass the defender'},
    {description: 'He is going with ball'},
    {description: 'He is going with ball'},
  ];

  constructor() { }

  ngOnInit(): void {
  }



}

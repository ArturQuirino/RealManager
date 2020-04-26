import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { MatchApiService, MatchApi, MatchEventApi } from 'src/app/shared/services/match-api.service';

export interface MatchEvents {
  descriptions: string[];
}

@Component({
  selector: 'app-match',
  templateUrl: './match.component.html',
  styleUrls: ['./match.component.scss']
})
export class MatchComponent implements OnInit {

  matchId: string;
  matchEvents: MatchEvents[];
  finalResult: string;

  constructor(private route: ActivatedRoute, private matchApiService: MatchApiService) { }

  ngOnInit(): void {
    this.matchId = this.route.snapshot.paramMap.get('id');
    this.matchApiService.getMatchById(this.matchId).subscribe((matchApi: MatchApi) => {
      this.finalResult = matchApi.finalResult;
      const matchEvents: MatchEvents[] = [];
      matchApi.events.forEach((eventApi: MatchEventApi) => {
        eventApi.description.sort((a, b) => a.position - b.position);
        matchEvents.push({
          descriptions: eventApi.description.map(desc => desc.description)
        });
      });
      this.matchEvents = matchEvents;
    });

  }



}

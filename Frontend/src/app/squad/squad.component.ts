import { Component, OnInit } from '@angular/core';
import { TeamApiService, TeamApi, PlayerApi } from '../shared/services/team-api.service';

interface Player {
  starter: boolean;
  position: Position;
  name: string;
  overall: number;
  pace: number;
  shoot: number;
  pass: number;
  drible: number;
  defence: number;
  physical: number;
}

enum Position {
  GK, DF, MF, ATA
}

@Component({
  selector: 'app-squad',
  templateUrl: './squad.component.html',
  styleUrls: ['./squad.component.scss']
})
export class SquadComponent implements OnInit {

  teamId = 'EDB9AA90-8F9F-43DF-87EA-E818911B0DF3';
  starter = false;
  teamName: string;
  squadDataSource: Player[] = [];
  displayedColumns = ['starter', 'position', 'name', 'overall', 'pace', 'shoot', 'pass', 'drible', 'defence', 'physical'];

  constructor(private teamApiService: TeamApiService) { }

  ngOnInit(): void {
    this.teamApiService.getTeam(this.teamId).subscribe((team: TeamApi) => {
      this.teamName = team.name;
      const teamPlayers: Player[] = [];
      team.players.forEach((player: PlayerApi) => {
        teamPlayers.push({
          defence: player.defence,
          drible: player.drible,
          name: player.name,
          overall: player.overall,
          pace: player.pace,
          pass: player.pass,
          physical: player.physical,
          position: player.position,
          shoot: player.shoot,
          starter: team.starters.some(p => p.id === player.id)
        });
      });
      teamPlayers.sort((a, b) => a.position - b.position);
      this.squadDataSource = teamPlayers;
    });
  }

  getPlayerPosition(positionId: number): string {
    return Position[positionId];
  }

}

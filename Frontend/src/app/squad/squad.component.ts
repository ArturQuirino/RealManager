import { Component, OnInit } from '@angular/core';
import { TeamApiService, TeamApi, PlayerApi } from '../shared/services/team-api.service';
import { MatSnackBar } from '@angular/material/snack-bar';

interface Player extends PlayerApi {
  starter: boolean;
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

  teamId = '8FBEC11C-FED1-42B0-96B8-1000D0D33BB2';
  starter = false;
  teamName: string;
  squadDataSource: Player[] = [];
  displayedColumns = ['starter', 'position', 'name', 'overall', 'pace', 'shoot', 'pass', 'drible', 'defence', 'physical'];

  constructor(private teamApiService: TeamApiService, private snackBar: MatSnackBar) { }

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
          starter: team.starters.some(p => p.id === player.id),
          id: player.id,
          teamId: player.teamId,
        });
      });
      teamPlayers.sort((a, b) => a.position - b.position);
      this.squadDataSource = teamPlayers;
    });
  }

  getPlayerPosition(positionId: number): string {
    return Position[positionId];
  }

  saveStarterTeam() {
    if (this.squadDataSource.filter((player) => player.position === Position.GK && player.starter).length !== 1) {
      this.snackBar.open('Chose one Goalkeeper.', undefined, { verticalPosition: 'top', duration: 4000 });
    } else if (this.squadDataSource.filter((player) => player.starter).length !== 11) {
      this.snackBar.open('Chose only 11 players to start the match.', undefined, { verticalPosition: 'top', duration: 4000 });
    } else if (this.squadDataSource.filter((player) => player.position === Position.DF && player.starter).length === 0) {
      this.snackBar.open('Chose at least one defender.', undefined, { verticalPosition: 'top', duration: 4000 });
    } else if (this.squadDataSource.filter((player) => player.position === Position.MF && player.starter).length === 0) {
      this.snackBar.open('Chose at least one midfielder.', undefined, { verticalPosition: 'top', duration: 4000 });
    } else if (this.squadDataSource.filter((player) => player.position === Position.ATA && player.starter).length === 0) {
      this.snackBar.open('Chose at least one attacker.', undefined, { verticalPosition: 'top', duration: 4000 });
    } else {
      const playersApi = this.squadDataSource.map((player: Player): PlayerApi => {
        return {
          defence: player.defence,
          name: player.name,
          pass: player.pass,
          drible: player.drible,
          id: player.id,
          overall: player.overall,
          pace: player.pace,
          physical: player.physical,
          position: player.position,
          shoot: player.shoot,
          teamId: player.teamId,
        };
      });

      const startersApi = this.squadDataSource
        .filter((player) => player.starter)
        .map((player: Player): PlayerApi => {
          return {
            defence: player.defence,
            name: player.name,
            pass: player.pass,
            drible: player.drible,
            id: player.id,
            overall: player.overall,
            pace: player.pace,
            physical: player.physical,
            position: player.position,
            shoot: player.shoot,
            teamId: player.teamId,
          };
        });

      const teamApi: TeamApi = {
        id: this.teamId,
        name: this.teamName,
        players: playersApi,
        starters: startersApi
      };

      this.teamApiService.updateTeam(teamApi).subscribe(() => {
        this.snackBar.open('Squad successfully saved.', undefined, { verticalPosition: 'top', duration: 4000 });
      }, () => {
        this.snackBar.open('An error occurred', undefined, { verticalPosition: 'top', duration: 4000 });
      });
    }
  }

}

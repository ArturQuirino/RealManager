const Team = require('../domain/team');
const Position = require('../domain/position');
const Player = require('../domain/player');

const TeamRepository = require('../data/teamRepository');
const teamRepository = new TeamRepository();

const {v4: uuidv4} = require('uuid');
const constants = require('../util/constantes');


class TeamService {
    async createRandomTeam (teamName) {
        const newTeam = new Team();
        newTeam.name = teamName;
        newTeam._id = uuidv4();

        for(let i = 0; i < 23; i++) {
            let newPlayer;
            if (i === 0) {
                newPlayer = this.createRandomPlayer(Position.GK, newTeam._id);
                newTeam.players.push(newPlayer);
                newTeam.starters.push(newPlayer);
            }
            else if (i >= 1 && i <= 4) {
                newPlayer = this.createRandomPlayer(Position.DF, newTeam._id);
                newTeam.players.push(newPlayer);
                newTeam.starters.push(newPlayer);
            }
            else if (i >= 5 && i <= 7) {
                newPlayer = this.createRandomPlayer(Position.DF, newTeam._id);
                newTeam.players.push(newPlayer);
                newTeam.starters.push(newPlayer);
            }
            else if (i >= 8 && i <= 10) {
                newPlayer = this.createRandomPlayer(Position.DF, newTeam._id);
                newTeam.players.push(newPlayer);
                newTeam.starters.push(newPlayer);
            }
            else {
                newPlayer = this.createRandomPlayer(undefined, newTeam._id);
                newTeam.players.push(newPlayer);
            }
        }

        const createdTeam = await teamRepository.createTeam(newTeam);

        return createdTeam;
    }

    async getTeam(teamId) {
        var team = await teamRepository.getTeamById(teamId);
        return team;
    }

    createRandomPlayer(position, newTeamId) {
        const newPlayer = new Player();
        newPlayer._id = uuidv4();

        const indexFirstName = Math.floor((Math.random() * constants.possibleNames.length));
        const indexSurname = Math.floor((Math.random() * constants.possibleSurnames.length));

        newPlayer.name = constants.possibleNames[indexFirstName] + ' ' + constants.possibleSurnames[indexSurname];

        newPlayer.pace = Math.floor((Math.random() * 100) + 1);
        newPlayer.pass = Math.floor((Math.random() * 100) + 1);
        newPlayer.physical = Math.floor((Math.random() * 100) + 1);
        newPlayer.defence = Math.floor((Math.random() * 100) + 1);
        newPlayer.shoot = Math.floor((Math.random() * 100) + 1);
        newPlayer.drible = Math.floor((Math.random() * 100) + 1);
        newPlayer.overall = [newPlayer.pace, newPlayer.pass, newPlayer.physical, newPlayer.defence, newPlayer.shoot, newPlayer.drible].reduce((a, b) => a + b) / 6;

        newPlayer.position = position ? position : this.selectRandomPosition();

        newPlayer.teamId = newTeamId;

        return newPlayer
    }

    selectRandomPosition() {
        var keys = Object.keys(Position);
        return Position[keys[ keys.length * Math.random() << 0]];
    }
}

module.exports = TeamService;
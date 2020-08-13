const Team = require('../domain/team');
const Position = require('../domain/position');
const Player = require('../domain/player');
const {v4: uuidv4} = require('uuid');
const constants = require('../util/constantes');


class TeamService {
    async createRandomTeam (teamName) {
        const newTeam = new Team();
        newTeam.name = teamName;
        newTeam._id = uuidv4();

        for(let i = 0; i < 23; i++) {
            const newPlayer = this.createRandomPlayer(Position.GK, newTeam._id);
            newTeam.players.push(newPlayer);
        }

        return newTeam;
    }

    createRandomPlayer(position, newTeamId) {
        const newPlayer = new Player();
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

        newPlayer.position = position;

        newPlayer.teamId = newTeamId;

        return newPlayer
    }
}

module.exports = TeamService;
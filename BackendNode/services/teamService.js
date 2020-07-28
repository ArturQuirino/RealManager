const Team = require('../domain/team');


class TeamService {
    async createRandomTeam (teamName) {
        const newTeam = new Team();
        newTeam.name = teamName;
        newTeam._id = 123456;

        return newTeam;
    }
}

module.exports = TeamService;
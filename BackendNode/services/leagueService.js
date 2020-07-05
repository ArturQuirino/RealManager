var League = require('../domain/league');

class LeagueService {
    getLeagueFromTeamId(idTeam) {
        const league = new League();
        league.position = 3;
        league.idTeam = idTeam;
        return league;
    }
}

module.exports = LeagueService;
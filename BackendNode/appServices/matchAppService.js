const TeamService = require('../services/teamService');
const teamService = new TeamService();

const MatchService = require('../services/matchService');
const matchService = new MatchService();

class MatchAppService {
  async runFriendly(homeTeamId, awayTeamId) {
    const homeTeam = await teamService.getTeam(homeTeamId);
    const awayTeam = await teamService.getTeam(awayTeamId);

    return matchService.runFriendly(homeTeam, awayTeam);
  }
}

module.exports = MatchAppService;

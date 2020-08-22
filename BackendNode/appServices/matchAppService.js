const TeamService = require('../services/teamService');
const teamService = new TeamService();

class MatchAppService {
  async runFriendly(homeTeamId, awayTeamId) {
    const homeTeam = await teamService.getTeam(homeTeamId);
    const awayTeam = await teamService.getTeam(awayTeamId);

    return null;
  }
}

module.exports = MatchAppService;

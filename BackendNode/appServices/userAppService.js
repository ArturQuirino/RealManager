const UserService = require('../services/userService');
const userService = new UserService();

const TeamService = require('../services/teamService');
const teamService = new TeamService();

class UserAppService {
  async signUp(email, password, teamName) {
    const createdTeam = await teamService.createRandomTeam(teamName);
    return await userService.signUp(email, password, createdTeam._id);
  }
}

module.exports = UserAppService;

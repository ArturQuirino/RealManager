const jwt = require('jsonwebtoken');



const UserService = require('../services/userService');
const userService = new UserService();

const TeamService = require('../services/teamService');
const teamService = new TeamService();
const bcrypt = require('bcrypt');

class UserAppService {
    async signUp (email, password, teamName) {
        const usersTeam = await teamService.createRandomTeam(teamName);
        return await userService.signUp(email, password, createdTeam._id);
    }
}

module.exports = UserAppService;
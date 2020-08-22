const jwt = require('jsonwebtoken');
const UserRepository = require('../data/userRepository');
const userRepository = new UserRepository();
const TeamRepository = require('../data/teamRepository');
const teamRepository = new TeamRepository();
const TeamService = require('./teamService');
const teamService = new TeamService();
const bcrypt = require('bcrypt');

class UserService {
    async signUp (email, password, teamName) {
        const usersTeam = await teamService.createRandomTeam(teamName);
        const createdTeam = await teamRepository.createTeam(usersTeam);
        const salt = await bcrypt.genSalt();
        const hash = await bcrypt.hash(password, salt);
        const user = {
            email,
            hashPassword: hash,
            teamId: usersTeam._id,
            salt: salt
        }
        const createdUser = await userRepository.createUser(user);

        return createdUser;
    }
}

module.exports = UserService;
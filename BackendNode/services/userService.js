const jwt = require('jsonwebtoken');
const UserRepository = require('../data/userRepository');
const userRepository = new UserRepository();
const bcrypt = require('bcrypt');

class userService {
    async signUp (email, password) {
        const salt = await bcrypt.genSalt();
        const hash = await bcrypt.hash(password, salt);
        const user = {
            email,
            hashPassword: hash,
            teamId: 1
        }
        const createdUser = await userRepository.createUser(user);

        return createdUser;
    }
}

module.exports = userService;
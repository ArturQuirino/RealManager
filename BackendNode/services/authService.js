const jwt = require('jsonwebtoken');
const UserRepository = require('../data/userRepository');
const userRepository = new UserRepository();
const bcrypt = require('bcrypt');

class authService {
    async login (email, password) {
        const user = await userRepository.getUserByEmail(email);
        const hashTypedPassword = await bcrypt.hash(password, user.salt);
        if (user.hashPassword === hashTypedPassword) {
            const token = jwt.sign({email: user.email} , process.env.SECRET , {expiresIn: 300});
            return token;
        } 
        else
        {
            return null;
        }
    }
}

module.exports = authService;
const jwt = require('jsonwebtoken');
const UserRepository = require('../data/userRepository');
const userRepository = new UserRepository();

class authService {
    async login (email, password) {
        if(email == 'artur@gmail.com' && password == '123'){
            const id = 1;
            const token = jwt.sign({id} , process.env.SECRET , {expiresIn: 300});
            const user = await userRepository.getUserByEmail(email);
            console.log(user);
            return token;
        } else {
            return null;
        }

    }
}

module.exports = authService;
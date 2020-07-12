const jwt = require('jsonwebtoken');

class authService {
    login = (email, password) => {
        if(email == 'artur' && password == '123'){
            const id = 1;
            const token = jwt.sign({id} , process.env.SECRET , {expiresIn: 300})
            return token;
        } else {
            return null;
        }

    }
}

module.exports = authService;
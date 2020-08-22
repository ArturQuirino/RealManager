const jwt = require('jsonwebtoken');
const UserService = require('../services/userService');
const userService = new UserService();
const bcrypt = require('bcrypt');

class authAppService {
    async login (email, password) {
        return userService.login(email, password);
    }
}

module.exports = authAppService;
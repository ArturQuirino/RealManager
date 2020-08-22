const UserService = require('../services/userService');
const userService = new UserService();

class authAppService {
  async login(email, password) {
    return userService.login(email, password);
  }
}

module.exports = authAppService;

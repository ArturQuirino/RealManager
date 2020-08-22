const UserRepository = require('../data/userRepository');
const userRepository = new UserRepository();
const bcrypt = require('bcrypt');

class UserService {
  async signUp(email, password, teamId) {
    const salt = await bcrypt.genSalt();
    const hash = await bcrypt.hash(password, salt);
    const user = {
      email,
      hashPassword: hash,
      teamId: teamId,
      salt: salt,
    };
    const createdUser = await userRepository.createUser(user);

    return createdUser;
  }
}

module.exports = UserService;

const UserAppService = require('../appServices/userAppService');
const userAppService = new UserAppService();

module.exports = (app) => {
  app.post('/user', (req, res) => {
    const {email, password, teamName} = req.body;
    userAppService.signUp(email, password, teamName).then((user) => {
      return res.status(200).send(user);
    });
  });
};

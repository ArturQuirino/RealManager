const UserService = require('../services/userService');
const userService = new UserService();

module.exports = app => {
    app.post('/user', (req, res) => {
        const {email, password, teamName} = req.body;
        userService.signUp(email, password, teamName).then((user) => {
            return res.status(200).send(user)
        });
    });
}
const AuthService = require('../services/authService');
const authService = new AuthService();

module.exports = app => {
    app.post('/auth', (req, res) => {
        const {email, password} = req.body;
        const retorno = authService.login(email, password);
        res.send(retorno)
    });
    
}
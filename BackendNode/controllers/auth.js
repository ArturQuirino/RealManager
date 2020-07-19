const AuthService = require('../services/authService');
const authService = new AuthService();

module.exports = app => {
    app.post('/auth', (req, res) => {
        const {email, password} = req.body;
        authService.login(email, password).then((token) => {
            if (token) {
                return res.status(200).send(token)
            }
    
            res.status(401).json({message: 'Login inválido'});
        });

    });
    
}
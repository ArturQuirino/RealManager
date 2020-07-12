const verifyJWT = require('../util/verifyJWT');

module.exports = app => {
    app.get('/leagues', verifyJWT, (req, res) => {
        res.send("you are on route leagues")
    });

    app.post('/leagues', (req, res) => {
        console.log(req.body);
        res.send("you are on route leagues")
    });
    
}
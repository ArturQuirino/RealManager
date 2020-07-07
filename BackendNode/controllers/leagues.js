module.exports = app => {
    app.get('/leagues', (req, res) => {
        res.send("you are on route leagues")
    });

    app.post('/leagues', (req, res) => {
        console.log(req.body);
        res.send("you are on route leagues")
    });
    
}
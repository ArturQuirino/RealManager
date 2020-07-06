module.exports = app => {
    app.get('/leagues', (req, res) => res.send("you are on route leagues"));
}
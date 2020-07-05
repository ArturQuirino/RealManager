var express = require('express');
var router = express.Router();
var LeagueService = require('../services/leagueService');

const leagueService = new LeagueService();

/* GET users listing. */
router.get('/', function(req, res, next) {
    var league = leagueService.getLeagueFromTeamId(req.idTeam);
    res.send(league);
});

module.exports = router;

const MatchAppService = require('../appServices/matchAppService');
const matchAppService = new MatchAppService();

module.exports = (app) => {
  app.post('/match/friendly', (req, res) => {
    const {homeTeamId, awayTeamId} = req.body;
    matchAppService.runFriendly(homeTeamId, awayTeamId).then((match) => {
      return res.status(200).send(match);
    });
  });
};

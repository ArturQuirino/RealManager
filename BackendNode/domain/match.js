
const {v4: uuidv4} = require('uuid');

class Match {
    homeGoals;
    awayGoals;
    events;
    constructor(homeTeamId, awayTeamId, homeTeamName, awayTeamName) {
      this.homeTeamId = homeTeamId;
      this.awayTeamId = awayTeamId;
      this.homeTeamName = homeTeamName;
      this.awayTeamName = awayTeamName;
      this._id = uuidv4();
    }
}

module.exports = Match;

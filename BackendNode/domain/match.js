
const {v4: uuidv4} = require('uuid');

class Match {
  constructor(homeTeamId, awayTeamId, homeTeamName, awayTeamName) {
    this.homeTeamId = homeTeamId;
    this.awayTeamId = awayTeamId;
    this.homeTeamName = homeTeamName;
    this.awayTeamName = awayTeamName;
    this._id = uuidv4();
    this.homeGoals = 0;
    this.awayGoals = 0;
    this.events = [];
  }

  get finalResult() {
    return `${this.homeTeamName} ${this.homeGoals} : ${this.awayGoals} ${this.awayTeamName}`;
  }
}

module.exports = Match;

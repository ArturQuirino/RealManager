const repositoryBase = require('./repositoryBase');

class matchRepository extends repositoryBase {
  async getMatchesByTeamId(id) {
    let matches;
    await this.useDatabase(async (client) => {
      await client.db('realmanagerdev').collection('matches')
          .find({$or: [{homeTeam: id}, {awayTeam: id}]}, (err, result) => {
            matches = result;
          });
    });
    return matches;
  }

  async createMatch(match) {
    await this.useDatabase(async (client) => {
      await client.db('realmanagerdev').collection('matches')
          .insertOne(match).then((document) => {
            match = document;
          });
    });
    return match;
  }
}

module.exports = matchRepository;

const repositoryBase = require('./repositoryBase');

class teamRepository extends repositoryBase {
    async getTeamById (id) {
        let team;
        await this.useDatabase(async (client) => {
            await client.db('realmanagerdev').collection('teams').findOne({_id: id}, (err, result) => {
                team = result;
            });
        });
        return team;
    }

    async createTeam (team) {
        await this.useDatabase(async (client) => {
            await client.db('realmanagerdev').collection('teams').insertOne(team).then((document) => {
                team = document;
            })
        });
        return team;
    }
}

module.exports = teamRepository;
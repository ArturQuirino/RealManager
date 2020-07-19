const {MongoClient} = require('mongodb');
const repositoryBase = require('./repositoryBase');

class userRepository extends repositoryBase {
    async getUserByEmail (email) {
        let user = null;
        await this.useDatabase(async (client) => {
            await client.db('realmanagerdev').collection('users').findOne({}, (err, result) => {
                user = result;
            });
        });
        return user;

    }
}

module.exports = userRepository;
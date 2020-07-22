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

    async createUser (user) {
        let userId = null;
        await this.useDatabase(async (client) => {
            await client.db('realmanagerdev').collection('users').insertOne(user).then((document) => {
                userId = document.insertedId;
            })
        });
        return userId;
    }
}

module.exports = userRepository;
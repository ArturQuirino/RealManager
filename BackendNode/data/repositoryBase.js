const {MongoClient} = require('mongodb');

class repositoryBase {
    async useDatabase(databaseCommand) {
        const uri = process.env.MONGO_CONNECTION_STRING;
 
        const client = new MongoClient(uri);
     
        try {
            // Connect to the MongoDB cluster
            await client.connect();
     
            // Make the appropriate DB calls
            await  databaseCommand(client);
     
        } catch (e) {
            console.error(e);
        } finally {
            await client.close();
        }
    }
}

module.exports = repositoryBase;
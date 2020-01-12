using Repositories.Interfaces;

namespace Repositories
{
    public class MongoRepository : IMongoRepository
    {        
        public string ConnectionString{ get;set; }
        public string DatabaseName { get;set; }
        
    }
}
using RealManager.Repositories.Interfaces;

namespace RealManager.Repositories
{
    public class MongoRepository : IMongoRepository
    {        
        public string ConnectionString{ get;set; }
        public string DatabaseName { get;set; }
        
    }
}
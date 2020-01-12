namespace Repositories.Interfaces
{
    public interface IMongoRepository
    {
        string ConnectionString{ get;set; }
        string DatabaseName { get;set; }
    }
}
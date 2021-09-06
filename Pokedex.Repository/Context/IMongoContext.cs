using MongoDB.Driver;

namespace Pokedex.Repository.Context
{
    public interface IMongoContext
    {
        IMongoDatabase Database { get; }

        IMongoCollection<T> GetCollection<T>(string collectionName);
    }
}

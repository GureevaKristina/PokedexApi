using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Pokedex.Repository.Context
{
    public class MongoContext : IMongoContext
    {
        private string connctionStringName = "Pokemon.MongoDB";
        private IMongoDatabase database;

        public IMongoDatabase Database
        {
            get { return database; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="MongoContext"/> class.
        /// </summary>
        /// <param name="config">The configuration.</param>
        public MongoContext(IConfiguration config)
        {
            var connectionString = config.GetConnectionString(connctionStringName);
            var mongoUrl = MongoUrl.Create(connectionString);
            var client = new MongoClient(mongoUrl);
            database = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string collectionName)
        {
            return database.GetCollection<T>(collectionName);
        }
    }
}

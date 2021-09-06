using MongoDB.Bson.Serialization.Attributes;

namespace Pokedex.Repository.Context
{
    /// <summary>
    /// Abstract MongoDbEntity for all business entitties.
    /// </summary>
    [BsonIgnoreExtraElements(Inherited = true)]
    public abstract class MongoDbEntity
    {
        /// <summary>
        /// Gets or sets the id for this object (the primary recors for an entity).
        /// </summary>
        /// <value>
        /// The id for this object (the primary recors for an entity).
        /// </value>
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}

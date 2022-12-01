using MongoDB.Bson.Serialization.Attributes;

namespace Wifi.PlaylistEditor.DbRepositories.MongoDbEntities
{
    public class PlaylistItemEntity
    {
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("path")]
        public string Path { get; set; }
    }
}
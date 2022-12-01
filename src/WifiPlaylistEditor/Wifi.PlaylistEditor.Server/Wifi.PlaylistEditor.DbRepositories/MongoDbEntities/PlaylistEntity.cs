using MongoDB.Bson.Serialization.Attributes;

namespace Wifi.PlaylistEditor.DbRepositories.MongoDbEntities
{
    public class PlaylistEntity
    {
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("createDate")]
        public string CreatedAt{ get; set; }

        [BsonElement("items")]
        public List<PlaylistItemEntity> Items { get; set; }
    }
}

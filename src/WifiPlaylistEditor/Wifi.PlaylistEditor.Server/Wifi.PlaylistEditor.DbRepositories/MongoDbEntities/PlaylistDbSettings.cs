namespace Wifi.PlaylistEditor.DbRepositories.MongoDbEntities
{
    public class PlaylistDbSettings
    {
        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; } 

        public string PlaylistCollectionName { get; set; }

        public string ItemsCollectionName { get; set; }
    }
}

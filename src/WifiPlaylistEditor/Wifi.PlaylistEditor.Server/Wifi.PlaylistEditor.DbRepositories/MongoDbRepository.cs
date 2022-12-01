using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;

namespace Wifi.PlaylistEditor.DbRepositories
{
    public class MongoDbRepository : IDatabaseRepository<PlaylistEntity>
    {
        private IMongoCollection<PlaylistEntity> _playlistCollection;

        public MongoDbRepository(IOptions<PlaylistDbSettings> playlistDbSetting)
        {
            if(playlistDbSetting == null)
            {
                return;
            }

            var mongoClient = new MongoClient(playlistDbSetting.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(playlistDbSetting.Value.DatabaseName);

            _playlistCollection = mongoDatabase.GetCollection<PlaylistEntity>(playlistDbSetting.Value.CollectionName);
        }

        public async Task CreateAsync(PlaylistEntity newPlaylist)
        {
            if(newPlaylist == null)
            {
                return;
            }

            await _playlistCollection.InsertOneAsync(newPlaylist);
        }

        public async Task<List<PlaylistEntity>> GetAsync()
        {
            return await _playlistCollection.Find(x => true).ToListAsync();
        }

        public async Task<PlaylistEntity> GetAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return await _playlistCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task RemoveAsync(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return;
            }

            await _playlistCollection.DeleteOneAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(string id, PlaylistEntity updatedPlaylist)
        {
            if (string.IsNullOrEmpty(id) || updatedPlaylist == null)
            {
                return;
            }

            await _playlistCollection.ReplaceOneAsync(x => x.Id == id, updatedPlaylist);
        }
    }
}
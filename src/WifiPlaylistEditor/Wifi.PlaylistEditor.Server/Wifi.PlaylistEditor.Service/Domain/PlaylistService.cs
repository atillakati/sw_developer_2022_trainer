using Wifi.PlaylistEditor.DbRepositories;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Domain
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IDatabaseRepository<PlaylistEntity> _databaseRepositoy;

        public PlaylistService(IPlaylistFactory playlistFactory,
                               IPlaylistItemFactory playlistItemFactory,
                               IDatabaseRepository<PlaylistEntity> databaseRepositoy)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _databaseRepositoy = databaseRepositoy;
        }

        public async Task<IEnumerable<IPlaylist>> GetAllPlaylists()
        {
            var playlistEntities = await _databaseRepositoy.GetAsync();
            if(playlistEntities == null || playlistEntities.Count == 0)
            {
                return new List<IPlaylist>();
            }

            return playlistEntities.ToDomain(_playlistFactory, _playlistItemFactory);
        }

        public async Task<IPlaylist> GetPlaylistById(string playlistId)
        {
            var playlistEntity = await _databaseRepositoy.GetAsync(playlistId);
            if (playlistEntity == null)
            {
                return null;
            }

            var playlist = playlistEntity.ToDomain(_playlistFactory, _playlistItemFactory);
            foreach (var item in playlistEntity.Items)
            {
                var playlistItem = _playlistItemFactory.Create(Guid.Parse(item.Id), item.Path);
                if(playlistItem != null)
                {
                    playlist.Add(playlistItem);
                }
            }

            return playlist;
        }    
    }
}

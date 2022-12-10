using Wifi.PlaylistEditor.DbRepositories;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Domain
{
    public class PlaylistService : IPlaylistService
    {
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private readonly IDatabaseRepository<PlaylistEntity, PlaylistItemEntity> _databaseRepositoy;

        public PlaylistService(IPlaylistFactory playlistFactory,
                               IPlaylistItemFactory playlistItemFactory,
                               IDatabaseRepository<PlaylistEntity, PlaylistItemEntity> databaseRepositoy)
        {
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _databaseRepositoy = databaseRepositoy;
        }

        public async Task AddNewPlaylist(IPlaylist newPlaylist)
        {
            if(newPlaylist == null)
            {
                return;
            }

            var entity = new PlaylistEntity
            {
                Id = newPlaylist.Id.ToString(),
                Author = newPlaylist.Author,
                Title = newPlaylist.Name,
                CreatedAt = newPlaylist.CreateAt.ToString("yyyyMMdd"),
                Items = newPlaylist.ItemList.Select(x => x.ToEntity())
            };

            await _databaseRepositoy.CreateAsync(entity);
        }

        public async Task AddItem(IPlaylistItem newItem)
        {
            var entity = newItem.ToEntity();
            await _databaseRepositoy.CreateItemAsync(entity);
        }

        public async Task<IEnumerable<IPlaylistItem>> GetAllItems()
        {            
            var items = await _databaseRepositoy.GetItemsAsync();
         
            if(items == null)
            {
                return Enumerable.Empty<IPlaylistItem>();
            }
            
            var domainItems = items.Select(x => _playlistItemFactory.Create(Guid.Parse(x.Id), x.Path))
                                   .ToList();

            return domainItems;
        }

        public async Task<IEnumerable<IPlaylist>> GetAllPlaylists()
        {
            var playlistEntities = await _databaseRepositoy.GetAsync();
            if (playlistEntities == null || playlistEntities.Count == 0)
            {
                return new List<IPlaylist>();
            }

            return playlistEntities.ToDomain(_playlistFactory, _playlistItemFactory);
        }

        public async Task<IPlaylistItem> GetItemById(string id)
        {
            var items = await _databaseRepositoy.GetItemsAsync();
            if (items == null)
            {
                return null;
            }

            var item = items.FirstOrDefault(x => x.Id == id);
            if(item == null)
            {
                return null;
            }

            var playlistItem = _playlistItemFactory.Create(item.Path);

            return playlistItem;
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
                if (playlistItem != null)
                {
                    playlist.Add(playlistItem);
                }
            }

            return playlist;
        }
    }
}

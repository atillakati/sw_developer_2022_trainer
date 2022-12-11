using System.Globalization;
using System.Runtime.CompilerServices;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Mappings
{
    public static class MongoDbMappings
    {
        public static PlaylistItemEntity ToEntity(this IPlaylistItem playlistItem)
        {
            return new PlaylistItemEntity
            {
                Id = playlistItem.Id.ToString(),
                Path = playlistItem.Path,                
            };
        }

        

        public static IEnumerable<IPlaylist> ToDomain(this IEnumerable<PlaylistEntity> entities,
                                                           IPlaylistFactory playlistFactory,
                                                           IPlaylistItemFactory playlistItemFactory)
        {
            return entities.Select(x => x.ToDomain(playlistFactory, playlistItemFactory));
        }

        public static IPlaylist ToDomain(this PlaylistEntity entity,
                                              IPlaylistFactory playlistFactory,
                                              IPlaylistItemFactory playlistItemFactory)
        {
            return playlistFactory.Create(Guid.Parse(entity.Id), entity.Title, entity.Author,
                DateTime.ParseExact(entity.CreatedAt, "yyyyMMdd", CultureInfo.InvariantCulture));
        }

        public static PlaylistEntity ToEntity(this IPlaylist playlist)
        {
            return new PlaylistEntity
            {
                Id = playlist.Id.ToString(),
                Author = playlist.Author,
                Title = playlist.Name,
                CreatedAt = playlist.CreateAt.ToString("yyyyMMdd"),
                Items = playlist.ItemList.Select(x => x.ToEntity())
            };
        }
    }
}

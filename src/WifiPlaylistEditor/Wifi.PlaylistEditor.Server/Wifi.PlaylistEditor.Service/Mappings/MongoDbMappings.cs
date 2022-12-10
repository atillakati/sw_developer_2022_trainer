using System.Globalization;
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
    }
}

using System.Globalization;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Mappings
{
    public static class MongoDbMappings
    {
        public static IEnumerable<IPlaylist> ToDomain(this IEnumerable<PlaylistEntity> entities,
                                                           IPlaylistFactory playlistFactory,
                                                           IPlaylistItemFactory playlistItemFactory)
        {
            return entities.Select(x => playlistFactory.Create(Guid.Parse(x.Id), 
                                                               x.Title, x.Author, 
                                                               DateTime.ParseExact(x.CreatedAt, "yyyyMMdd", CultureInfo.InvariantCulture)));
        }
    }
}

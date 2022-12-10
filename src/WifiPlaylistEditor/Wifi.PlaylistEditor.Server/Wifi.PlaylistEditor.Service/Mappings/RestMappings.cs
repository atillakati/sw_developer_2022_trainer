using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Mappings
{
    public static class RestMappings
    {        
        public static ItemList ToEntity(this IEnumerable<IPlaylistItem> domainItems)
        {
            var entityList = new ItemList();
            entityList.Items = domainItems.Select(x => new PlaylistItem
            {
                Artist = x.Artist,
                Duration = (long)x.Duration.TotalSeconds,
                Extension = x.Extension,
                Path = x.Path,
                Thumbnail = x.Thumbnail,
                Title = x.Title,
                Id = x.Id.ToString()
            }).ToList();

            return entityList;
        }

        public static IPlaylist ToDomain(this PlaylistPost entity, IPlaylistFactory playlistFactory)
        {
            var playlist = playlistFactory.Create(entity.Name, entity.Autor, DateTime.Now);

            return playlist;
        }

        public static PlaylistList ToEntity(this IEnumerable<IPlaylist> domainObjects)
        {
            var playlistInfo = domainObjects.Select(x => new PlaylistInfo { Id = x.Id.ToString(), Name = x.Name });

            return new PlaylistList { Playlists = playlistInfo.ToList() };
        }

        public static Models.Playlist ToEntity(this IPlaylist domainObject)
        {
            return new Models.Playlist
            {
                Id = domainObject.Id.ToString(),
                Name = domainObject.Name,
                Autor = domainObject.Author,
                Duration = (long)domainObject.Duration.TotalSeconds,
                DateOfCreation = domainObject.CreateAt,
                Items = domainObject.ItemList.Select(x => new Models.PlaylistItem 
                {
                    Id = x.Id.ToString(), 
                    Artist = x.Artist, 
                    Title = x.Title, 
                    Path = x.Path,
                    Extension = x.Extension,
                    Thumbnail= x.Thumbnail,
                    Duration = (long)x.Duration.TotalSeconds,
                }).ToList()
            };            
        }
    }
}

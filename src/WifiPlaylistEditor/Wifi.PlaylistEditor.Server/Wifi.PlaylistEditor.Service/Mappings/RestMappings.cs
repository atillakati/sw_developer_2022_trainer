using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Mappings
{
    public static class RestMappings
    {
        public static PlaylistList ToEntity(this IEnumerable<IPlaylist> domainObjects)
        {
            var playlistInfo = domainObjects.Select(x => new PlaylistInfo { Id = x.Id.ToString(), Name = x.Name });

            return new PlaylistList { Playlists = playlistInfo.ToList() };
        }
    }
}

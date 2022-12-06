using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Domain
{
    public interface IPlaylistService
    {
        Task<IEnumerable<IPlaylist>> GetAllPlaylists();
    }
}
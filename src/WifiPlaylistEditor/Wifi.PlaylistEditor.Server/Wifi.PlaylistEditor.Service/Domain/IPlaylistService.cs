using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Service.Domain
{
    public interface IPlaylistService
    {
        void AddNewPlaylist(IPlaylist newPlaylist);

        Task<IEnumerable<IPlaylist>> GetAllPlaylists();
        
        Task<IPlaylistItem> GetItemById(string id);

        Task<IPlaylist> GetPlaylistById(string playlistId);
    }
}
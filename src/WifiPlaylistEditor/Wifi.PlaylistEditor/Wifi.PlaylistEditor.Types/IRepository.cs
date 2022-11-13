
namespace Wifi.PlaylistEditor.Types
{
    public interface IRepository
    {
        /// <summary>
        /// Die Dateiextension die verwendet werden soll für das jeweilige Playlist Format.
        /// zb: .m3u
        /// </summary>
        string Extension { get; }

        string Description { get;}

        IPlaylist Load(string playlistFilePath);

        void Save(IPlaylist playlist, string playlistFilePath);
    }
}

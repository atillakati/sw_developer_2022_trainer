
namespace Wifi.PlaylistEditor.Types
{
    public interface IRepository : IFileDescription
    {        
        IPlaylist Load(string playlistFilePath);

        void Save(IPlaylist playlist, string playlistFilePath);
    }
}

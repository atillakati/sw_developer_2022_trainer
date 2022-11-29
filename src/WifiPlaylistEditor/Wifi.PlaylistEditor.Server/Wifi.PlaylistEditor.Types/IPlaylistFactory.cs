using System;

namespace Wifi.PlaylistEditor.Types
{
    public interface IPlaylistFactory
    {
        //IEnumerable<IFileDescription> AvailableTypes { get; }

        IPlaylist Create(string title, string author, DateTime createDate);
    }
}

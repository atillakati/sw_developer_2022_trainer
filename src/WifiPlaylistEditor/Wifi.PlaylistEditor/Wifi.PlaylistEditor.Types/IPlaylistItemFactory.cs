using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Types
{
    public interface IPlaylistItemFactory
    {
        IEnumerable<IFileDescription> AvailableTypes { get; }

        IPlaylistItem Create(string itemPath);        
    }
}

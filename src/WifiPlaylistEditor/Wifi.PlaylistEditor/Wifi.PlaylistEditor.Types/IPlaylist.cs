using System;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Types
{
    public interface IPlaylist
    {
        /// <summary>
        /// This should be described!
        /// </summary>
        string Name { get; set; }
        string Author { get; set; }
        DateTime CreateAt { get; }
        TimeSpan Duration { get; }
        bool AllowDuplicates { get; set; }
        IEnumerable<IPlaylistItem> ItemList { get; }

        void Add(IPlaylistItem itemToAdd);
        void Remove(IPlaylistItem itemToRemove);
        void Clear();
    }
}

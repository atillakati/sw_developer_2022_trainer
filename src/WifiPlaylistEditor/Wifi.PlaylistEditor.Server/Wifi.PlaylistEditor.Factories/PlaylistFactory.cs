using System;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Factories
{
    public class PlaylistFactory : IPlaylistFactory
    {
        //public IEnumerable<IFileDescription> AvailableTypes => throw new NotImplementedException();

        public IPlaylist Create(string title, string author, DateTime createDate)
        {
            return new Playlist(title, author, createDate);
        }

        public IPlaylist Create(Guid id, string title, string author, DateTime createDate)
        {
            return new Playlist(id, title, author, createDate);
        }
    }
}

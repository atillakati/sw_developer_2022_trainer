using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO;

using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class m3uRepository : IRepository
    {
        public m3uRepository() { }

        public string Extension => ".m3u";

        public string Description => "M3U Playlist";

        public IPlaylist Load(string playlistFilePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string playlistFilePath)
        {
            if (playlist == null || string.IsNullOrEmpty(playlistFilePath))
            {
                return;
            }

            var m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            foreach (var item in playlist.ItemList)
            {
                m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {
                    AlbumArtist = item.Artist,
                    Duration = item.Duration,
                    Path = item.Path,
                    Title = item.Titel
                });
            }

            var content = new M3uContent();
            string text = content.ToText(m3uPlaylist);

            using (var sw = new StreamWriter(playlistFilePath, false))
            {
                sw.WriteLine(text);
            }
        }
    }
}
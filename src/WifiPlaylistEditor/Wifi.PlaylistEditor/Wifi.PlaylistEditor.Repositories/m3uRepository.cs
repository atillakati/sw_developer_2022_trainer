
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO;

using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IRepository
    {
        private readonly string _extension;

        public M3uRepository()
        {
            _extension= ".m3u";
        }

        public string Extension => _extension;

        public string Description => "M3U Playlist file";

        public IPlaylist Load(string playlistFilePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string playlistFilePath)
        {
            if(playlist == null || string.IsNullOrEmpty(playlistFilePath))  
            {
                return;
            }

            M3uPlaylist m3uPlaylist = new M3uPlaylist();
            m3uPlaylist.IsExtended = true;

            foreach (var item in playlist.ItemList)
            {
                m3uPlaylist.PlaylistEntries.Add(new M3uPlaylistEntry()
                {                                        
                    Duration = item.Duration,
                    Path = item.Path,
                    Title = item.Title
                });
            }

            M3uContent content = new M3uContent();
            string text = content.ToText(m3uPlaylist);

            using(var sw = new StreamWriter(playlistFilePath, false)) 
            {
                sw.WriteLine(text);
            }
        }
    }
}
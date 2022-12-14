using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO.Abstractions;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IRepository
    {
        private readonly string _extension;
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistFactory, playlistItemFactory)
        {            
        }

        public M3uRepository(IFileSystem fileSystem, IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _extension = ".m3u";
        }

        public string Extension => _extension;

        public string Description => "M3U Playlist file";

        public IPlaylist Load(string playlistFilePath)
        {
            if (string.IsNullOrEmpty(playlistFilePath) || !_fileSystem.File.Exists(playlistFilePath))
            {
                return null;
            }

            var stream = _fileSystem.File.OpenRead(playlistFilePath);

            var parser = PlaylistParserFactory.GetPlaylistParser(_extension);
            IBasePlaylist playlist = parser.GetFromStream(stream);

            var myPlaylist = _playlistFactory.Create("M3UPlaylist","WifiPlaylistEditor", DateTime.Now);

            //add items
            var paths = playlist.GetTracksPaths();
            foreach (var itemPath in paths)
            {
                var item = _playlistItemFactory.Create(itemPath);
                if (item != null)
                {
                    myPlaylist.Add(item);
                }
            }

            return myPlaylist;
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
            
            _fileSystem.File.WriteAllText(playlistFilePath, text);            
        }
    }
}
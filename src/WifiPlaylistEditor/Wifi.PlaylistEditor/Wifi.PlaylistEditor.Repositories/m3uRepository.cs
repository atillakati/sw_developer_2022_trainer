using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System.IO.Abstractions;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class M3uRepository : IRepository
    {
        private readonly string _extension;
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public M3uRepository(IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistItemFactory)
        {            
        }

        public M3uRepository(IFileSystem fileSystem, IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
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

            var myPlaylist = new Playlist("M3UPlaylist","WifiPlaylistEditor");

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
using PlaylistsNET.Content;
using PlaylistsNET.Models;
using System;
using System.IO.Abstractions;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class PlsRepository : IRepository
    {
        private readonly string _extension;
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public PlsRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistFactory, playlistItemFactory)
        {            
        }

        public PlsRepository(IFileSystem fileSystem, IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
            _extension = ".pls";
        }

        public string Extension => _extension;

        public string Description => "PLS Playlist file";

        public IPlaylist Load(string playlistFilePath)
        {
            if (string.IsNullOrEmpty(playlistFilePath) || !_fileSystem.File.Exists(playlistFilePath))
            {
                return null;
            }

            var stream = _fileSystem.File.OpenRead(playlistFilePath);

            var parser = PlaylistParserFactory.GetPlaylistParser(_extension);
            IBasePlaylist playlist = parser.GetFromStream(stream);

            var myPlaylist = _playlistFactory.Create("PLSPlaylist", "WifiPlaylistEditor", DateTime.Now);

            //add items
            var paths = playlist.GetTracksPaths();
            foreach (var itemPath in paths)
            {
                var item = _playlistItemFactory.Create(itemPath);
                myPlaylist.Add(item);
            }

            return myPlaylist;
        }

        public void Save(IPlaylist playlist, string playlistFilePath)
        {
            if (playlist == null || string.IsNullOrEmpty(playlistFilePath))
            {
                return;
            }

            var plsPlaylist = new PlsPlaylist();

            foreach (var item in playlist.ItemList)
            {
                plsPlaylist.PlaylistEntries.Add(new PlsPlaylistEntry()
                {
                    Length = item.Duration,
                    Path = item.Path,
                    Title = item.Title
                });
            }

            var content = new PlsContent();
            string text = content.ToText(plsPlaylist);

            _fileSystem.File.WriteAllText(playlistFilePath, text);
        }
    }
}
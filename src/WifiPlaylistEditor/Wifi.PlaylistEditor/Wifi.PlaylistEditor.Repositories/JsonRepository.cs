using Newtonsoft.Json;
using System;
using System.IO;
using System.IO.Abstractions;
using Wifi.PlaylistEditor.Repositories.Json;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories
{
    public class JsonRepository : IRepository
    {
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public JsonRepository(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistFactory, playlistItemFactory) { }

        public JsonRepository(IFileSystem fileSystem, IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _fileSystem = fileSystem;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
        }

        public string Extension => ".json";

        public string Description => "Wifi playlist format";

        public IPlaylist Load(string playlistFilePath)
        {
            if (string.IsNullOrEmpty(playlistFilePath) || !_fileSystem.File.Exists(playlistFilePath))
            {
                return null;
            }

            //open file and read content
            string json = string.Empty;
            var jsonStream = _fileSystem.File.OpenRead(playlistFilePath);
            using(var sr = new StreamReader(jsonStream))
            {
                json = sr.ReadToEnd();
            }

            //convert json text to entity object (deserialize)
            var entity = JsonConvert.DeserializeObject<PlaylistEntity>(json);

            //convert entity object to domain object
            var playlist = entity.ToDomain(_playlistFactory, _playlistItemFactory);

            return playlist;
        }

        public void Save(IPlaylist playlist, string playlistFilePath)
        {
            if (playlist == null || string.IsNullOrEmpty(playlistFilePath))
            {
                return;
            }

            //convert domain object into json spezific enities
            var entity = playlist.ToEntity();

            //convert entity object to json text (serialize)
            string json = JsonConvert.SerializeObject(entity);

            //create file
            try
            {
                _fileSystem.File.WriteAllText(playlistFilePath, json);
            }
            catch (Exception ex)
            {
                //create log entries
            }
        }
    }
}

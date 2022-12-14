using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using Wifi.PlaylistEditor.Repositories;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Factories
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly IFileSystem _fileSystem;
        private readonly IPlaylistFactory _playlistFactory;
        private readonly IPlaylistItemFactory _playlistItemFactory;
        private List<IRepository> _availableTypes;

        public RepositoryFactory(IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
            : this(new FileSystem(), playlistFactory, playlistItemFactory)
        {
            
        }

        public RepositoryFactory(IFileSystem fileSystem, IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistItemFactory = playlistItemFactory;
            _fileSystem = fileSystem;
            _playlistFactory = playlistFactory;

            _availableTypes = new List<IRepository>() 
            {
                new M3uRepository(_fileSystem, _playlistFactory, _playlistItemFactory),
                new PlsRepository(_fileSystem, _playlistFactory, _playlistItemFactory),
                new JsonRepository(_fileSystem, _playlistFactory, _playlistItemFactory),
            };  
        }

        public IEnumerable<IFileDescription> AvailableTypes => _availableTypes;

        public IRepository Create(string itemPath)
        {
            if(string.IsNullOrEmpty(itemPath) || !_fileSystem.File.Exists(itemPath))
            {
                return null;
            }

            var extension = Path.GetExtension(itemPath);
            var repository = _availableTypes.FirstOrDefault(x => x.Extension == extension);

            return repository;
        }
    }
}

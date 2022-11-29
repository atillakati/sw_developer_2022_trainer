using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Items;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Factories
{
    public class PlaylistItemFactory : IPlaylistItemFactory
    {
        private readonly IFileSystem _fileSystem;

        public PlaylistItemFactory()
            :this(new FileSystem())
        {

        }

        public PlaylistItemFactory(IFileSystem fileSystem)
        {
            _fileSystem = fileSystem;
        }

        public IEnumerable<IFileDescription> AvailableTypes => new IFileDescription[] 
        {
            new Mp3Item(),
            new ImageItem(),
        };

        public IPlaylistItem Create(string itemPath)
        {
            if (string.IsNullOrEmpty(itemPath) || !_fileSystem.File.Exists(itemPath))
            {
                return null;
            }

            var extension = Path.GetExtension(itemPath);
            switch (extension)
            {
                case ".mp3":
                    return new Mp3Item(itemPath);

                case ".jpg":
                    return new ImageItem(itemPath);

                default:
                    return null;                        
            }
        }
    }
}

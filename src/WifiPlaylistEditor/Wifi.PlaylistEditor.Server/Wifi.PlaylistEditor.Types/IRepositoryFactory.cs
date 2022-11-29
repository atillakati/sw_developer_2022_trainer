using System.Collections.Generic;

namespace Wifi.PlaylistEditor.Types
{
    public interface IRepositoryFactory
    {
        IEnumerable<IFileDescription> AvailableTypes { get; }

        IRepository Create(string itemPath);
    }
}

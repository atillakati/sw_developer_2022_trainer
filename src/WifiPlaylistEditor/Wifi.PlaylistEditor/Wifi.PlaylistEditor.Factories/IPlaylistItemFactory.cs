using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Factories
{
    public interface IPlaylistItemFactory
    {
        IPlaylistItem Create(string itemPath);
    }
}

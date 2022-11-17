using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Json
{
    public class JsonRepository : IRepository
    {
        public string Extension => ".json";

        public string Description => "Wifi playlist format";

        public IPlaylist Load(string playlistFilePath)
        {
            throw new NotImplementedException();
        }

        public void Save(IPlaylist playlist, string playlistFilePath)
        {
            var entity = playlist.ToEntity();

            string json = JsonConvert.SerializeObject(entity);

        }
    }
}

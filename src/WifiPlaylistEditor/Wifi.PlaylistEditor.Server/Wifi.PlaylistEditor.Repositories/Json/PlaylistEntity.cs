using System;
using System.Collections.Generic;
using System.Linq;
namespace Wifi.PlaylistEditor.Repositories.Json
{
    internal class PlaylistEntity
    {
        public string title { get; set; }
        public string author { get; set; }
        public string createdAt { get; set; }
        public IEnumerable<ItemEntity> items { get; set; }
    }
}

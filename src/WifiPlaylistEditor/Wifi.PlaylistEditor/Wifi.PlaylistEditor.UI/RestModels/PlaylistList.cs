using System.Collections.Generic;

namespace Wifi.PlaylistEditor.UI.RestModels
{
    /// <summary>
    /// 
    /// </summary>    
    public class PlaylistList
    {
        /// <summary>
        /// Gets or Sets Playlists
        /// </summary>        
        public IEnumerable<PlaylistInfo> Playlists { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace Wifi.PlaylistEditor.UI.RestModels
{
    /// <summary>
    /// 
    /// </summary>   
    public class Playlist
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>                
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Name
        /// </summary>        
        public string Name { get; set; }

        /// <summary>
        /// Gets or Sets Duration
        /// </summary>        
        public long Duration { get; set; }

        /// <summary>
        /// Gets or Sets Autor
        /// </summary>        
        public string Author { get; set; }

        /// <summary>
        /// Gets or Sets DateOfCreation
        /// </summary>       
        public DateTime DateOfCreation { get; set; }

        /// <summary>
        /// Gets or Sets Items
        /// </summary>        
        public List<PlaylistItem> Items { get; set; }
    }
}

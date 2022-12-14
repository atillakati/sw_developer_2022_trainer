namespace Wifi.PlaylistEditor.UI.RestModels
{
    public class PlaylistItem
    {
        /// <summary>
        /// Gets or Sets Id
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Gets or Sets Title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or Sets Artist
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// Gets or Sets Duration
        /// </summary>
        public long? Duration { get; set; }

        /// <summary>
        /// Gets or Sets Thumbnail
        /// </summary>
        public byte[] Thumbnail { get; set; }

        /// <summary>
        /// Gets or Sets Extension
        /// </summary>        
        public string Extension { get; set; }

        /// <summary>
        /// Gets or Sets Path
        /// </summary>        
        public string Path { get; set; }
    }
}

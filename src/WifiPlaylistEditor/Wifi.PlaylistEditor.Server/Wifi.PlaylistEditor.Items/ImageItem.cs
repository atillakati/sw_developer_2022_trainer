
using File = TagLib.File;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items
{
    public class ImageItem : IPlaylistItem
    {
        private string _path;
        private Guid _id;

        /// <summary>
        /// Creates a dummy ImageItem instance with no tag information
        /// </summary>
        public ImageItem() : this(string.Empty) { }

        public ImageItem(string filePath)
        {
            _id= Guid.NewGuid();
            _path = filePath;

            Title= string.Empty;
            Artist= string.Empty;
            Thumbnail = new byte[0];

            if (!string.IsNullOrWhiteSpace(filePath))
            {
                ReadImageTags();
            }
        }

        public string Title { get; set; }

        public string Path
        {
            get => _path;
            set => _path = value;
        }
        public string Artist { get; set; }
        public byte[] Thumbnail { get; set; }
        public TimeSpan Duration { get; set; }

        public string Extension => ".jpg";

        public string Description => "JPG Image File";

        public Guid Id {  get => _id; set => _id = value; }

        private void ReadImageTags()
        {
            var tfile = File.Create(_path);

            Title = tfile.Tag.Title;
            if (string.IsNullOrWhiteSpace(Title)) Title = System.IO.Path.GetFileName(_path);

            Artist = tfile.Tag.FirstPerformer;
            if (string.IsNullOrWhiteSpace(Artist))
            {
                Artist = "Unknown";
            }

            Duration = TimeSpan.FromSeconds(10);            
            Thumbnail = tfile.Tag.Pictures[0].Data.Data;
        }
        
        public override string ToString()
        {
            return Title;
        }
    }
}
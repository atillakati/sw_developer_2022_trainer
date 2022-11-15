using System;
using System.Drawing;
using TagLib;
using Wifi.PlaylistEditor.Items.Helper;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items
{
    public class ImageItem : IPlaylistItem
    {
        private string _path;

        public ImageItem()
        {
            _path = string.Empty;
        }

        public ImageItem(string filePath)
        {
            _path = filePath;

            if (!string.IsNullOrWhiteSpace(filePath)) ReadImageTags();
        }

        public string Title { get; set; }

        public string Path
        {
            get => _path;
            set => _path = value;
        }
        public string Artist { get; set; }
        public Image Thumbnail { get; set; }
        public TimeSpan Duration { get; set; }

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

            var tmp = LoadImage();
            Thumbnail = tmp.Resize(128, 128);
        }

        private Image LoadImage()
        {
            if (string.IsNullOrWhiteSpace(_path))
            {
                return null; //Resource.noImage;
            }

            return Image.FromFile(_path);
        }

        public override string ToString()
        {
            return Title;
        }
    }
}
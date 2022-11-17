using System;
using System.Drawing;
using System.IO;
using Wifi.PlaylistEditor.Types;
using File = TagLib.File;

namespace Wifi.PlaylistEditor.Items
{
    public class Mp3Item : IPlaylistItem
    {
        //"C:\Users\User\Music\001 - Bruno Mars - Grenade.mp3"

        /// <summary>
        /// Creates a dummy Mp3Item instance with no tag information
        /// </summary>
        public Mp3Item() { }

        public Mp3Item(string filePath)
        {
            Path = filePath;
            ReadIdTags();
        }

        public string Title { get; set; }

        public string Artist { get; set; }

        public TimeSpan Duration { get; private set; }

        public string Path { get; }

        public Image Thumbnail { get; set; }

        public string Extension => ".mp3";

        public string Description => "MP3 Music File";

        private void ReadIdTags()
        {            
            var tfile = File.Create(Path);

            Title = tfile.Tag.Title;
            Artist = tfile.Tag.FirstAlbumArtist;
            Duration = tfile.Properties.Duration;

            if (tfile.Tag.Pictures != null && tfile.Tag.Pictures.Length > 0)
                //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                Thumbnail = Image.FromStream(new MemoryStream(tfile.Tag.Pictures[0].Data.Data));
            else
                Thumbnail = null;
        }
    }
}
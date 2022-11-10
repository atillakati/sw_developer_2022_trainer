using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Items
{
    public class Mp3Item : IPlaylistItem
    {
        //"C:\Users\User\Music\001 - Bruno Mars - Grenade.mp3"
        private readonly string _path;
        private string _title;
        private string _artist;
        private TimeSpan _duration;
        private Image _thumbnail;

        public Mp3Item(string filePath) 
        {
            _path = filePath;
            ReadIdTags();
        }

        private void ReadIdTags()
        {
            var tfile = TagLib.File.Create(_path);
            
            _title = tfile.Tag.Title;
            _artist = tfile.Tag.FirstAlbumArtist;
            _duration = tfile.Properties.Duration;

            if (tfile.Tag.Pictures != null && tfile.Tag.Pictures.Length > 0)
            {
                //https://stackoverflow.com/questions/10247216/c-sharp-mp3-id-tags-with-taglib-album-art
                _thumbnail = Image.FromStream(new MemoryStream(tfile.Tag.Pictures[0].Data.Data));
            }
            else
            {
                _thumbnail = null;
            }
        }

        public string Titel 
        {
            get => _title;
            set => _title = value; 
        }
        public string Artist 
        {
            get => _artist;
            set => _artist = value;
        }

        public TimeSpan Duration => _duration;

        public string Path => _path;

        public Image Thumbnail 
        {
            get => _thumbnail;
            set => _thumbnail = value;
        }
    }
}

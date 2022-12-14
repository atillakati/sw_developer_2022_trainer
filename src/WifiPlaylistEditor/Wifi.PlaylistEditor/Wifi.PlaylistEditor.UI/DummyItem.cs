using System;
using System.Drawing;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.UI
{
    public class DummyItem : IPlaylistItem
    {
        public DummyItem(TimeSpan duration, string path)
        {
            Duration = duration;
            Path = path;
        }

        public string Title { get; set; }
        public string Artist { get; set; }

        public TimeSpan Duration { get; }

        public string Path { get; }

        public Image Thumbnail { get; set; }

        public string Extension => "REST";

        public string Description => "Content from REST server";

    }
}

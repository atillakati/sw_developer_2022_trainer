﻿using System;
using System.Drawing;


namespace Wifi.PlaylistEditor.Types
{
    public interface IPlaylistItem : IFileDescription
    {
        string Title { get; set; }

        string Artist { get; set; }

        TimeSpan Duration { get; }

        string Path { get; }

        byte[] Thumbnail { get; set; }
    }
}

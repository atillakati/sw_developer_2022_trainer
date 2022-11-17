﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Json
{
    internal static class JsonExtensions
    {
        public static IPlaylist ToDomain(this PlaylistEntity playlistEntity, IPlaylistItemFactory playlistItemFactory)
        {
            var playlist = new Playlist(playlistEntity.title, 
                                        playlistEntity.author, 
                                        DateTime.ParseExact(playlistEntity.createdAt, "yyyy-MM-dd", CultureInfo.InvariantCulture));

            foreach (var item in playlistEntity.items)
            {
                var playlistItem = playlistItemFactory.Create(item.path);
                if(playlistItem != null)
                {
                    playlist.Add(playlistItem);
                }
            }
            
            return playlist;
        }

        public static IEnumerable<ItemEntity> ToEntity(this IEnumerable<IPlaylistItem> playlistItems)
        {
            return playlistItems.Select(x => new ItemEntity { path = x.Path });            
        }

        public static PlaylistEntity ToEntity(this IPlaylist playlist)
        {            
            var playlistEntity = new PlaylistEntity()
            {
                author = playlist.Author,
                title = playlist.Name,
                createdAt = playlist.CreateAt.ToString("yyyy-MM-dd"),
                items = playlist.ItemList.ToEntity()
            };

            return playlistEntity;
        }
    }
}

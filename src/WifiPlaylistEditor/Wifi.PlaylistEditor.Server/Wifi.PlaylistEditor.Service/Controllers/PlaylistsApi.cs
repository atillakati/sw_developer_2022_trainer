using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Wifi.PlaylistEditor.Service.Attributes;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Types;
using SharpCompress.Common;

namespace Wifi.PlaylistEditor.Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("playlistapi/v1")]
    public class PlaylistsApiController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistFactory _playlistFactory;
        

        public PlaylistsApiController(IPlaylistService playlistService, IPlaylistFactory playlistFactory)
        {
            _playlistService = playlistService;
            _playlistFactory = playlistFactory;            
        }

        
        [HttpGet]
        [Route("playlists")]
        [ValidateModelState]        
        public async Task<IActionResult> PlaylistsGet()
        {                                    
            var domainObjects = await _playlistService.GetAllPlaylists();
            if(domainObjects == null)
            {
                return StatusCode(201, new PlaylistList());
            }

            var entity = domainObjects.ToRestEntity();

            return StatusCode(200, entity);
        }

        [HttpGet]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]
        public async Task<IActionResult> PlaylistsPlaylistIdGet([FromRoute][Required] string playlistId)
        {
            if (string.IsNullOrEmpty(playlistId))
            {
                return StatusCode(400);
            }

            var domainObject = await _playlistService.GetPlaylistById(playlistId);
            if (domainObject == null)
            {
                return StatusCode(404);
            }

            var entity = domainObject.ToRestEntity();

            return StatusCode(200, entity);
        }

        [HttpDelete]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]        
        public async Task<IActionResult> PlaylistsPlaylistIdDelete([FromRoute][Required] string playlistId)
        {                        
            var playlist = await _playlistService.GetPlaylistById(playlistId);
            if(playlist == null)
            {
                return StatusCode(404);
            }

            await _playlistService.DeletePlaylist(playlistId);
            return StatusCode(204);
        }
        
        [HttpPut]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]     
        public async Task<IActionResult> PlaylistsPlaylistIdPut([FromBody] PlaylistUpdate body, [FromRoute][Required] string playlistId)
        {            
            var existingPlaylist = await _playlistService.GetPlaylistById(playlistId);
            if (existingPlaylist == null || body == null)
            {
                return StatusCode(404);
            }

            var updatedPlaylist = body.ToDomain(_playlistFactory);
            foreach (var item in body.Items)
            {
                var playlistItem = await _playlistService.GetItemById(item.Id);
                if (playlistItem != null)
                {
                    updatedPlaylist.Add(playlistItem);
                }
                else
                {
                    return StatusCode(404, $"Item with id = {item.Id} not found.");
                }
            }
            
            await _playlistService.UpdatePlaylist(existingPlaylist, updatedPlaylist);
            existingPlaylist = await _playlistService.GetPlaylistById(playlistId);

            return StatusCode(201, existingPlaylist.ToRestEntity());
        }

        [HttpPost]
        [Route("playlists")]
        [ValidateModelState]     
        public async Task<IActionResult> PlaylistsPost([FromBody] PlaylistPost entity)
        {            
            if (entity == null)
            {
                return StatusCode(405);
            }

            var domainObject = entity.ToDomain(_playlistFactory);
            foreach (var item in entity.Items)
            {
                var playlistItem = await _playlistService.GetItemById(item.Id);
                if (playlistItem != null)
                {
                    domainObject.Add(playlistItem);
                }
                else
                {
                    return StatusCode(404, $"Item with id = {item.Id} not found.");
                }
            }

            await _playlistService.AddNewPlaylist(domainObject);

            var playlistEnity = domainObject.ToRestEntity();

            return StatusCode(201, playlistEnity);
        }
    }
}

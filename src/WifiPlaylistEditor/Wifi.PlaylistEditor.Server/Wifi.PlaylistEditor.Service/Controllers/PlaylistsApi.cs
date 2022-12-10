using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Wifi.PlaylistEditor.Service.Attributes;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Types;

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
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public PlaylistsApiController(IPlaylistService playlistService, IPlaylistFactory playlistFactory, IPlaylistItemFactory playlistItemFactory)
        {
            _playlistService = playlistService;
            _playlistFactory = playlistFactory;
            _playlistItemFactory = playlistItemFactory;
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

            var entity = domainObjects.ToEntity();

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

            var entity = domainObject.ToEntity();

            return StatusCode(200, entity);
        }

        [HttpDelete]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]        
        public virtual IActionResult PlaylistsPlaylistIdDelete([FromRoute][Required] string playlistId)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            throw new NotImplementedException();
        }
        
        [HttpPut]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]     
        public virtual IActionResult PlaylistsPlaylistIdPut([FromBody] PlaylistUpdate body, [FromRoute][Required] string playlistId)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Playlist));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            string exampleJson = null;
           
            return new ObjectResult(exampleJson);
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

            return StatusCode(201);
        }
    }
}

/*
 * API description for Playlist project
 *
 * This is a sample Playlist Server based on the OpenAPI 3.0 specification.  You can find out more about OpenAPI at [https://oai.github.io/Documentation](https://oai.github.io/Documentation).      Playlist server should provide following functionalities: - Upload item to server - Delete item from server - Get data from one item - Get list of all items on server - Create playlists - Modify playlists - Get a list of all existing playlists Further sources for information   - [Multipart Requests](https://swagger.io/docs/specification/describing-request-body/multipart-requests)   - [Upload And Download Multiple Files Using Web API](https://github.com/JayKrishnareddy/UploadandDownloadFiles)
 *
 * OpenAPI spec version: 1.0.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;
using Wifi.PlaylistEditor.Service.Attributes;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Service.Mappings;

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

        public PlaylistsApiController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        /// <summary>
        /// Get all existing playlists
        /// </summary>
        /// <remarks>Returns a list of existing playlist</remarks>
        /// <response code="201">Playlist was successful created.</response>
        /// <response code="404">No playlists found</response>
        [HttpGet]
        [Route("playlists")]
        [ValidateModelState]        
        public async Task<IActionResult> PlaylistsGet()
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(PlaylistList));

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            
            var domainObjects = await _playlistService.GetAllPlaylists();

            var entity = domainObjects.ToEntity();

            return new ObjectResult(entity);
        }

        /// <summary>
        /// Deletes a playlist
        /// </summary>
        /// <remarks>delete a playlist</remarks>
        /// <param name="playlistId">ID of playlist to delete</param>
        /// <response code="201">successful operation</response>
        /// <response code="400">Invalid playlist value</response>
        /// <response code="404">Playlist not found</response>
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

        /// <summary>
        /// Returns playlist by ID
        /// </summary>
        /// <remarks>Returns a single playlist</remarks>
        /// <param name="playlistId">ID of playlist to return</param>
        /// <response code="201">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Playlist not found</response>
        [HttpGet]
        [Route("playlists/{playlistId}")]
        [ValidateModelState]        
        public virtual IActionResult PlaylistsPlaylistIdGet([FromRoute][Required] string playlistId)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(Playlist));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            string exampleJson = null;
            exampleJson = "{\n  \"duration\" : 680,\n  \"name\" : \"MyMegaHitsPlaylist_2022\",\n  \"id\" : \"4979875A-A40E-4CC6-99AB-CB5CE62DA97C\",\n  \"items\" : [ {\n    \"duration\" : 205,\n    \"path\" : \"data\\musik\\Bethoven.mp3\",\n    \"thumbnail\" : \"\",\n    \"extension\" : \".mp3\",\n    \"artist\" : \"Gandalf Singer\",\n    \"id\" : \"4979875A-123E-4346-CCAB-CB5CE62DA97C\",\n    \"title\" : \"The bird song\"\n  }, {\n    \"duration\" : 205,\n    \"path\" : \"data\\musik\\Bethoven.mp3\",\n    \"thumbnail\" : \"\",\n    \"extension\" : \".mp3\",\n    \"artist\" : \"Gandalf Singer\",\n    \"id\" : \"4979875A-123E-4346-CCAB-CB5CE62DA97C\",\n    \"title\" : \"The bird song\"\n  } ],\n  \"autor\" : \"DJ Gandalf\",\n  \"dateOfCreation\" : \"2019-05-17T00:00:00.000+00:00\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Playlist>(exampleJson)
            : default(Playlist);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Updates playlist items by ID
        /// </summary>
        /// <remarks>Updates playlist items by ID. The existing items within the playlist will be replaced by received item list.</remarks>
        /// <param name="body">Optional description in *Markdown*</param>
        /// <param name="playlistId">ID of playlist to update</param>
        /// <response code="201">successful operation</response>
        /// <response code="400">Invalid ID supplied</response>
        /// <response code="404">Playlist not found</response>
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
            exampleJson = "{\n  \"duration\" : 680,\n  \"name\" : \"MyMegaHitsPlaylist_2022\",\n  \"id\" : \"4979875A-A40E-4CC6-99AB-CB5CE62DA97C\",\n  \"items\" : [ {\n    \"duration\" : 205,\n    \"path\" : \"data\\musik\\Bethoven.mp3\",\n    \"thumbnail\" : \"\",\n    \"extension\" : \".mp3\",\n    \"artist\" : \"Gandalf Singer\",\n    \"id\" : \"4979875A-123E-4346-CCAB-CB5CE62DA97C\",\n    \"title\" : \"The bird song\"\n  }, {\n    \"duration\" : 205,\n    \"path\" : \"data\\musik\\Bethoven.mp3\",\n    \"thumbnail\" : \"\",\n    \"extension\" : \".mp3\",\n    \"artist\" : \"Gandalf Singer\",\n    \"id\" : \"4979875A-123E-4346-CCAB-CB5CE62DA97C\",\n    \"title\" : \"The bird song\"\n  } ],\n  \"autor\" : \"DJ Gandalf\",\n  \"dateOfCreation\" : \"2019-05-17T00:00:00.000+00:00\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<Playlist>(exampleJson)
            : default(Playlist);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// Creates a new playlist with data provided in body
        /// </summary>
        /// <param name="body">Creates new playlist with provided data in body.</param>
        /// <response code="201">successful operation</response>
        /// <response code="405">Invalid input</response>
        [HttpPost]
        [Route("playlists")]
        [ValidateModelState]     
        public virtual IActionResult PlaylistsPost([FromBody] PlaylistPost body)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(PlaylistLink));

            //TODO: Uncomment the next line to return response 405 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(405);
            string exampleJson = null;
            exampleJson = "{\n  \"href\" : \"http://localhost/playlistapi/playlists/4979875A-A40E-4CC6-99AB-CB5CE62DA97C\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<PlaylistLink>(exampleJson)
            : default(PlaylistLink);            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}

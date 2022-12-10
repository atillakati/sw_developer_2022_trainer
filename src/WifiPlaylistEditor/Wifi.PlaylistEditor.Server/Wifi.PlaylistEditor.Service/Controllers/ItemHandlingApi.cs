using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Wifi.PlaylistEditor.Service.Attributes;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;

namespace Wifi.PlaylistEditor.Service.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("playlistapi/v1")]
    public class ItemHandlingApiController : ControllerBase
    {
        private readonly IHostEnvironment _hostEnvironment;
        private readonly IPlaylistService _playlistService;
        private readonly IPlaylistItemFactory _playlistItemFactory;

        public ItemHandlingApiController(IHostEnvironment hostEnvironment, IPlaylistService playlistService, IPlaylistItemFactory playlistItemFactory)
        {
            _hostEnvironment = hostEnvironment;
            _playlistService = playlistService;
            _playlistItemFactory = playlistItemFactory;
        }

        
        [HttpGet]
        [Route("items")]
        [ValidateModelState]
        public async Task<IActionResult> ItemsGet()
        {            
            IEnumerable<IPlaylistItem> items = await _playlistService.GetAllItems();

            var entity = items.ToEntity();

            return StatusCode(200, entity);
        }

        
        [HttpDelete]
        [Route("items/{itemId}")]
        [ValidateModelState]
        public virtual IActionResult ItemsItemIdDelete([FromRoute][Required] string itemId)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201);

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);

            //TODO: Uncomment the next line to return response 423 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(423);

            throw new NotImplementedException();
        }

        
        [HttpGet]
        [Route("items/{itemId}")]
        [ValidateModelState]
        public virtual IActionResult ItemsItemIdGet([FromRoute][Required] string itemId)
        {
            //TODO: Uncomment the next line to return response 201 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(201, default(PlaylistItem));

            //TODO: Uncomment the next line to return response 400 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(400);

            //TODO: Uncomment the next line to return response 404 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(404);
            string exampleJson = null;
            exampleJson = "{\n  \"duration\" : 205,\n  \"path\" : \"data\\musik\\Bethoven.mp3\",\n  \"thumbnail\" : \"\",\n  \"extension\" : \".mp3\",\n  \"artist\" : \"Gandalf Singer\",\n  \"id\" : \"4979875A-123E-4346-CCAB-CB5CE62DA97C\",\n  \"title\" : \"The bird song\"\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<PlaylistItem>(exampleJson)
            : default(PlaylistItem);            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        [HttpPost]
        [Route("items")]
        [ValidateModelState]
        public async Task<IActionResult> Post([FromForm] string filename, [FromForm] string extension, [FromForm] IFormFile file)
        {
            string uploads = Path.Combine(_hostEnvironment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            string filePath = Path.Combine(uploads, file.FileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream).Wait();
            }
            
            var domainItem = _playlistItemFactory.Create(filePath);
            await _playlistService.AddItem(domainItem);
            
            return StatusCode(201);
        }
    }
}

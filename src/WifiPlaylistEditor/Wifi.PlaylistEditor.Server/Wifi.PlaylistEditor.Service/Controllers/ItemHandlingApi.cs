using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using Wifi.PlaylistEditor.Service.Attributes;
using Wifi.PlaylistEditor.Service.Models;
using Wifi.PlaylistEditor.Service.Mappings;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Types;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using System.Text;

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

            var entity = items.ToRestEntity();

            return StatusCode(200, entity);
        }

        
        [HttpDelete]
        [Route("items/{itemId}")]
        [ValidateModelState]
        public async Task<IActionResult> ItemsItemIdDelete([FromRoute][Required] string itemId)
        {            
            var item = await _playlistService.GetItemById(itemId);
            if(item == null)
            {
                return StatusCode(404);
            }

            if (System.IO.File.Exists(item.Path))
            {
                System.IO.File.Delete(item.Path);
            }

            await _playlistService.DeleteItem(itemId);

            return StatusCode(204);
        }

        
        [HttpGet]
        [Route("items/{itemId}")]
        [ValidateModelState]
        public async Task<IActionResult> ItemsItemIdGet([FromRoute][Required] string itemId)
        {
            var item = await _playlistService.GetItemById(itemId);

            if(item == null) 
            {
                return StatusCode(404);
            }

            var entity = item.ToRestEntity();
            return StatusCode(200, entity);
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
            
            var path = $"{Request.HttpContext.Request.Scheme}://{Request.HttpContext.Request.Host}{Request.HttpContext.Request.Path}/{domainItem.Id}";
            return StatusCode(201, new Models.ItemLink { Href = path});
        }
    }
}

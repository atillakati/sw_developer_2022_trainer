# WIFI PlaylistEditor Server

![Overview](images/overview.drawio.png)

Database & REST API KnowHow:
[Create a web API with ASP.NET Core and MongoDB](https://learn.microsoft.com/en-us/aspnet/core/tutorials/first-mongo-app?view=aspnetcore-7.0&tabs=visual-studio)

Existing implementation with MongoDB.Driver
[Wifi.PlaylistEditor.Repositories.MongoDb](https://github.com/atillakati/SWDeveloper2019/tree/master/src/Wifi.PlaylistEditor.Repositories.MongoDb)

C# MongoDB Guide
[C# MongoDB Guide](https://rubikscode.net/2022/07/25/c-mongodb-guide)

ZetCode C# MongoDB tutorial
[C# MongoDB tutorial](https://zetcode.com/csharp/mongodb/)

## Uploading files using WebAPI POST
```charp
        [HttpPost]
        [Route("items")]
        [ValidateModelState]
        public IActionResult Post([FromForm] string filename, [FromForm] string extension, [FromForm] IFormFile file)
        {
            string uploads = Path.Combine(_environment.ContentRootPath, "uploads");
            if (!Directory.Exists(uploads))
            {
                Directory.CreateDirectory(uploads);
            }
            string filePath = Path.Combine(uploads, file.FileName);

            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
            {
                file.CopyToAsync(fileStream).Wait();
            }

            //process the parameters
            var length = file.Length;
           
            return StatusCode(201, $"{extension} {filename} => {length} bytes saved in : {filePath}");
        }
```

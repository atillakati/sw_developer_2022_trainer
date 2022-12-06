using Wifi.PlaylistEditor.DbRepositories;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;
using Wifi.PlaylistEditor.Factories;
using Wifi.PlaylistEditor.Service.Domain;
using Wifi.PlaylistEditor.Types;

var builder = WebApplication.CreateBuilder(args);
builder.Services.Configure<PlaylistDbSettings>(
    builder.Configuration.GetSection("PlaylistDbSettings"));

// Add services to the container.
builder.Services.AddScoped<IPlaylistFactory, PlaylistFactory>();
builder.Services.AddScoped<IPlaylistService, PlaylistService>();
builder.Services.AddScoped<IPlaylistItemFactory, PlaylistItemFactory>();
builder.Services.AddScoped<IDatabaseRepository<PlaylistEntity>, MongoDbRepository>();


builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();

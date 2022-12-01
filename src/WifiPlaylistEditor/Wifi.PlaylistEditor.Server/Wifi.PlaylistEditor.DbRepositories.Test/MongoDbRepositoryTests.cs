using Microsoft.Extensions.Options;
using NUnit.Framework;
using Wifi.PlaylistEditor.DbRepositories.MongoDbEntities;

namespace Wifi.PlaylistEditor.DbRepositories.Test
{
    [TestFixture]
    public class MongoDbRepositoryTests
    {
        private IDatabaseRepository<PlaylistEntity> _fixture;

        [SetUp]
        public void Setup()
        {
            var options = Options.Create(new PlaylistDbSettings
            {
                ConnectionString = "mongodb://admin:password@localhost:27017",
                DatabaseName = "playlistDb",
                CollectionName = "playlists"
            });

            _fixture = new MongoDbRepository(options);
        }

        [OneTimeTearDown]
        public void Clear()
        {

        }

        [Test]
        public async Task CreatAsync()
        {
            //arrange
            var entity = new PlaylistEntity
            {
                Author = "DJ Gandalf",
                Title = "Meine Top Charts 2022",
                CreatedAt = "20221201",
                Id = Guid.NewGuid().ToString(),
                Items = new List<PlaylistItemEntity>
                {
                    new PlaylistItemEntity
                    {
                        Id= Guid.NewGuid().ToString(),
                        Path = @"/app/uploads/meinSuper song_1.mp3"
                    },
                    new PlaylistItemEntity
                    {
                        Id= Guid.NewGuid().ToString(),
                        Path = @"/app/uploads/Griechischer Wein.mp3"
                    }
                }
            };

            //act
            await _fixture.CreateAsync(entity);

            //assert
        }
    }
}
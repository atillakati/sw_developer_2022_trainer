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
            var playlists = _fixture.GetAsync().Result;
            foreach (PlaylistEntity playlist in playlists)
            {
                _fixture.RemoveAsync(playlist.Id).Wait();
            }
        }

        [Test]
        [Ignore("MongoDB server needed")]
        [Category("Integration Test")]
        public async Task CreatAsync()
        {
            //arrange            
            var reference = Guid.NewGuid(); 
            var entity = CreateEntity(reference);

            //act
            await _fixture.CreateAsync(entity);

            //assert
            var createdItem = await _fixture.GetAsync(reference.ToString());
            Assert.That(createdItem,Is.Not.Null);
            Assert.That(createdItem.Id, Is.EqualTo(reference.ToString()));
        }

        [Test]
        [Ignore("MongoDB server needed")]
        [Category("Integration Test")]
        public async Task UpdateAsync()
        {
            //arrange            
            var reference = Guid.NewGuid();
            var entity = CreateEntity(reference);
            await _fixture.CreateAsync(entity);

            entity.Author = "NUnit Update Test";

            //act
            await _fixture.UpdateAsync(reference.ToString(), entity);

            //assert
            var item = await _fixture.GetAsync(reference.ToString());
            Assert.That(item.Author, Is.EqualTo("NUnit Update Test"));            
        }

        [Test]
        [Ignore("MongoDB server needed")]
        [Category("Integration Test")]
        public async Task GetAsyncById()
        {
            //arrange            
            var reference = Guid.NewGuid();
            var entity = CreateEntity(reference);
            await _fixture.CreateAsync(entity);


            //act
            var createdItem = await _fixture.GetAsync(reference.ToString());

            //assert
            Assert.That(createdItem, Is.Not.Null);
            Assert.That(createdItem.Id, Is.EqualTo(reference.ToString()));
        }

        [Test]
        [Ignore("MongoDB server needed")]
        [Category("Integration Test")]
        public async Task GetAsync()
        {
            //arrange
            var reference = Guid.NewGuid();           
            var entity = CreateEntity(reference);
            await _fixture.CreateAsync(entity);

            //act
            var createdItems = await _fixture.GetAsync();

            //assert
            Assert.That(createdItems, Is.Not.Null);
            Assert.That(createdItems.Count, Is.AtLeast(1));
        }

        [Test]
        [Ignore("MongoDB server needed")]
        [Category("Integration Test")]
        public async Task RemoveAsync()
        {
            //arrange            
            var reference = Guid.NewGuid();
            var entity = CreateEntity(reference);
            await _fixture.CreateAsync(entity);

            //act
            await _fixture.RemoveAsync(reference.ToString());

            //assert
            var item = await _fixture.GetAsync(reference.ToString());
            Assert.That(item, Is.Null);
        }


        private PlaylistEntity CreateEntity(Guid? id = null)
        {
            if (id == null)
            {
                id = Guid.NewGuid();
            }

            return new PlaylistEntity
            {
                Author = "DJ Gandalf",
                Title = "Meine Top Charts 2022",
                CreatedAt = "20221201",
                Id = id.ToString(),
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
        }
    }
}
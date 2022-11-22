using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class M3uRepositoryTests
    {
        private Mock<IPlaylistItemFactory> _mockedPlaylistItemFactory;
        private Mock<IFileSystem> _mockedFileSystem;
        private IRepository _fixture;
        private Mock<IPlaylist> _mockedPlaylist;

        private string _referenceContent = "#EXTM3U\r\n#EXTINF:100,Demo Song 1\r\nc:\\myMusic\\Demo Song 1.mp3\r\n#EXTINF:120,Super Song\r\nc:\\myMusic\\SuperDuperSong2.mp3";

        [SetUp]
        public void Init()
        {
            _mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();

            _mockedFileSystem = new Mock<IFileSystem>();
            _fixture = new M3uRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            var mockedItem1 = new Mock<IPlaylistItem>();
            mockedItem1.Setup(x => x.Title).Returns("Demo Song 1");
            mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(100));
            mockedItem1.Setup(x => x.Path).Returns(@"c:\myMusic\Demo Song 1.mp3");

            var mockedItem2 = new Mock<IPlaylistItem>();
            mockedItem2.Setup(x => x.Title).Returns("Super Song");
            mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(120));
            mockedItem2.Setup(x => x.Path).Returns(@"c:\myMusic\SuperDuperSong2.mp3");

            var myMockedItems = new[] { mockedItem1.Object, mockedItem2.Object };

            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedPlaylist.Setup(x => x.Author).Returns("DJ Gandalf");
            _mockedPlaylist.Setup(x => x.Name).Returns("MeineTopHits2022");
            _mockedPlaylist.Setup(x => x.CreateAt).Returns(new DateTime(2022, 11, 15));
            _mockedPlaylist.Setup(x => x.ItemList).Returns(myMockedItems);
        }


        [Test]
        public void Extension_get()
        {
            var extension = _fixture.Extension;

            Assert.That(extension, Is.EqualTo(".m3u"));
        }

        [Test]
        public void Description_get()
        {
            var description = _fixture.Description;

            Assert.That(description, Is.EqualTo("M3U Playlist file"));
        }

        [Test]
        public void Save()
        {
            //Arrange
            string contentToWrite = string.Empty;            

            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                      .Callback<string, string>((path, content) =>
                      {
                          contentToWrite = content;
                      });

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _fixture = new M3uRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //Act
            _fixture.Save(_mockedPlaylist.Object, @"c:\temp\meinePlaylist.m3u");

            //Assert
            Assert.That(contentToWrite, Is.EqualTo(_referenceContent));
        }

        [Test]
        public void Save_FilenameIsInvalid()
        {
            //Arrange
            string contentToWrite = string.Empty;
            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                      .Callback<string, string>((path, content) =>
                      {
                          contentToWrite = content;
                      });

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _fixture = new M3uRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //Act
            _fixture.Save(_mockedPlaylist.Object, string.Empty);

            //Assert
            mockedFile.Verify(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Save_PlaylistIsNull()
        {
            //Arrange

            //Act
            _fixture.Save(null, string.Empty);

            //Assert

        }

        [Test]
        public void Load()
        {
            //Arrange    
            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.OpenRead("demoplaylist.m3u")).Returns(new MemoryStream(Encoding.UTF8.GetBytes(_referenceContent)));
            mockedFile.Setup(x => x.Exists("demoplaylist.m3u")).Returns(true);

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _mockedPlaylistItemFactory = CreateMockedPlaylistItemFactory();

            _fixture = new M3uRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load("demoplaylist.m3u");

            //assert
            Assert.That(playlist.Duration, Is.EqualTo(TimeSpan.FromSeconds(220)));
            Assert.That(playlist.ItemList.Count(), Is.EqualTo(2));
        }

        [Test]
        [TestCaseSource(nameof(LoadTestCases))]
        public void Load_WithTestData(int testNr, string data)
        {
            //Arrange            
            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MemoryStream(Encoding.UTF8.GetBytes(_referenceContent)));
            mockedFile.Setup(x => x.Exists(It.IsAny<string>())).Returns(false);

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _fixture = new M3uRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load(data);

            //assert
            Assert.That(playlist, Is.Null);
            mockedFile.Verify(x => x.OpenRead(It.IsAny<string>()), Times.Never);
        }

        public static IEnumerable<object> LoadTestCases()
        {
            return new object[]
            {
                new object[]{ 1, string.Empty},
                new object[]{ 2, null},
                new object[]{ 3, @"p:\09384523\04958"},
            };
        }

        private Mock<IPlaylistItemFactory> CreateMockedPlaylistItemFactory()
        {
            var mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();

            var mockedItem1 = new Mock<IPlaylistItem>();
            mockedItem1.Setup(x => x.Title).Returns("Demo Song 1");
            mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(100));
            mockedItem1.Setup(x => x.Path).Returns(@"c:\myMusic\Demo Song 1.mp3");

            var mockedItem2 = new Mock<IPlaylistItem>();
            mockedItem2.Setup(x => x.Title).Returns("Super Song");
            mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(120));
            mockedItem2.Setup(x => x.Path).Returns(@"c:\myMusic\SuperDuperSong2.mp3");

            mockedPlaylistItemFactory.Setup(x => x.Create(@"c:\myMusic\Demo Song 1.mp3")).Returns(mockedItem1.Object);
            mockedPlaylistItemFactory.Setup(x => x.Create(@"c:\myMusic\SuperDuperSong2.mp3")).Returns(mockedItem2.Object);

            return mockedPlaylistItemFactory;
        }
    }
}

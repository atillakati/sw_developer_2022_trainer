using Moq;
using NUnit.Framework;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class PlsRepositoryTests
    {
        private Mock<IPlaylistItemFactory> _mockedPlaylistItemFactory;
        private Mock<IFileSystem> _mockedFileSystem;
        private IRepository _fixture;
        private Mock<IPlaylist> _mockedPlaylist;

        private string _referenceContent = "[playlist]\r\n\r\nFile1=c:\\myMusic\\Demo Song 1.mp3\r\nTitle1=Demo Song 1\r\nLength1=100\r\n\r\nFile2=c:\\myMusic\\SuperDuperSong2.mp3\r\nTitle2=Super Song\r\nLength2=120\r\n\r\nNumberOfEntries=2\r\n\r\nVersion=2";

        [SetUp]
        public void Init()
        {
            _mockedPlaylistItemFactory = new Mock<IPlaylistItemFactory>();

            _mockedFileSystem = new Mock<IFileSystem>();
            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

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

            Assert.That(extension, Is.EqualTo(".pls"));
        }

        [Test]
        public void Description_get()
        {
            var description = _fixture.Description;

            Assert.That(description, Is.EqualTo("PLS Playlist file"));
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

            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

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

            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

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
            mockedFile.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MemoryStream(Encoding.UTF8.GetBytes(_referenceContent)));                      

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _mockedPlaylistItemFactory = CreateMockedPlaylistItemFactory();

            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load("demoplaylist.m3u");

            //assert
            Assert.That(playlist.Duration, Is.EqualTo(TimeSpan.FromSeconds(220)));
            Assert.That(playlist.ItemList.Count(), Is.EqualTo(2));
        }

        [Test]
        public void Load_PlaylistpathIsEmpty()
        {
            //Arrange            
            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MemoryStream(Encoding.UTF8.GetBytes(_referenceContent)));

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);            

            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load(string.Empty);

            //assert
            Assert.That(playlist, Is.Null);
            mockedFile.Verify(x => x.OpenRead(It.IsAny<string>()), Times.Never);
        }

        [Test]
        public void Load_PlaylistpathIsNull()
        {
            //Arrange            
            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.OpenRead(It.IsAny<string>())).Returns(new MemoryStream(Encoding.UTF8.GetBytes(_referenceContent)));

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _fixture = new PlsRepository(_mockedFileSystem.Object, _mockedPlaylistItemFactory.Object);

            //act
            var playlist = _fixture.Load(null);

            //assert
            Assert.That(playlist, Is.Null);
            mockedFile.Verify(x => x.OpenRead(It.IsAny<string>()), Times.Never);
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

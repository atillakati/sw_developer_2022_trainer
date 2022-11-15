using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wifi.PlaylistEditor.Types;

namespace Wifi.PlaylistEditor.Repositories.Test
{
    [TestFixture]
    public class m3uRepositoryTests
    {
        private Mock<IFileSystem> _mockedFileSystem;
        private IRepository _fixture;
        private Mock<IPlaylist> _mockedPlaylist;

        [SetUp]
        public void Init()
        {            
            _mockedFileSystem = new Mock<IFileSystem>();
            _fixture = new M3uRepository(_mockedFileSystem.Object);

            var mockedItem1 = new Mock<IPlaylistItem>();
            mockedItem1.Setup(x => x.Title).Returns("Demo Song 1");
            mockedItem1.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(100));
            mockedItem1.Setup(x => x.Path).Returns(@"c:\myMusic\Demo Song 1.mp3");

            var mockedItem2 = new Mock<IPlaylistItem>();
            mockedItem2.Setup(x => x.Title).Returns("Super Song");
            mockedItem2.Setup(x => x.Duration).Returns(TimeSpan.FromSeconds(120));
            mockedItem2.Setup(x => x.Path).Returns(@"c:\myMusic\SuperDuperSong2.mp3");

            var myMockedItems = new [] { mockedItem1.Object, mockedItem2.Object };

            _mockedPlaylist = new Mock<IPlaylist>();
            _mockedPlaylist.Setup(x => x.Author).Returns("DJ Gandalf");
            _mockedPlaylist.Setup(x => x.Name).Returns("MeineTopHits2022");
            _mockedPlaylist.Setup(x => x.CreateAt).Returns(new DateTime(2022, 11, 15));            
            _mockedPlaylist.Setup(x => x.ItemList).Returns(myMockedItems);
        }
        

        [Test]
        public void Save()
        {
            //Arrange
            string contentToWrite = string.Empty;
            string referenceContent = "#EXTM3U\r\n#EXTINF:100,Demo Song 1\r\nc:\\myMusic\\Demo Song 1.mp3\r\n#EXTINF:120,Super Song\r\nc:\\myMusic\\SuperDuperSong2.mp3";

            var mockedFile = new Mock<IFile>();
            mockedFile.Setup(x => x.WriteAllText(It.IsAny<string>(), It.IsAny<string>()))
                      .Callback<string, string>((path, content) =>
                      {
                          contentToWrite = content;
                      });

            _mockedFileSystem = new Mock<IFileSystem>();
            _mockedFileSystem.Setup(x => x.File).Returns(mockedFile.Object);

            _fixture = new M3uRepository(_mockedFileSystem.Object);
            
            //Act
            _fixture.Save(_mockedPlaylist.Object, @"c:\temp\meinePlaylist.m3u");

            //Assert
            Assert.That(contentToWrite, Is.EqualTo(referenceContent));
        }
    }
}

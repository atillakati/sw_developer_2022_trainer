using NUnit.Framework;
using System;
using Wifi.PlaylistEditor.Types;


namespace Wifi.PlaylistEditor.Types.Test
{
    [TestFixture]
    public class PlaylistTests
    {
        private IPlaylist _fixture;


        [SetUp]
        public void Init()
        {
            _fixture = new Playlist("TopHits2022", "Gandalf", new DateTime(2022,4,15));
        }

        [Test]
        public void AdditionOfIntValues()
        {
            //arrange
            int zahl1 = 5;
            int zahl2 = 8;
            int ergSoll = 13;

            //act
            var result = zahl1 + zahl2;

            //assert
            Assert.That(result, Is.EqualTo(ergSoll));
        }
    }
}

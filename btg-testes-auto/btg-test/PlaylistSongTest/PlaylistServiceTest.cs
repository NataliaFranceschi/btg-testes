using btg_testes_auto.PlaylistSongs;
using FluentAssertions;
using NSubstitute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace btg_test.PlaylistSongTest
{
    public class PlaylistServiceTest
    {
        private readonly IPlaylistValidationService _mockPlaylistValidationService;
        private PlaylistService _sut; 

        public PlaylistServiceTest()
        {
            _mockPlaylistValidationService = Substitute.For<IPlaylistValidationService>();
            _sut = new(_mockPlaylistValidationService);
        }

        Song song1 = new Song() { Artist = "artist1", Title = "title1" };
        Song song2 = new Song() { Artist = "artist2", Title = "title2" };
        Song song3 = new Song() { Artist = "artist3", Title = "title3" };

        [Fact]
        public void AddSongToPlaylist_PlaylistWithSpace_ReturnTrue()
        {
            List<Song> list = new List<Song>() { song1, song2 };
            Playlist playlist = new Playlist() { MaxSongs = 3, Songs = list };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3)
                .Returns(true);

            bool result = _sut.AddSongToPlaylist(playlist, song3);

            result.Should().BeTrue();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, song3);
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
            playlist.Songs.Should().Contain(song3);
        }

        [Fact]
        public void AddSongToPlaylist_FullPlaylist_ReturnFalse()
        {
            List<Song> list = new List<Song>() { song1, song2 };
            Playlist playlist = new Playlist() { MaxSongs = 2, Songs = list };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3)
                .Returns(false);

            bool result = _sut.AddSongToPlaylist(playlist, song3);

            result.Should().BeFalse();
            _mockPlaylistValidationService.Received().CanAddSongToPlaylist(playlist, song3);
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
            playlist.Songs.Should().NotContain(song3);
        }

        [Fact]
        public void AddSongsToPlaylist_PlaylistWithSpace_AllSongsAdded()
        {
            List<Song> songs = new List<Song>() { song1, song2 };

            Playlist playlist = new Playlist() { MaxSongs = 3, Songs = new List<Song>() };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>())
                .Returns(true);

            _sut.AddSongsToPlaylist(playlist, songs);

            _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
        }

        [Fact]
        public void AddSongsToPlaylist_Playlist2EmptySpace_2of3SongsAdded()
        {
            List<Song> songs = new List<Song>() { song1, song2, song3 };

            Playlist playlist = new Playlist() { MaxSongs = 2, Songs = new List<Song>() };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song1)
                .Returns(true);
            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song2)
                .Returns(true);
            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, song3)
                .Returns(false);

            _sut.AddSongsToPlaylist(playlist, songs);

            _mockPlaylistValidationService.Received(3).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().Contain(song2);
            playlist.Songs.Should().NotContain(song3);
        }

        [Fact]
        public void AddSongsToPlaylist_FullPlaylist_NoSongsWereAdded()
        {
            List<Song> songs = new List<Song>() { song2, song3 };

            Playlist playlist = new Playlist() { MaxSongs = 1, Songs = new List<Song>() { song1} };

            _mockPlaylistValidationService.CanAddSongToPlaylist(playlist, Arg.Any<Song>())
                .Returns(false);

            _sut.AddSongsToPlaylist(playlist, songs);

            _mockPlaylistValidationService.Received(2).CanAddSongToPlaylist(playlist, Arg.Any<Song>());
            playlist.Songs.Should().Contain(song1);
            playlist.Songs.Should().NotContain(song2);
            playlist.Songs.Should().NotContain(song3);
        }

    }
}

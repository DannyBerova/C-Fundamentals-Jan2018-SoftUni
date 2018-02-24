using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    public class Startup
    {
        public static void Main()
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            var songs = new List<Song>();

            for (int index = 0; index < numberOfSongs; index++)
            {
                var songTokens = Console.ReadLine().Split(';').ToArray();

                try
                {
                    AddValidSong(songs, songTokens);
                }
                catch (Exception ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            int result = GetTotalLengthOfPlaylist(songs);

            PrintCountOfSongsAddedAndTotalLengthOfPlaylist(songs, result);
        }

        private static void AddValidSong(List<Song> songs, string[] songTokens)
        {
            var artist = new Artist(songTokens[0]);
            var lenght = songTokens[2];
            var song = new Song(artist, songTokens[1], lenght);
            songs.Add(song);
            Console.WriteLine("Song added.");
        }

        private static void PrintCountOfSongsAddedAndTotalLengthOfPlaylist(List<Song> songs, int result)
        {
            TimeSpan t = TimeSpan.FromSeconds(result);
            string playlistLength = $"{t.Hours:D1}h {t.Minutes:D1}m {t.Seconds:D1}s";

            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine($"Playlist length: {playlistLength}");
        }

        private static int GetTotalLengthOfPlaylist(List<Song> songs)
        {
            var result = 0;
            foreach (var song in songs)
            {
                var time = song.Lenght.Split(':').ToArray();
                var minutes = time[0];
                var seconds = time[1];

                result += int.Parse(seconds) + int.Parse(minutes) * 60;
            }

            return result;
        }
    }
}
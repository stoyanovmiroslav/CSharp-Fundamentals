using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.OnlineRadioDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<RadioStation> songs = new List<RadioStation>();

            for (int i = 0; i < n; i++)
            {
                try
                {
                    CreateNewSong(songs);
                }
                catch (ArgumentException argEx)
                {
                    Console.WriteLine(argEx.Message);
                }
            }

            string playListLength = CalculatePlayListLength(songs);
            Console.WriteLine($"Songs added: {songs.Count}");
            Console.WriteLine(playListLength);
        }

        private static void CreateNewSong(List<RadioStation> songs)
        {
            string[] input = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

            string artistName = input[0];
            string songName = input[1];
            string[] minutesSecond = input[2].Split(":");

            IsSongLenghtValid(minutesSecond);
            int minutes = int.Parse(minutesSecond[0]);
            int seconds = int.Parse(minutesSecond[1]);

            RadioStation radioStation = new RadioStation(artistName, songName, minutes, seconds);
            songs.Add(radioStation);
            Console.WriteLine("Song added.");
        }

        private static string CalculatePlayListLength(List<RadioStation> songs)
        {
            string playListLength = "Playlist length: 0h 0m 0s";

            if (songs.Count > 0)
            {
                int minutes = songs.Select(x => x.Minutes).Sum();
                int second = songs.Select(x => x.Seconds).Sum();

                long allSeconds = minutes * 60 + second;
                TimeSpan t = TimeSpan.FromSeconds(allSeconds);

                playListLength = string.Format("Playlist length: {0}h {1}m {2}s",
                                t.Hours,
                                t.Minutes,
                                t.Seconds);
            }

            return playListLength;
        }

        private static void IsSongLenghtValid(string[] minutesSecond)
        {
            if (int.TryParse(minutesSecond[0], out _) == false || int.TryParse(minutesSecond[1], out _) == false)
            {
                throw new ArgumentException("Invalid song length.");
            }
        }
    }
}
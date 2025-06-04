using System;
using System.Collections.Generic;
using System.Linq;

public class MyPlayList : IPlaylist
{
    public static List<Song> myPlayList = new List<Song>();
    private const int Capacity = 20;
    private static readonly string[] validGenres =
    { "Pop", "HipHop", "Soul Music", "Jazz", "Rock", "Disco", "Melody", "Classic" };

    public MyPlayList() { }

    public void Add(Song song)
    {
        if (myPlayList.Count >= Capacity)
        {
            Console.WriteLine("Playlist is full. Cannot add more songs.");
            return;
        }

        if (!validGenres.Contains(song.SongGenre, StringComparer.OrdinalIgnoreCase))
        {
            Console.WriteLine("Invalid genre. Allowed genres are:");
            Console.WriteLine(string.Join(", ", validGenres));
            return;
        }

        if (myPlayList.Any(s => s.SongId == song.SongId))
        {
            Console.WriteLine("Song with this ID already exists.");
            return;
        }

        myPlayList.Add(song);
        Console.WriteLine("Song added successfully.");
    }

    public void Remove(int songId)
    {
        Song song = GetSongById(songId);
        if (song != null)
        {
            myPlayList.Remove(song);
            Console.WriteLine("Song removed successfully.");
        }
        else
        {
            Console.WriteLine("Song not found.");
        }
    }

    public Song GetSongById(int songId)
    {
        return myPlayList.FirstOrDefault(s => s.SongId == songId);
    }

    public Song GetSongByName(string songName)
    {
        return myPlayList.FirstOrDefault(s => s.SongName.Equals(songName, StringComparison.OrdinalIgnoreCase));
    }

    public List<Song> GetAllSongs()
    {
        return myPlayList;
    }
}

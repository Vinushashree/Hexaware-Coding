public class Song
{
    public int SongId { get; set; }
    public string SongName { get; set; }
    public string SongGenre { get; set; }

    public Song(int songId, string songName, string songGenre)
    {
        SongId = songId;
        SongName = songName;
        SongGenre = songGenre;
    }

    public override string ToString()
    {
        return $"ID: {SongId}, Name: {SongName}, Genre: {SongGenre}";
    }
}


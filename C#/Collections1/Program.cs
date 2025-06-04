using System;

class Program
{
    static void Main(string[] args)
    {
        MyPlayList playlist = new MyPlayList();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nEnter your choice:");
            Console.WriteLine("1. Add Song");
            Console.WriteLine("2. Remove Song by ID");
            Console.WriteLine("3. Get Song by ID");
            Console.WriteLine("4. Get Song by Name");
            Console.WriteLine("5. Get All Songs");
            Console.WriteLine("6. Exit");

            Console.Write("Choice: ");
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Write("Enter Song ID: ");
                    int id = int.Parse(Console.ReadLine());

                    Console.Write("Enter Song Name: ");
                    string name = Console.ReadLine();

                    Console.Write("Enter Song Genre: ");
                    string genre = Console.ReadLine();

                    playlist.Add(new Song(id, name, genre));
                    break;

                case "2":
                    Console.Write("Enter Song ID to remove: ");
                    int removeId = int.Parse(Console.ReadLine());
                    playlist.Remove(removeId);
                    break;

                case "3":
                    Console.Write("Enter Song ID to retrieve: ");
                    int searchId = int.Parse(Console.ReadLine());
                    Song songById = playlist.GetSongById(searchId);
                    Console.WriteLine(songById != null ? songById.ToString() : "Song not found.");
                    break;

                case "4":
                    Console.Write("Enter Song Name to retrieve: ");
                    string searchName = Console.ReadLine();
                    Song songByName = playlist.GetSongByName(searchName);
                    Console.WriteLine(songByName != null ? songByName.ToString() : "Song not found.");
                    break;

                case "5":
                    var allSongs = playlist.GetAllSongs();
                    if (allSongs.Count == 0)
                    {
                        Console.WriteLine("No songs in playlist.");
                    }
                    else
                    {
                        Console.WriteLine("Songs in Playlist:");
                        allSongs.ForEach(s => Console.WriteLine(s));
                    }
                    break;

                case "6":
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid input. Try again.");
                    break;
            }
        }
    }
}


using System;
using System.Collections.Generic;

namespace Assignment9;

public class Show : Media
{
    public int Episode { get; set; }
    public int Season { get; set; }
    public string Writers { get; set; }

    public override void Display()
    {
        List<string> Id = new List<string>();
        List<string> Title = new List<string>();
        List<string> Season = new List<string>();
        List<string> Episode = new List<string>();
        List<string> Writers = new List<string>();
        String filename = "shows.csv";
        StreamReader sr = new StreamReader(filename);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
            Season.Add(movies[2]);
            Episode.Add(movies[3]);
            Writers.Add(movies[4]);
        }
        sr.Close();

        for (int i = 0; i < Id.Count; i++)
        {
            Console.WriteLine($"Id: {Id[i]}");
            Console.WriteLine($"Title: {Title[i]}");
            Console.WriteLine($"Season: {Season[i]}");
            Console.WriteLine($"Episode: {Episode[i]}");
            Console.WriteLine($"Writer(s): {Writers[i]}");
            Console.WriteLine();
        }


    }
}

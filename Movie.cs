using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Assignment9;

public class Movie : Media
{
    public string Genres { get; set; }

    public override void Display()
    {
        List<string> Id = new List<string>();
        List<string> Title = new List<string>();
        List<string> Genre = new List<string>();
        String filename = "movies.csv";
        StreamReader sr = new StreamReader(filename);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
            Genre.Add(movies[2]);
        }
        sr.Close();

        for (int i = 0; i < Id.Count; i++)
        {
            Console.WriteLine($"Id: {Id[i]}");
            Console.WriteLine($"Title: {Title[i]}");
            Console.WriteLine($"Genre(s): {Genre[i]}");
            Console.WriteLine();
        }
    }
}

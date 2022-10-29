using System;
using System.Collections.Generic;

namespace Assignment9;

public class Video : Media
{
    public String Format { get; set; }
    public int Length { get; set; }
    public String Regions { get; set; }

    public override void Display()
    {
        List<string> Id = new List<string>();
        List<string> Title = new List<string>();
        List<string> Format = new List<string>();
        List<string> Length = new List<string>();
        List<string> Regions = new List<string>();
        String filename = "videos.csv";
        StreamReader sr = new StreamReader(filename);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
            Format.Add(movies[2]);
            Length.Add(movies[3]);
            Regions.Add(movies[4]);
        }
        sr.Close();

        for (int i = 0; i < Id.Count; i++)
        {
            Console.WriteLine($"Id: {Id[i]}");
            Console.WriteLine($"Title: {Title[i]}");
            Console.WriteLine($"Format: {Format[i]}");
            Console.WriteLine($"Length: {Length[i]}");
            Console.WriteLine($"Region(s): {Regions[i]}");
            Console.WriteLine();
        }
    }
}

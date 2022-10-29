using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Schema;

namespace Assignment9;

    public abstract class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }

    public static void Search(String searchValue)
    {
        List<string> Id = new List<string>();
        List<string> Title = new List<string>();
        String filename1 = "movies.csv";
        String filename2 = "shows.csv";
        String filename3 = "videos.csv";
        StreamReader sr = new StreamReader(filename1);
        sr.ReadLine();
        while (!sr.EndOfStream)
        {
            string line = sr.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
        }
        StreamReader sr2 = new StreamReader(filename2);
        sr2.ReadLine();
        while (!sr2.EndOfStream)
        {
            string line = sr2.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
        }
        StreamReader sr3 = new StreamReader(filename3);
        sr3.ReadLine();
        while (!sr3.EndOfStream)
        {
            string line = sr3.ReadLine();
            int idx = line.IndexOf('"');
            string[] movies = line.Split(',');
            Id.Add(movies[0]);
            Title.Add(movies[1]);
        }
        int i = 0;

        foreach (string t in Title)
        {
            if (t.Contains(searchValue))
            {
                Console.WriteLine(t);
                i++;
            }
        }
        Console.WriteLine("There were " + i + " titles that matched the search");
    }

    public abstract void Display();
}

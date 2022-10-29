using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace Assignment9;

public class Program
{

    private static void Main(string[] args)
    {
        string exit = "false";
        do
        {
            Console.WriteLine("Media Type (X to exit)");
            Console.WriteLine("1) Movie");
            Console.WriteLine("2) Show");
            Console.WriteLine("3) Video");
            Console.WriteLine("4) Search for media");
            String input = Console.ReadLine();

            String filename1 = "movies.csv";
            String filename2 = "shows.csv";
            String filename3 = "videos.csv";
            List<Int32> list1 = new List<Int32>();
            List<Int32> list2 = new List<Int32>();
            List<Int32> list3 = new List<Int32>();

            StreamReader sr = new StreamReader(filename1);
            sr.ReadLine();
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                int idx = line.IndexOf('"');
                string[] ids = line.Split(',');
                list1.Add(int.Parse(ids[0]));
            }
            sr.Close();

            StreamReader sr2 = new StreamReader(filename2);
            sr2.ReadLine();
            while (!sr2.EndOfStream)
            {
                string line = sr2.ReadLine();
                int idx = line.IndexOf('"');
                string[] ids = line.Split(',');
                list2.Add(int.Parse(ids[0]));
            }
            sr2.Close();

            StreamReader sr3 = new StreamReader(filename3);
            sr3.ReadLine();
            while (!sr3.EndOfStream)
            {
                string line = sr3.ReadLine();
                int idx = line.IndexOf('"');
                string[] ids = line.Split(',');
                list3.Add(int.Parse(ids[0]));
            }
            sr3.Close();

            if (input == "1")
            {
                Media media = new Movie();
                Console.WriteLine("1) Add Movie");
                Console.WriteLine("2) Display Movies");
                String input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    Console.WriteLine("Enter movie name");
                    string ans = Console.ReadLine();
                    media.Title = ans;

                    List<string> genres = new List<string>();
                    do
                    {
                        Console.WriteLine("Enter genre (or done to quit)");
                        ans = Console.ReadLine();
                        if (ans != "done" && ans.Length > 0)
                        {
                            genres.Add(ans);
                        }

                    } while (ans != "done");
                    string genresString = string.Join("|", genres);
                    ((Movie)media).Genres = genresString;

                    media.Id = list1.Max() + 1;


                    StreamWriter sw = new StreamWriter(filename1, true);
                    sw.WriteLine($"{media.Id},{media.Title},{((Movie)media).Genres}");
                    sw.Close();
                }
                else if (input2 == "2")
                {
                    ((Movie)media).Display();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }





            else if (input == "2")
            {
                Media media = new Show();
                Console.WriteLine("1) Add Show");
                Console.WriteLine("2) Display Shows");
                String input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    Console.WriteLine("Enter show title");
                    string ans = Console.ReadLine();
                    media.Title = ans;

                    Console.WriteLine("Enter show season");
                    int ans2 = Convert.ToInt32(Console.ReadLine());
                    ((Show)media).Season = ans2;

                    Console.WriteLine("Enter show episode");
                    int ans3 = Convert.ToInt32(Console.ReadLine());
                    ((Show)media).Episode = ans3;

                    List<string> writers = new List<string>();
                    do
                    {
                        Console.WriteLine("Enter genre (or done to quit)");
                        ans = Console.ReadLine();
                        if (ans != "done" && ans.Length > 0)
                        {
                            writers.Add(ans);
                        }

                    } while (ans != "done");
                    string genresString = string.Join("|", writers);
                    ((Show)media).Writers = genresString;

                    media.Id = list2.Max() + 1;

                    StreamWriter sw = new StreamWriter(filename2, true);
                    sw.WriteLine($"{media.Id},{media.Title},{((Show)media).Season},{((Show)media).Episode},{((Show)media).Writers}");
                    sw.Close();

                }
                else if (input2 == "2")
                {
                    ((Show)media).Display();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }




            else if (input == "3")
            {
                Media media = new Video();
                Console.WriteLine("1) Add Video");
                Console.WriteLine("2) Display Videos");
                String input2 = Console.ReadLine();
                if (input2 == "1")
                {
                    Console.WriteLine("Enter video title");
                    string ans = Console.ReadLine();
                    media.Title = ans;

                    Console.WriteLine("Enter video format");
                    string ans2 = Console.ReadLine();
                    ((Video)media).Format = ans2;

                    Console.WriteLine("Enter video length");
                    int ans3 = Convert.ToInt32(Console.ReadLine());
                    ((Video)media).Length = ans3;

                    List<string> regions = new List<string>();
                    do
                    {
                        Console.WriteLine("Enter region (or done to quit)");
                        ans = Console.ReadLine();
                        if (ans != "done" && ans.Length > 0)
                        {
                            regions.Add(ans);
                        }

                    } while (ans != "done");
                    string regionsString = string.Join("|", regions);
                    ((Video)media).Regions = regionsString;

                    media.Id = list3.Max() + 1;

                    StreamWriter sw = new StreamWriter(filename3, true);
                    sw.WriteLine($"{media.Id},{media.Title},{((Video)media).Format},{((Video)media).Length},{((Video)media).Regions}");
                    sw.Close();
                }
                else if (input2 == "2")
                {
                    ((Video)media).Display();
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            else if (input == "4")
            {
                Console.WriteLine("Enter media title");
                String searchValue = Console.ReadLine();
                Media.Search(searchValue);

            }

            else if (input == "X")
            {
                exit = "true";
            }




            else
            {
                Console.WriteLine("Invalid Input");
            }

        } while (exit == "false");
      
    }
}
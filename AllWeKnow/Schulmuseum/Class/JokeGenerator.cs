using System;
using System.IO;

namespace Schulmuseum;

public static class JokeGenerator
{
    public static string GetJoke()
    {
        try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("wwwroot/resources/loading/loadingjokes.txt"))
            {
                int count = 0;
                List<string> lines = new List<string>();
                Random r = new Random();  
                
                while (sr.ReadLine() is { } line)
                {
                    count++;
                    lines.Add(line);
                }
                return lines[r.Next(0, count)];
            }
        }
        catch (IOException e)
        {
            return e.Message;
        }
    }

    public static string GetShortJoke()
    {
        try
        {
            // Open the text file using a stream reader.
            using (var sr = new StreamReader("wwwroot/resources/loading/loadingjokesshort.txt"))
            {
                int count = 0;
                List<string> lines = new List<string>();
                Random r = new Random();  
                
                while (sr.ReadLine() is { } line)
                {
                    count++;
                    lines.Add(line);
                }
                return lines[r.Next(0, count)];
            }
        }
        catch (IOException e)
        {
            return e.Message;
        }
    }
}
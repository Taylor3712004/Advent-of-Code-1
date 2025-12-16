using System;
using System.IO;

class Program
{
    static int Mod(int a, int m) => ((a % m) + m) % m;

    static void Main()
    {
        int pos = 50;
        int hitsZero = 0;

        foreach (var raw in File.ReadLines("input.txt"))
        {
            var line = raw.Trim();
            if (line.Length == 0) continue;

            char dir = line[0];
            int dist = int.Parse(line.Substring(1));

            if (dir == 'L') pos = Mod(pos - dist, 100);
            else if (dir == 'R') pos = Mod(pos + dist, 100);
            else throw new Exception($"Bad rotation: {line}");

            if (pos == 0) hitsZero++;
        }

        Console.WriteLine(hitsZero);
    }
}

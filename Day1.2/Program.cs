using System;
using System.IO;

class Program
{
    static long Mod(long a, long m) => ((a % m) + m) % m;

    static void Main(string[] args)
    {
        string path = args.Length > 0 ? args[0] : "input.txt";
        if (!File.Exists(path))
        {
            Console.WriteLine($"Can't find '{path}'. Put input.txt next to the .csproj or pass a full path.");
            return;
        }

        long pos = 50;      // dial position 0..99
        long hitsZero = 0;  // count of clicks that land on 0

        foreach (var raw in File.ReadLines(path))
        {
            var line = raw.Trim();
            if (line.Length == 0) continue;

            char dir = line[0];
            long dist = long.Parse(line.Substring(1));

            long step = dir == 'R' ? 1 : dir == 'L' ? -1 : throw new Exception($"Bad rotation: {line}");

            // Find which click counts as landing on 0 (mod 100)
            // Right: k ≡ (100 - pos) mod 100
            // Left : k ≡ pos mod 100
            long r = step == 1 ? Mod(100 - pos, 100) : Mod(pos, 100);

            // Smallest k >= 1 such that k ≡ r (mod 100)
            long first = (r == 0) ? 100 : r;

            if (first <= dist)
            {
                hitsZero += 1 + (dist - first) / 100;
            }

            // Update dial position after full rotation
            pos = Mod(pos + step * dist, 100);
        }

        Console.WriteLine(hitsZero);
    }
}

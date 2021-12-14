using System;
using System.IO;
using System.Text.RegularExpressions;

namespace com.fabioscagliola.AdventOfCode202102
{
    class Program
    {
        static void Main()
        {
            Regex regex = new Regex(@"(down|forward|up)\s+(\d+)");
            MatchCollection matchCollection = regex.Matches(File.ReadAllText("Input1.txt"));

            // PART 1 
            {
                int horizontalPosition = 0;
                int depth = 0;
                foreach (Match match in matchCollection)
                {
                    string command = match.Groups[1].Value;
                    int units = int.Parse(match.Groups[2].Value);
                    switch (command)
                    {
                        case "down":
                            depth += units;
                            break;
                        case "forward":
                            horizontalPosition += units;
                            break;
                        case "up":
                            depth -= units;
                            break;
                    }
                }
                Console.WriteLine($"If you multiply your final horizontal position ({horizontalPosition}) by your final depth ({depth}) you get {horizontalPosition * depth}");
            }

            // PART 2 
            {
                int horizontalPosition = 0;
                int depth = 0;
                int aim = 0;
                foreach (Match match in matchCollection)
                {
                    string command = match.Groups[1].Value;
                    int units = int.Parse(match.Groups[2].Value);
                    switch (command)
                    {
                        case "down":
                            aim += units;
                            break;
                        case "forward":
                            horizontalPosition += units;
                            depth += units * aim;
                            break;
                        case "up":
                            aim -= units;
                            break;
                    }
                }
                Console.WriteLine($"If you multiply your final horizontal position ({horizontalPosition}) by your final depth ({depth}) you get {horizontalPosition * depth}");
            }
        }

    }
}


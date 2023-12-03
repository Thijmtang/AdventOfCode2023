﻿// See https://aka.ms/new-console-template for more information


using System.Runtime.CompilerServices;
using AdventOfCode;
using AdventOfCode2023.Utils;


public partial class Program
{
    public static void Main()
    {
        // Day 1
        // day1();

        day2_p2();

    }

    public static void day1()
    {
        var file = FileUtils.ReadPuzzleFile(1);
        Console.WriteLine(AdventOfcode.sumCalibrationValues(file));
    }

    public static void day2_p1()
    {
        var file = FileUtils.ReadPuzzleFile(2);
        int sum = AdventOfcode.sumPossibleBagGaneIds(file, new() {
            {"red", 12},
            {"green", 13},
            {"blue", 14}
        });

        Console.WriteLine(sum);
    }

    public static void day2_p2()
    {
        var file = FileUtils.ReadPuzzleFile(2);

        int sum = AdventOfcode.getLowestNumberOfCubes(file, new() {
            {"red", 12},
            {"green", 13},
            {"blue", 14}
        });

        Console.WriteLine(sum);
    }
}
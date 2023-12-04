// See https://aka.ms/new-console-template for more information


using AdventOfCode;
using AdventOfCode2023.Utils;


public partial class Program
{
    public static void Main()
    {

        // Day 1
        // day1_p1();
        // day1_p2();

        // Day 2
        // day2_p1();
        // day2_p2();

        // Day 3

        // Day 4
        // day4_p1();
        day4_p2();
    }



    public static void day1_p1()
    {
        var file = FileUtils.ReadPuzzleFile(1);
        var output = AdventOfcode.sumCalibrationValues(file);
        Console.WriteLine(output);

    }

    public static void day1_p2()
    {
        var file = FileUtils.ReadPuzzleFile(1);
        var output = AdventOfcode.sumCalibrationValues(file, true);
        Console.WriteLine(output);

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

    public static void day3_p1()
    {
        var file = FileUtils.ReadPuzzleFile(3);
        // var result = AdventOfCode.

    }


    public static void day4_p1()
    {
        var file = FileUtils.ReadPuzzleFile(4);
        var output = AdventOfcode.countScratchCardsPoints(file);

        Console.WriteLine(output);
    }


    public static void day4_p2()
    {
        var file = FileUtils.ReadPuzzleFile(4);
        var output = AdventOfcode.countWonScratchCards(file);

        Console.WriteLine(output);
    }
}
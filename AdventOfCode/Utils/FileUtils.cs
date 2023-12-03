namespace AdventOfCode2023.Utils;

public static class FileUtils
{
    public static List<string> ReadPuzzleFile(int day)
    {
        var result = new List<string>();
        var ds = Path.DirectorySeparatorChar;
        var filePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName + ds +
                       "AdventOfCode" + ds;


        var path = filePath + ds + "PuzzleInput" +
                   ds + "day-" + day;


        try
        {
            var sr = new StreamReader(path);

            var line = sr.ReadLine();
            //Continue to read until you reach end of file
            while (line != null)
            {
                //write the line to console window
                result.Add(line);
                //Read the next line
                line = sr.ReadLine();
            }

            //close the file
            sr.Close();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }


        return result;
    }
}
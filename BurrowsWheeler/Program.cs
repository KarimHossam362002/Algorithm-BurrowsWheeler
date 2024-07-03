using BurrowsWheeler;
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;

public class Program
{
    public static void Main()
    {
        Console.WriteLine("Please select a text file:");
        string filePath = GetFilePathFromUser();

        if (!string.IsNullOrEmpty(filePath))
        {
            try
            {
                string fileContent = File.ReadAllText(filePath);

                Console.WriteLine("File Content:");
                Console.WriteLine(fileContent);

               
                ProcessFileContent(fileContent);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error reading file: " + ex.Message);
            }
        }
        else
        {
            Console.WriteLine("No file selected.");
        }
    }

    public static string GetFilePathFromUser()
    {
        string filePath = Console.ReadLine().Trim();
        while (!File.Exists(filePath) || Path.GetExtension(filePath).ToLower() != ".txt")
        {
            Console.WriteLine("Invalid file path or not a text file. Please enter a valid text file path:");
            filePath = Console.ReadLine().Trim();
        }
        return filePath;
    }

    public static void ProcessFileContent(string input)
    {
        Stopwatch stopwatch = Stopwatch.StartNew();
        /*The logic of the whole project goes from here as the input is the content of the textFile chosen for our main function*/
        string bwtEncoded = BWT.Encode(input);
        /*string bwtDecoded = BWT.Decode(input ,);*/
        /*string mtfEncoded = MTF.Encode(input);*/
        /*string mtfDecoded = MTF.Decode(input);*/
        stopwatch.Stop();
        /*string bwtDecoded = BWT.Decode(input);*/
        Console.WriteLine("The BWT string is : " + bwtEncoded);
        Console.WriteLine("choose path to save the encoded bwt in a binary file");
        string newFilePath = GetFilePathFromUser();
        SaveToBinaryFile.SaveToBinary(bwtEncoded, newFilePath);
     /*display the time*/
        TimeSpan elapsedTime = stopwatch.Elapsed;
        double seconds = elapsedTime.TotalSeconds;

        Console.WriteLine($"BWT Encoding Execution Time: {seconds} seconds");
        /*Console.WriteLine("The Original String is : " + bwtDecoded);*/
    }
}


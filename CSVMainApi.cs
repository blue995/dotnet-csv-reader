using System;
using System.Collections.Generic;


namespace CSVUtils
{
    public class CSVMainApi
    {
        public static ICollection<Dictionary<string, string>> GetDataTuples(string csvPath, char valueDelimiter)
        {
            // Read CSV
            var csvReader = new CSVReader(csvPath, valueDelimiter);

            // Analyze content of CSV file
            var analyzer = new CSVDataAnalyzer(csvReader);
            var result = analyzer.Analyze();

            // Convert analyzed result to tuples (Should be used for testinput)
            var testDataTuples = result.ConvertToDataTuples();

            return testDataTuples;
        }

        public static void PrintDataTuples(string csvPath, char valueDelimiter)
        {
            var dataTuples = GetDataTuples(csvPath, valueDelimiter);
            foreach(var dataTuple in dataTuples)
            {
                Console.WriteLine("###");
                foreach(var kvTuple in dataTuple)
                {
                    var key = kvTuple.Key;
                    var value = kvTuple.Value;
                    Console.WriteLine($"Key:{key} - Value:{value}");
                }
                Console.WriteLine("######");
            }
        }
    }
}
using System;
using System.Linq;

namespace CSVUtils
{
    public class CSVDataAnalyzer
    {
        private CSVReader myReader;

        public CSVDataAnalyzer(CSVReader reader)
        {
            myReader = reader;
        }

        public CSVDataAnalyzerResult Analyze()
        {
            var lines = myReader.ReadLines().Where(line => !line.IsEmpty()).ToList();
            var firstLine = lines.First();
            lines.Remove(firstLine);
            var columnNames = firstLine.Values();
            var result = new CSVDataAnalyzerResult(columnNames);
            foreach(var line in lines)
            {
                result.Add(line);
            }
            return result;
        }
        public void PrintResult()
        {
            var results = Analyze();
            Console.WriteLine(results);
        }
    }
}
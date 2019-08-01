using System.IO;
using System.Collections.Generic;


namespace CSVUtils
{
    public class CSVReader
    {
        private string myPath;
        private char myDelimiter;

        public CSVReader(string path, char valueDelimiter = ';')
        {
            myPath = path;
            myDelimiter = valueDelimiter;
        }

        public List<CSVLine> ReadLines()
        {
            var result = new List<CSVLine>();
            using (var reader = new StreamReader(myPath))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(myDelimiter);
                    var currentLine = new CSVLine();
                    currentLine.AddAll(values);
                    result.Add(currentLine);
                }
            }
            return result;
        }
    }
}
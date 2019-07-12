using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace CSVUtils
{
    public class CSVDataAnalyzerResult
    {
        private ICollection<string> myValueNames;
        private ICollection<CSVLine> myLines;
        private int myColumnCount;

        public CSVDataAnalyzerResult(ICollection<string> valueNames)
        {
            myValueNames = new ReadOnlyCollection<string>(valueNames.ToList());
            myColumnCount = myValueNames.Count;
            myLines = new List<CSVLine>();
        }

        public void Add(CSVLine line)
        {
            var columnCount = line.Values().Count;
            if (columnCount  != myColumnCount)
            {
                throw new ArgumentException($"Column count {columnCount} does not match expected column count of {myColumnCount}");
            }
            myLines.Add(line);
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            foreach (var line in myLines)
            {
                for (int i = 0; i < myColumnCount; i++)
                {
                    var valueName = myValueNames.ElementAt(i);
                    var value = line.ElementAt(i);
                    builder.Append($"{valueName}={value}; ");
                }
                builder.AppendLine();
            }
            return builder.ToString();
        }

        public ICollection<Dictionary<string, string>> ConvertToDataTuples()
        {
            var result = new List<Dictionary<string, string>>();
            foreach (var line in myLines)
            {
                var tuple = new Dictionary<string, string>();
                var values = line.Values();
                var valueCount = values.Count;
                for (int i = 0; i < valueCount; i++)
                {
                    var currentValue = line.ElementAt(i);
                    var currentValueName = myValueNames.ElementAt(i);
                    tuple.Add(currentValueName, currentValue);
                }
                result.Add(tuple);                
            }
            return result;
        }
    }
}
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;


namespace CSVUtils
{
    public class CSVLine
    {
        private ICollection<string> myValues;
        

        public CSVLine()
        {
            myValues = new List<string>();
        }

        public void Add(string value)
        {
            value = Convert(value);
            myValues.Add(value);
        }

        public void AddAll(params string[] values)
        {
            foreach(var value in values)
            {
                Add(value);
            }
        }

        public string ElementAt(int index)
        {
            return myValues.ElementAt(index);
        }

        public ICollection<string> Values()
        {
            return new ReadOnlyCollection<string>(myValues.ToList());
        }

        public bool IsEmpty()
        {
            return myValues.All(value => !value.Any());
        }

        private string Convert(string value)
        {
            // Remove escaped '"' characters
            value = value.Replace("\\\"", "\"");

            // Remove enclosing '"' characters
            var regexExpression = "^\"([^\\r]*)\"$";
            var match = Regex.Match(value, regexExpression, RegexOptions.Compiled);
            if (match.Success)
            {
                var newValue = match.Groups[1].Value;
                newValue = DeepMatchRecursively(newValue, regexExpression);
                return newValue.Replace("\"\"", "\"");
            }

            // If it is a bool value, return the bool string
            if (BoolParser.IsBool(value))
            {
                return BoolParser.GetValue(value).ToString();
            }
            return value;
        }

        private string DeepMatchRecursively(string value, string regex)
        {
            var match = Regex.Match(value, regex);
            if (!match.Success)
            {
                return value;
            }
            value = match.Groups[1].Value;
            return DeepMatchRecursively(value, regex);
        }
    }
}

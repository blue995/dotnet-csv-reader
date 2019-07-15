using System;
using System.Linq;

namespace CSVUtils
{
    /// <summary>
    /// Parse strings into true or false bools using relaxed parsing rules
    /// </summary>
    public static class BoolParser
    {
        public static bool IsBool(string value)
        {
            var valueAsPossibleBoolString = GetBoolValueAsString(value);
            return Boolean.TryParse(valueAsPossibleBoolString, out bool result);
        }

        /// <summary>
        /// Get the boolean value for this string
        /// </summary>
        public static bool GetValue(string value)
        {
            var valueAsPossibleBoolString = GetBoolValueAsString(value);
            return Boolean.Parse(valueAsPossibleBoolString);
        }

        private static string GetBoolValueAsString(string value)
        {
            var originalValue = value;
            try
            {
                // 1
                // Avoid exceptions
                if (value == null)
                {
                    return Boolean.FalseString;
                }

                // 2
                // Remove whitespace from string
                value = value.Trim();

                // 3
                // Lowercase the string
                value = value.ToLower();

                // 4.1
                // Check for word true
                if (value == Boolean.TrueString)
                {
                    return Boolean.TrueString;
                }
                // 4.2
                // Check for word false
                if (value == Boolean.FalseString)
                {
                    return Boolean.FalseString;
                }

                // 5.1
                // Check for letter true
                if (value == "t")
                {
                    return Boolean.TrueString;
                }
                // 5.2
                // Check for letter false
                if (value == "f")
                {
                    return Boolean.FalseString;
                }

                // 6.1
                // Check for one
                if (value == "1")
                {
                    return Boolean.TrueString;
                }
                // 6.2
                // Check for zero
                if (value == "0")
                {
                    return Boolean.FalseString;
                }

                // 7.1
                // Check for word yes
                if (value == "yes")
                {
                    return Boolean.TrueString;
                }
                // 7.2
                // Check for word yes
                if (value == "no")
                {
                    return Boolean.FalseString;
                }

                // 8.1
                // Check for letter yes
                if (value == "y")
                {
                    return Boolean.TrueString;
                }
                // 8.2
                // Check for letter yes
                if (value == "n")
                {
                    return Boolean.FalseString;
                }

                // 9
                // It is value
                return originalValue;
            }
            catch
            {
                return originalValue;
            }

        }
    }
}
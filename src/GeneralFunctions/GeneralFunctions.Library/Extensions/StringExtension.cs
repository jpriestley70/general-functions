using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

#nullable enable

namespace GeneralFunctions.Library.Extensions
{
    public static class StringExtension
    {
        #region Check Strings
        /// <summary>
        /// Is the string null, empty or just contains white spaces?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsEmpty(this string? value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Return a default value if the string is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static string DefaultIfNullOrEmpty(this string? value, string defaultValue)
        {
            if (value.IsEmpty()) { return defaultValue; }

            // Compiler says possible null value returned so we check again and return default value
            return value ?? defaultValue;
        }

        /// <summary>
        /// Return number of times a text sequence is in a string
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static int CountOf(this string? text, string pattern)
        {
            if (text.IsEmpty()) { return 0; }
            if (pattern.IsEmpty()) { return 0; }

            // To keep the compiler from complaining "text may be nullable" even though IsEmpty checks for null
            if (text is null) { return 0; }

            int count = 0;
            int index = -1;
            bool found = true;
            
            try
            {
                while (found == true)
                {
                    found = false;
                    if ((index + 1) >= text.Length) { break; }

                    int newIndex = text.IndexOf(pattern, index + 1, StringComparison.InvariantCultureIgnoreCase);
                    if (newIndex > index)
                    {
                        found = true;
                        index = newIndex;
                        count++;
                    }
                }
            }
            catch
            {
                // In case index is greater than string length
            }

            return count;
        }

        /// <summary>
        /// Checks the value to see if matches one of the items in the array
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool IsOneOf(this string? value, params string[]? values)
        {
            if (values is null) { return false; }
            if (value is null) { return false; }

            return values.Any(e => e.Equals(value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        public static bool ContainsOneOf(this string? value, params string[]? values)
        {
            if (values is null) { return false; }
            if (value is null) { return false; }

            foreach (string compare in values)
            {
                if (value.Contains(compare)) { return true; }
            }

            return false;
        }

        /// <summary>
        /// Compare to strings to see if they are equal
        /// If both strings are NULL, returns true
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compareTo"></param>
        /// <returns></returns>
        public static bool EqualsInvariant(this string? value, string? compareTo)
        {
            if (value is null || compareTo is null) { return false; }

            return value.Equals(compareTo, StringComparison.InvariantCultureIgnoreCase);
        }
        #endregion

        #region Comparisions
        /// <summary>
        /// Is the string a boolean?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBoolean(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return bool.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a byte?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsByte(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return byte.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a DateTime?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDateTime(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return DateTime.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a decimal?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDecimal(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return decimal.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a double?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDouble(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return double.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a float?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsFloat(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return float.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a Guid?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsGuid(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return Guid.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string an integer?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return int.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a long?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsLong(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return long.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a short?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsShort(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return short.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string a signed byte?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsSByte(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return SByte.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string an unsigned integer?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUInteger(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return uint.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string an unsigned long?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsULong(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return ulong.TryParse(value, out _);
        }

        /// <summary>
        /// Is the string an unsigned short?
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsUShort(this string? value)
        {
            if (value is null) { return false; }
            if (value.IsEmpty()) { return false; }

            return ushort.TryParse(value, out _);
        }
        #endregion

        #region Convert String to another type
        /// <summary>
        /// Convert string to Boolean
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns True/False. If string is not boolean the result will be false.</returns>
        public static bool ToBoolean(this string? value)
        {
            if (bool.TryParse(value, out bool v) == false) { return false; }
            return v;
        }

        /// <summary>
        /// Convert string to Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns byte value. If string is not a byte the result will be 0.</returns>
        public static byte ToByte(this string? value)
        {
            if (byte.TryParse(value, out byte v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Signed Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns signed byte value. If string is not a signed byte the result will be 0.</returns>
        public static sbyte ToSByte(this string? value)
        {
            if (sbyte.TryParse(value, out sbyte v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns DateTime value. If string is not DateTime the result will be today's date.</returns>
        public static DateTime ToDateTime(this string? value)
        {
            if (DateTime.TryParse(value, out DateTime v) == false) { return DateTime.Today; }
            return v;
        }

        /// <summary>
        /// Convert string to DateTime
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns DateTime value. If string is not DateTime the result will be null.</returns>
        public static DateTime? ToDateTimeOrNull(this string? value)
        {
            if (DateTime.TryParse(value, out DateTime v) == false) { return null; }
            return v;
        }

        /// <summary>
        /// Convert string to Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns decimal value. If string is not a decimal the result will be 0.</returns>
        public static decimal ToDecimal(this string? value)
        {
            if (decimal.TryParse(value, out decimal v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Double
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns double value. If string is not a double the result will be 0.</returns>
        public static double ToDouble(this string? value)
        {
            if (double.TryParse(value, out double v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Float
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns double value. If string is not a double the result will be 0.</returns>
        public static float ToFloat(this string? value)
        {
            if (float.TryParse(value, out float v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Guid
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns Guid value. If string is not a Guid the result will be Guid empty value.</returns>
        public static Guid ToGuid(this string? value)
        {
            if (Guid.TryParse(value, out Guid v) == false) { return Guid.Empty; }
            return v;
        }

        /// <summary>
        /// Convert string to Integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns integer value. If string is not a integer the result will be 0.</returns>
        public static int ToInteger(this string? value)
        {
            if (int.TryParse(value, out int v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Unsigned Integer
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns unsigned integer value. If string is not an unsigned integer the result will be 0.</returns>
        public static uint ToUInteger(this string? value)
        {
            if (uint.TryParse(value, out uint v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Long
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns long value. If string is not a long the result will be 0.</returns>
        public static long ToLong(this string? value)
        {
            if (long.TryParse(value, out long v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Unsigned Long
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns unsigned long value. If string is not an unsigned long the result will be 0.</returns>
        public static ulong ToULong(this string? value)
        {
            if (ulong.TryParse(value, out ulong v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Short
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns short value. If string is not a short the result will be 0.</returns>
        public static short ToShort(this string? value)
        {
            if (short.TryParse(value, out short v) == false) { return 0; }
            return v;
        }

        /// <summary>
        /// Convert string to Unsigned Short
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Returns unsigned short value. If string is not an unsigned short the result will be 0.</returns>
        public static ushort ToUShort(this string? value)
        {
            if (ushort.TryParse(value, out ushort v) == false) { return 0; }
            return v;
        }
        #endregion

        #region Manipulate Strings
        /// <summary>
        /// Split the string into a list
        /// </summary>
        /// <param name="value"></param>
        /// <param name="removeEmptyLines"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetLines(this string? value, bool removeEmptyLines = false)
        {
            if (value != null)
            {
                using (var reader = new StringReader(value))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (removeEmptyLines && line.IsEmpty()) { continue; }
                        yield return line;
                    }
                }
            }
        }

        /// <summary>
        /// Truncate string to a specific length
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">Maximum number of characters</param>
        /// <returns></returns>
        public static string? Truncate(this string? value, int length)
        {
            if (value is null) { return null; }

            if (length < 1) { length = 1; }

            if (value.Length > length)
            {
                return value.Substring(0, length).Trim();
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Shorten string
        /// </summary>
        /// <param name="value"></param>
        /// <param name="length">Maximum number of characters</param>
        /// <param name="ellipse">Default is ...</param>
        /// <returns></returns>
        public static string? Shorten(this string? value, int length, string ellipse = "...")
        {
            if (value is null) { return null; }

            if (length < 1) { length = 1; }

            if (value.Length > length)
            {
                return $"{value.Substring(0, length).Trim()}{ellipse}";
            }
            else
            {
                return value;
            }
        }

        /// <summary>
        /// Concatenate string array into a string
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator">Include a separator</param>
        /// <returns></returns>
        public static string ConcatenateString(this string[] values, string separator = "")
        {
            StringBuilder sb = new StringBuilder();
            bool hasData = false;

            foreach (string value in values)
            {
                if (hasData) { if (!separator.IsEmpty()) { sb.Append(separator); } }
                sb.Append(value);
                hasData = true;
            }

            return sb.ToString();
        }

        /// <summary>
        /// Concatenate string list into a string
        /// </summary>
        /// <param name="values"></param>
        /// <param name="separator">Include a separator</param>
        /// <returns></returns>
        public static string ConcatenateString(this List<string>? values, string separator = "")
        {
            if (values is null) { return string.Empty; }
            return values.ToArray().ConcatenateString(separator);
        }
        #endregion
    }
}

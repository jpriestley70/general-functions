using System;
using System.Collections.Generic;
using System.Text;
using GeneralFunctions.Library.Extensions;
using Xunit;

#nullable enable

namespace GeneralFunctions.XUnitTests
{
    public class StringComparisonUnitTest
    {
        /// <summary>
        /// Check the string to see if the value is boolean (True/False)
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("true", true)]
        [InlineData("false", true)]
        [InlineData("True", true)]
        [InlineData("False", true)]
        [InlineData("TRUE", true)]
        [InlineData("FALSE", true)]
        [InlineData("yes", false)]
        [InlineData("no", false)]
        [InlineData("on", false)]
        [InlineData("off", false)]
        [InlineData("0", false)]
        [InlineData("1", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsBoolean(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsBoolean());
        }

        /// <summary>
        /// Check the string to see if the value is a byte 0 - 255
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", true)]     // Min Value
        [InlineData("255", true)]   // Max Value
        [InlineData("-1", false)]   // Min Value - 1
        [InlineData("256", false)]  // Max Value + 1
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsByte(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsByte());
        }

        /// <summary>
        /// Check the string to see if the value is a DateTime.
        /// Results depends on locale.
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("31/01/2020", true)]    // en-GB, fr-FR, es-ES
        [InlineData("31.01.2020", true)]    // de-DE , pl-PL
        [InlineData("31-01-2020", true)]
        [InlineData("01/31/2020", false)]   // en-US - fails because locale is en-GB
        [InlineData("01-31-2020", false)]
        [InlineData("2020-01-31", true)]
        [InlineData("2020-01-31T23:59:59Z", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsDateTime(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsDateTime());
        }

        /// <summary>
        /// Check the string to see if the value is a decimal
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-79228162514264337593543950335", true)]    // Min Value
        [InlineData("79228162514264337593543950335", true)]     // Max Value
        [InlineData("-79228162514264337593543950336", false)]    // Min Value - 1
        [InlineData("79228162514264337593543950336", false)]     // Max Value + 1
        [InlineData("0.1234567890123456789012345678", true)]
        [InlineData("-0.1234567890123456789012345678", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsDecimal(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsDecimal());
        }

        /// <summary>
        /// Check the string to see if the value is a double
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-1.7976931348623157E+308", true)]  // Min Value
        [InlineData("1.7976931348623157E+308", true)]   // Max Value
        [InlineData("-2E+308", true)]                   // Negative Infinity
        [InlineData("2E+308", true)]                    // Positive Infinity
        [InlineData("0.5", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsDouble(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsDouble());
        }

        /// <summary>
        /// Check the string to see if the value is a float
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-3.40282347E+38", true)]   // Min Value
        [InlineData("3.40282347E+38", true)]    // Max Value
        [InlineData("-4E+38", true)]            // Negative Infinity
        [InlineData("4E+38", true)]             // Positive Infinity
        [InlineData("0.5", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsFloat(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsFloat());
        }

        /// <summary>
        /// Check the string to see if it the value is a Guid
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("49808961-4BC7-41AD-A8A5-AE8C3C74C9DE", true)]
        [InlineData("{49808961-4BC7-41AD-A8A5-AE8C3C74C9DE}", true)]
        [InlineData("498089614BC741ADA8A5AE8C3C74C9DE", true)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsGuid(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsGuid());
        }

        /// <summary>
        /// Check the string to see if it the value is an integer
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-2147483648", true)]   // Min Value
        [InlineData("2147483647", true)]    // Max Value
        [InlineData("-2147483649", false)]  // Min Value - 1
        [InlineData("2147483648", false)]   // Max Value + 1
        [InlineData("-2,147,483,648", false)]
        [InlineData("2,147,483,647", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsInteger(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsInteger());
        }

        /// <summary>
        /// Check the string to see if it the value is a long
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-9223372036854775808", true)]   // Min Value
        [InlineData("9223372036854775807", true)]    // Max Value
        [InlineData("-9223372036854775809", false)]  // Min Value - 1
        [InlineData("9223372036854775808", false)]   // Max Value + 1
        [InlineData("-9,223,372,036,854,775,808", false)]
        [InlineData("9,223,372,036,854,775,807", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsLong(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsLong());
        }

        /// <summary>
        /// Check the string to see if it the value is a short
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-32768", true)]   // Min Value
        [InlineData("32767", true)]    // Max Value
        [InlineData("-32769", false)]  // Min Value - 1
        [InlineData("32768", false)]   // Max Value + 1
        [InlineData("-32,768", false)]
        [InlineData("32,767", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsShort(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsShort());
        }

        /// <summary>
        /// Check the string to see if the value is a signed byte -128 - 127
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-128", true)]      // Min Value
        [InlineData("127", true)]       // Max Value
        [InlineData("-129", false)]     // Min Value - 1
        [InlineData("128", false)]      // Max Value + 1
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsSByte(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsSByte());
        }

        /// <summary>
        /// Check the string to see if it the value is an unsigned integer
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", true)]             // Min Value
        [InlineData("4294967295", true)]    // Max Value
        [InlineData("-1", false)]           // Min Value - 1
        [InlineData("4294967296", false)]   // Max Value + 1
        [InlineData("4,294,967,295", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsUInteger(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsUInteger());
        }

        /// <summary>
        /// Check the string to see if it the value is an unsigned long
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", true)]                     // Min Value
        [InlineData("18446744073709551615", true)]  // Max Value
        [InlineData("-1", false)]                   // Min Value - 1
        [InlineData("18446744073709551616", false)] // Max Value + 1
        [InlineData("18,446,744,073,709,551,615", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsULong(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsULong());
        }

        /// <summary>
        /// Check the string to see if it the value is an unsigned short
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", true)]         // Min Value
        [InlineData("65535", true)]     // Max Value
        [InlineData("-1", false)]       // Min Value - 1
        [InlineData("65536", false)]    // Max Value + 1
        [InlineData("65,535", false)]
        [InlineData("0.5", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringIsUShort(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsUShort());
        }
    }
}

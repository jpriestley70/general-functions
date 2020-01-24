using System;
using System.Collections.Generic;
using System.Text;
using GeneralFunctions.Library.Extensions;
using GeneralFunctions.XUnitTests.Models;
using Xunit;

#nullable enable

namespace GeneralFunctions.XUnitTests
{
    public class StringConversionUnitTest
    {
        /// <summary>
        /// Convert string to boolean
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("true", true)]
        [InlineData("false", false)]
        [InlineData("True", true)]
        [InlineData("False", false)]
        [InlineData("TRUE", true)]
        [InlineData("FALSE", false)]
        [InlineData("yes", false)]
        [InlineData("no", false)]
        [InlineData("on", false)]
        [InlineData("off", false)]
        [InlineData("0", false)]
        [InlineData("1", false)]
        [InlineData(null, false)]
        [InlineData("", false)]
        [InlineData("random text", false)]
        public void StringToBoolean(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.ToBoolean());
        }

        /// <summary>
        /// Convert string to byte
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", 0)]        // Min Value
        [InlineData("255", 255)]    // Max Value
        [InlineData("-1", 0)]       // Min Value - 1
        [InlineData("256", 0)]      // Max Value + 1
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToByte(string? actual, byte expected)
        {
            Assert.Equal(expected, actual.ToByte());
        }

        /// <summary>
        /// Convert string to signed byte
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-128", -128)]  // Min Value
        [InlineData("127", 127)]    // Max Value
        [InlineData("-129", 0)]     // Min Value - 1
        [InlineData("128", 0)]      // Max Value + 1
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToSByte(string? actual, sbyte expected)
        {
            Assert.Equal(expected, actual.ToSByte());
        }

        /// <summary>
        /// Convert string to DateTime or Today's date if invalid
        /// Results depends on locale.
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(DateTimeSampleData))]
        public void StringToDateTime(DateTimeModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToDateTime());
        }

        /// <summary>
        /// Convert string to DateTime or null if invalid
        /// Results depends on locale.
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(DateTimeNullSampleData))]
        public void StringToDateTimeOrNull(DateTimeModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToDateTimeOrNull());
        }

        /// <summary>
        /// Convert string to decimal
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(DecimalSampleData))]

        public void StringToDecimal(DecimalModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToDecimal());
        }

        /// <summary>
        /// Convert string to double
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(DoubleSampleData))]

        public void StringToDouble(DoubleModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToDouble());
        }

        /// <summary>
        /// Convert string to float
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(FloatSampleData))]

        public void StringToFloat(FloatModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToFloat());
        }

        /// <summary>
        /// Convert string to Guid
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(GuidSampleData))]

        public void StringToGuid(GuidModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToGuid());
        }

        /// <summary>
        /// Convert string to integer
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-2147483648", -2147483648)]  // Min Value
        [InlineData("2147483647", 2147483647)]    // Max Value
        [InlineData("-2147483649", 0)]     // Min Value - 1
        [InlineData("2147483648", 0)]      // Max Value + 1
        [InlineData("-2,147,483,648", 0)]
        [InlineData("2,147,483,647", 0)]
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToInteger(string? actual, int expected)
        {
            Assert.Equal(expected, actual.ToInteger());
        }

        /// <summary>
        /// Convert string to Long
        /// </summary>
        /// <param name="sampleData"></param>
        [Theory, MemberData(nameof(LongSampleData))]
        public void StringToLong(LongModel sampleData)
        {
            Assert.Equal(sampleData.Expected, sampleData.Actual.ToLong());
        }

        /// <summary>
        /// Convert string to short
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("-32768", -32768)]  // Min Value
        [InlineData("32767", 32767)]    // Max Value
        [InlineData("-32769", 0)]       // Min Value - 1
        [InlineData("32768", 0)]        // Max Value + 1
        [InlineData("-32,768", 0)]
        [InlineData("32,767", 0)]
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToShort(string? actual, short expected)
        {
            Assert.Equal(expected, actual.ToShort());
        }

        /// <summary>
        /// Convert string to unsigned integer
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", 0)]                    // Min Value
        [InlineData("4294967295", 4294967295)]  // Max Value
        [InlineData("-1", 0)]                   // Min Value - 1
        [InlineData("4294967296", 0)]           // Max Value + 1
        [InlineData("4,294,967,295", 0)]
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToUInteger(string? actual, uint expected)
        {
            Assert.Equal(expected, actual.ToUInteger());
        }

        /// <summary>
        /// Convert string to unsigned long
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", 0)]                                        // Min Value
        [InlineData("18446744073709551615", 18446744073709551615)]  // Max Value
        [InlineData("-1", 0)]                                       // Min Value - 1
        [InlineData("18446744073709551616", 0)]                     // Max Value + 1
        [InlineData("18,446,744,073,709,551,615", 0)]
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToULong(string? actual, ulong expected)
        {
            Assert.Equal(expected, actual.ToULong());
        }

        /// <summary>
        /// Convert string to unsigned short
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("0", 0)]            // Min Value
        [InlineData("65535", 65535)]    // Max Value
        [InlineData("-1", 0)]           // Min Value - 1
        [InlineData("65536", 0)]        // Max Value + 1
        [InlineData("65,535", 0)]
        [InlineData("0.5", 0)]
        [InlineData(null, 0)]
        [InlineData("", 0)]
        [InlineData("random text", 0)]
        public void StringToUShort(string? actual, ushort expected)
        {
            Assert.Equal(expected, actual.ToUShort());
        }

        #region Sample Data Lists
        /// <summary>
        /// ToDateTime()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> DateTimeSampleData()
        {
            yield return new[] { new DateTimeModel() { Actual = "31/01/2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "31.01.2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "31-01-2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "01/31/2020", Expected = DateTime.Today } };
            yield return new[] { new DateTimeModel() { Actual = "01-31-2020", Expected = DateTime.Today } };
            yield return new[] { new DateTimeModel() { Actual = "2020-01-31", Expected = new DateTime(2020, 01, 31).Date } };
            yield return new[] { new DateTimeModel() { Actual = "2020-01-31T23:59:59Z", Expected = new DateTime(2020, 01, 31, 23, 59, 59) } };
            yield return new[] { new DateTimeModel() { Actual = null, Expected = DateTime.Today } };
            yield return new[] { new DateTimeModel() { Actual = "", Expected = DateTime.Today } };
            yield return new[] { new DateTimeModel() { Actual = "random text", Expected = DateTime.Today } };
        }

        /// <summary>
        /// ToDateTimeOrNull()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> DateTimeNullSampleData()
        {
            yield return new[] { new DateTimeModel() { Actual = "31/01/2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "31.01.2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "31-01-2020", Expected = new DateTime(2020, 01, 31) } };
            yield return new[] { new DateTimeModel() { Actual = "01/31/2020", Expected = null } };
            yield return new[] { new DateTimeModel() { Actual = "01-31-2020", Expected = null } };
            yield return new[] { new DateTimeModel() { Actual = "2020-01-31", Expected = new DateTime(2020, 01, 31).Date } };
            yield return new[] { new DateTimeModel() { Actual = "2020-01-31T23:59:59Z", Expected = new DateTime(2020, 01, 31, 23, 59, 59) } };
            yield return new[] { new DateTimeModel() { Actual = null, Expected = null } };
            yield return new[] { new DateTimeModel() { Actual = "", Expected = null } };
            yield return new[] { new DateTimeModel() { Actual = "random text", Expected = null } };
        }

        /// <summary>
        /// ToDecimal()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> DecimalSampleData()
        {
            yield return new[] { new DecimalModel() { Actual = "-79228162514264337593543950335", Expected = -79228162514264337593543950335M } };
            yield return new[] { new DecimalModel() { Actual = "79228162514264337593543950335", Expected = 79228162514264337593543950335M } };
            yield return new[] { new DecimalModel() { Actual = "-79228162514264337593543950336", Expected = 0M } };
            yield return new[] { new DecimalModel() { Actual = "79228162514264337593543950336", Expected = 0M } };
            yield return new[] { new DecimalModel() { Actual = "0.1234567890123456789012345678", Expected = 0.1234567890123456789012345678M } };
            yield return new[] { new DecimalModel() { Actual = "-0.1234567890123456789012345678", Expected = -0.1234567890123456789012345678M } };
            yield return new[] { new DecimalModel() { Actual = null, Expected = 0M } };
            yield return new[] { new DecimalModel() { Actual = "", Expected = 0M } };
            yield return new[] { new DecimalModel() { Actual = "random text", Expected = 0M } };
        }

        /// <summary>
        /// ToDouble()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> DoubleSampleData()
        {
            yield return new[] { new DoubleModel() { Actual = "-1.7976931348623157E+308", Expected = -1.7976931348623157E+308D } };
            yield return new[] { new DoubleModel() { Actual = "1.7976931348623157E+308", Expected = 1.7976931348623157E+308D } };
            yield return new[] { new DoubleModel() { Actual = "0.5", Expected = 0.5D } };
            yield return new[] { new DoubleModel() { Actual = "-2E+308", Expected = double.NegativeInfinity } };
            yield return new[] { new DoubleModel() { Actual = "2E+308", Expected = double.PositiveInfinity } };
            yield return new[] { new DoubleModel() { Actual = null, Expected = 0D } };
            yield return new[] { new DoubleModel() { Actual = "", Expected = 0D } };
            yield return new[] { new DoubleModel() { Actual = "random text", Expected = 0D } };
        }

        /// <summary>
        /// ToFloat()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> FloatSampleData()
        {
            yield return new[] { new FloatModel() { Actual = "-3.40282347E+38", Expected = -3.40282347E+38F } };
            yield return new[] { new FloatModel() { Actual = "3.40282347E+38", Expected = 3.40282347E+38F } };
            yield return new[] { new FloatModel() { Actual = "0.5", Expected = 0.5F } };
            yield return new[] { new FloatModel() { Actual = "-4E+38", Expected = float.NegativeInfinity } };
            yield return new[] { new FloatModel() { Actual = "4E+38", Expected = float.PositiveInfinity } };
            yield return new[] { new FloatModel() { Actual = null, Expected = 0F } };
            yield return new[] { new FloatModel() { Actual = "", Expected = 0F } };
            yield return new[] { new FloatModel() { Actual = "random text", Expected = 0F } };
        }

        /// <summary>
        /// ToGuid()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> GuidSampleData()
        {
            yield return new[] { new GuidModel() { Actual = "49808961-4BC7-41AD-A8A5-AE8C3C74C9DE", Expected = new Guid("49808961-4BC7-41AD-A8A5-AE8C3C74C9DE") } };
            yield return new[] { new GuidModel() { Actual = "{49808961-4BC7-41AD-A8A5-AE8C3C74C9DE}", Expected = new Guid("{49808961-4BC7-41AD-A8A5-AE8C3C74C9DE}") } };
            yield return new[] { new GuidModel() { Actual = "498089614BC741ADA8A5AE8C3C74C9DE", Expected = new Guid("498089614BC741ADA8A5AE8C3C74C9DE") } };
            yield return new[] { new GuidModel() { Actual = null, Expected = Guid.Empty } };
            yield return new[] { new GuidModel() { Actual = "", Expected = Guid.Empty } };
            yield return new[] { new GuidModel() { Actual = "random text", Expected = Guid.Empty } };
        }

        /// <summary>
        /// ToLong()
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<object[]> LongSampleData()
        {
            yield return new[] { new LongModel() { Actual = "-9223372036854775808", Expected = -9223372036854775808L } };
            yield return new[] { new LongModel() { Actual = "9223372036854775807", Expected = 9223372036854775807L } };
            yield return new[] { new LongModel() { Actual = "-9223372036854775809", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "9223372036854775808", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "-9,223,372,036,854,775,808", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "9,223,372,036,854,775,807", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "0.5", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = null, Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "", Expected = 0L } };
            yield return new[] { new LongModel() { Actual = "random text", Expected = 0L } };
        }
        #endregion
    }
}

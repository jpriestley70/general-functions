using System;
using System.Collections.Generic;
using System.Text;
using GeneralFunctions.Library.Extensions;
using GeneralFunctions.XUnitTests.Models;
using Xunit;

#nullable enable

namespace GeneralFunctions.XUnitTests
{
    public class StringCheckingUnitTest
    {
        /// <summary>
        /// Test the string to see if is empty
        /// Empty is either blank, white space or null
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("", true)]
        [InlineData(" ", true)]
        [InlineData(null, true)]
        [InlineData("Something", false)]
        public void StringIsEmpty(string? actual, bool expected)
        {
            Assert.Equal(expected, actual.IsEmpty());
        }

        /// <summary>
        /// Test the string to see if it is empty and if so return a default value
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="defaultValue"></param>
        [Theory]
        [InlineData("", "", "")]
        [InlineData(null, "", "")]
        [InlineData("", "Beta", "Beta")]
        [InlineData(null, "Beta", "Beta")]
        [InlineData("Alpha", "Alpha", "Beta")]
        public void StringDefaultIfNullOrEmpty(string? actual, string expected, string defaultValue)
        {
            Assert.Equal(expected, actual.DefaultIfNullOrEmpty(defaultValue));
        }


        /// <summary>
        /// Count the number of times a pattern is within a string
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        /// <param name="pattern"></param>
        [Theory]
        [InlineData("abcdef", 1, "abc")]
        [InlineData("abcdefabc", 2, "abc")]
        [InlineData("ABCdefAbC", 2, "abc")]
        [InlineData("abcdefabc", 2, "ABC")]
        [InlineData("abcdef", 0, "")]
        [InlineData("", 0, "abc")]
        [InlineData(null, 0, "abc")]
        public void CountOfString(string? actual, int expected, string pattern)
        {
            Assert.Equal(expected, actual.CountOf(pattern));
        }

        /// <summary>
        /// Check to see if value is within a list of values
        /// </summary>
        /// <param name="model"></param>
        [Theory, MemberData(nameof(StringIsOneOfSampleData))]
        public void StringIsOneOf(StringOneOfModel model)
        {
            Assert.Equal(model.Expected, model.Actual.IsOneOf(model.Values));
        }

        /// <summary>
        /// Check to see if value is within a list of values
        /// </summary>
        /// <param name="model"></param>
        [Theory, MemberData(nameof(StringContainsOneOfSampleData))]
        public void StringContainsOneOf(StringOneOfModel model)
        {
            Assert.Equal(model.Expected, model.Actual.ContainsOneOf(model.Values));
        }

        /// <summary>
        /// Compare two strings using Invariant Culture Ignore Case
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="compareTo"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("Alpha","Alpha", true)]
        [InlineData("Beta", "beta", true)]
        [InlineData("Gamma", "gAMMA", true)]
        [InlineData("Delta", "dElTa", true)]
        [InlineData("", "", true)]
        [InlineData(null, "", false)]
        [InlineData("", null, false)]
        [InlineData(null, null, false)]
        public void StringEqualInvariant(string? actual, string? compareTo, bool expected)
        {
            Assert.Equal(expected, actual.EqualsInvariant(compareTo));
        }

        #region Sample Data
        public static IEnumerable<object[]> StringIsOneOfSampleData()
        {
            yield return new[] { new StringOneOfModel() { Actual = "Theta", Expected = true, Values = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lamda" } } };
            yield return new[] { new StringOneOfModel() { Actual = "Omega", Expected = false, Values = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lamda" } } };
        }

        public static IEnumerable<object[]> StringContainsOneOfSampleData()
        {
            yield return new[] { new StringOneOfModel() { Actual = "Omicron-Theta-Pi", Expected = true, Values = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lamda" } } };
            yield return new[] { new StringOneOfModel() { Actual = "Sigma-Omega-Tau", Expected = false, Values = new string[] { "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta", "Iota", "Kappa", "Lamda" } } };
        }
        #endregion
    }
}

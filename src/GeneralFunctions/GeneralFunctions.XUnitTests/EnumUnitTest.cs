using System;
using System.Collections.Generic;
using System.Text;
using GeneralFunctions.Library.Extensions;
using Xunit;

namespace GeneralFunctions.XUnitTests
{
    public class EnumUnitTest
    {
        public enum TestEnum
        {
            Alpha,
            Beta,
            Gamma,
            Delta,
            Epsilon
        }

        /// <summary>
        /// Test to see if the text is part of the enum
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("Alpha", true)]
        [InlineData("Beta", true)]
        [InlineData("Gamma", true)]
        [InlineData("Delta", true)]
        [InlineData("Epsilon", true)]
        [InlineData("Zeta", false)]     // Don't Exist
        [InlineData("Eta", false)]
        [InlineData("Theta", false)]
        [InlineData("alpha", true)]     // Different cAsE
        [InlineData("bEtA", true)]
        [InlineData("GAMMA", true)]
        [InlineData("dELTA", true)]
        public void EnumContainsTestEnum(string actual, bool expected)
        {
            Assert.Equal(expected, actual.EnumContains<TestEnum>());
        }

        /// <summary>
        /// Convert string to enum value
        /// </summary>
        /// <param name="actual"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData("Alpha", TestEnum.Alpha)]
        [InlineData("Beta", TestEnum.Beta)]
        [InlineData("Gamma", TestEnum.Gamma)]
        [InlineData("Delta", TestEnum.Delta)]
        [InlineData("Epsilon", TestEnum.Epsilon)]
        public void StringToEnum(string actual, TestEnum expected)
        {
            Assert.Equal(expected, actual.ToEnum<TestEnum>());
        }

        /// <summary>
        /// String does not exist in enum, exception  thrown
        /// </summary>
        /// <param name="actual"></param>
        [Theory]
        [InlineData("Alpha1")]
        [InlineData("Beta2")]
        [InlineData("Gamma3")]
        [InlineData("Delta4")]
        [InlineData("Epsilon5")]
        public void StringToEnumArgumentException(string actual)
        {
            Assert.Throws<ArgumentException>(() => { _ = actual.ToEnum<TestEnum>(); });
        }
    }
}

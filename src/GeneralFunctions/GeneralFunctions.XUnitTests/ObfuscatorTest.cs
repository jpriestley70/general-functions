using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using GeneralFunctions.Library.Security;
using Xunit;

namespace GeneralFunctions.XUnitTests
{
    public class ObfuscatorTest
    {
        [Theory]
        [InlineData(0)]
        [InlineData(int.MaxValue)]
        [InlineData(int.MinValue)]
        public void ObfuscateInteger_UnobfuscateGuid(int expected)
        {
            // Arrange
            Guid guid = Obfuscator.IntegerToGuid(expected);

            // Act
            int actual = Obfuscator.GuidToInteger(guid);

            // Assert
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("10a78885-238e-4e66-8bb1-632245891ba3", true)]
        [InlineData("0dfa612b-c009-4e1c-abb6-004b586a1bc7", true)]
        [InlineData("0c2894b0-e560-4cca-95e8-3141a6b0e686", true)]
        [InlineData("0D499522-BB69-4E64-AEEC-18B1B0622A14", false)]
        [InlineData("1D0AC715-3E3C-4814-83CC-05279678A322", false)]
        [InlineData("3D8A6BD6-7B9A-4694-8FC8-5CF9A96A795E", false)]
        public void GuidIsValid(Guid guid, bool expected)
        {
            bool actual = Obfuscator.IsValidGuid(guid);
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("10a78885-238e-4e66-8bb1-632245891ba3", 0)]
        [InlineData("0dfa612b-c009-4e1c-abb6-004b586a1bc7", int.MinValue)]
        [InlineData("0c2894b0-e560-4cca-95e8-3141a6b0e686", int.MaxValue)]
        public void UnobfuscateInteger(Guid guid, int expected)
        {
            int actual = Obfuscator.GuidToInteger(guid);
            Assert.Equal(expected, actual);
        }
    }
}

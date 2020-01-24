using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneralFunctions.Library.Extensions;
using GeneralFunctions.XUnitTests.Models;
using Xunit;

#nullable enable

namespace GeneralFunctions.XUnitTests
{
    public class StringManipulateUnitTest
    {
        #region GetLines
        /// <summary>
        /// Get lines from the text
        /// </summary>
        [Fact]
        public void GetLines_Default()
        {
            // Assign
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi quis ex libero.");
            sb.AppendLine("Proin tellus nibh, malesuada euismod tortor et, sagittis posuere enim. Donec pulvinar odio justo, ut ultricies ipsum imperdiet ornare.");
            sb.AppendLine("Phasellus ligula nisi, placerat in lorem sit amet, convallis suscipit neque.");
            sb.AppendLine("Duis elit velit, facilisis vitae pulvinar eget, vehicula nec leo.");
            sb.AppendLine("Ut commodo semper diam et pulvinar. Integer ac metus commodo, ultricies sapien a, gravida risus.");

            // Act
            IEnumerable<string> lines = sb.ToString().GetLines();
            int length = lines.Count();

            // Assert
            Assert.Equal(5, length);
        }

        /// <summary>
        /// Get lines from the text removing empty lines
        /// </summary>
        [Fact]
        public void GetLines_Remove_EmptyLines()
        {
            // Assign
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi quis ex libero.");
            sb.AppendLine("");
            sb.AppendLine("Proin tellus nibh, malesuada euismod tortor et, sagittis posuere enim. Donec pulvinar odio justo, ut ultricies ipsum imperdiet ornare.");
            sb.AppendLine("");
            sb.AppendLine("Phasellus ligula nisi, placerat in lorem sit amet, convallis suscipit neque.");
            sb.AppendLine("");
            sb.AppendLine("Duis elit velit, facilisis vitae pulvinar eget, vehicula nec leo.");
            sb.AppendLine("");
            sb.AppendLine("Ut commodo semper diam et pulvinar. Integer ac metus commodo, ultricies sapien a, gravida risus.");

            // Act
            IEnumerable<string> lines = sb.ToString().GetLines(true);

            // Assert
            Assert.Equal(5, lines.Count());
        }

        /// <summary>
        /// Empty lines from a null string
        /// </summary>
        [Fact]
        public void GetLines_Null()
        {
            // Assign
            string? nullString = null;

            // Act
            IEnumerable<string> lines = nullString.GetLines();
            int length = lines.Count();

            // Assert
            Assert.Equal(0, length);
        }
        #endregion

        #region Truncate
        /// <summary>
        /// Truncate string
        /// </summary>
        [Fact]
        public void Truncate_Text()
        {
            // Assign
            // 44 characters
            string original = "The quick brown fox jumped over the lazy dog";

            // 19 characters
            string expected = "The quick brown fox";

            // Act
            string? actual = original.Truncate(19);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Truncate string where value is larger than the string length
        /// </summary>
        [Fact]
        public void Truncate_Text_Larger_Than_String_Length()
        {
            // Assign
            // 44 characters
            string original = "The quick brown fox jumped over the lazy dog";

            // 44 characters
            string expected = "The quick brown fox jumped over the lazy dog";

            // Act
            string? actual = original.Truncate(100);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Truncate null string
        /// </summary>
        [Fact]
        public void Truncate_Text_Null()
        {
            // Assign
            // 44 characters
            string? original = null;

            // 44 characters
            string? expected = null;

            // Act
            string? actual = original.Truncate(100);

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region Shorten
        /// <summary>
        /// Shorten string
        /// </summary>
        [Fact]
        public void Shorten_Text()
        {
            // Assign
            // 44 characters
            string original = "The quick brown fox jumped over the lazy dog";

            // 19 characters + ellipse
            string expected = "The quick brown fox...";

            // Act
            string? actual = original.Shorten(19);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shorten string where value is larger than the string length
        /// </summary>
        [Fact]
        public void Shorten_Text_Larger_Than_String_Length()
        {
            // Assign
            // 44 characters
            string original = "The quick brown fox jumped over the lazy dog";

            // 44 characters
            string expected = "The quick brown fox jumped over the lazy dog";

            // Act
            string? actual = original.Shorten(100);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shorten null string
        /// </summary>
        [Fact]
        public void Shorten_Text_Null()
        {
            // Assign
            // 44 characters
            string? original = null;

            // 44 characters
            string? expected = null;

            // Act
            string? actual = original.Shorten(100);

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Shorten string
        /// </summary>
        [Fact]
        public void Shorten_Text_With_Ellipse()
        {
            // Assign
            // 44 characters
            string original = "The quick brown fox jumped over the lazy dog";

            // 19 characters + ellipse
            string expected = "The quick brown fox***";

            // Act
            string? actual = original.Shorten(19, "***");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion

        #region ConcatenateString
        /// <summary>
        /// Concatenate string array into string
        /// </summary>
        [Fact]
        public void ConcatenateString_Array()
        {
            // Assign
            string[] words = { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
            string expected = "AlphaBetaGammaDeltaEpsilon";

            // Act
            string actual = words.ConcatenateString();

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string array into string with a separator
        /// </summary>
        [Fact]
        public void ConcatenateString_Array_Separator()
        {
            // Assign
            string[] words = { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
            string expected = "Alpha-Beta-Gamma-Delta-Epsilon";

            // Act
            string actual = words.ConcatenateString("-");

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string array into string with a separator
        /// </summary>
        [Fact]
        public void ConcatenateString_Array_Empty()
        {
            // Assign
            string[] words = { "" };
            string expected = "";

            // Act
            string actual = words.ConcatenateString("-");

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string list into string
        /// </summary>
        [Fact]
        public void ConcatenateString_List()
        {
            // Assign
            List<string> words = new List<string>() { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
            string expected = "AlphaBetaGammaDeltaEpsilon";

            // Act
            string actual = words.ConcatenateString();

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string list into string
        /// </summary>
        [Fact]
        public void ConcatenateString_List_Separator()
        {
            // Assign
            List<string> words = new List<string>() { "Alpha", "Beta", "Gamma", "Delta", "Epsilon" };
            string expected = "Alpha-Beta-Gamma-Delta-Epsilon";

            // Act
            string actual = words.ConcatenateString("-");

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string list is empty
        /// </summary>
        [Fact]
        public void ConcatenateString_List_Empty()
        {
            // Assign
            List<string> words = new List<string>();
            string expected = "";

            // Act
            string actual = words.ConcatenateString("-");

            // Assert
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Concatenate string list is null
        /// </summary>
        [Fact]
        public void ConcatenateString_List_Null()
        {
            // Assign
            List<string>? words = null;
            string expected = "";

            // Act
            string actual = words.ConcatenateString("-");

            // Assert
            Assert.Equal(expected, actual);
        }
        #endregion
    }
}

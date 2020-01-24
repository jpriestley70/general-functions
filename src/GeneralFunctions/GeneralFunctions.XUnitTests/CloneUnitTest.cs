using System;
using System.Collections.Generic;
using System.Text;
using GeneralFunctions.XUnitTests.Models;
using GeneralFunctions.Library.Extensions;
using Xunit;

namespace GeneralFunctions.XUnitTests
{
    public class CloneUnitTest
    {
        #region Cloning Serialized
        /// <summary>
        /// Clone public properties
        /// </summary>
        [Fact]
        public void Clone_Light()
        {
            // Arrange
            CloneModel original = new CloneModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel cloned = original.Clone();

            // Assert
            Assert.Equal(original.Id, cloned.Id);
            Assert.Equal(original.Description, cloned.Description);
            Assert.Equal(original.IntValue, cloned.IntValue);
            Assert.Equal(original.FltValue, cloned.FltValue);
        }

        /// <summary>
        /// Unable to clone private member variable
        /// </summary>
        [Fact]
        public void Clone_Light_PrivateMember_Fails()
        {
            // Arrange
            CloneModel original = new CloneModel(DateTime.UtcNow)
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel cloned = original.Clone();

            // Assert
            Assert.NotNull(original.SomeTimeAgo);
            Assert.Null(cloned.SomeTimeAgo);
        }

        /// <summary>
        /// Clone public properties using deep cloning method
        /// </summary>
        [Fact]
        public void Clone_Deep()
        {
            // Arrange
            CloneModel original = new CloneModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel cloned = original.Clone(true);

            // Assert
            Assert.Equal(original.Id, cloned.Id);
            Assert.Equal(original.Description, cloned.Description);
            Assert.Equal(original.IntValue, cloned.IntValue);
            Assert.Equal(original.FltValue, cloned.FltValue);
        }

        /// <summary>
        /// Clone using deep method which will clone the private member variable
        /// </summary>
        [Fact]
        public void Clone_Deep_PrivateMember()
        {
            // Arrange
            CloneModel original = new CloneModel(DateTime.UtcNow)
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel cloned = original.Clone(true);

            // Assert
            Assert.Equal(original.SomeTimeAgo, cloned.SomeTimeAgo);
        }
        #endregion

        #region Cloning Non-Serialized
        /// <summary>
        /// Clone public properties
        /// </summary>
        [Fact]
        public void CloneNonSerialized_Light()
        {
            // Arrange
            CloneNonSerializedModel original = new CloneNonSerializedModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneNonSerializedModel cloned = original.Clone();

            // Assert
            Assert.Equal(original.Id, cloned.Id);
            Assert.Equal(original.Description, cloned.Description);
            Assert.Equal(original.IntValue, cloned.IntValue);
            Assert.Equal(original.FltValue, cloned.FltValue);
        }

        /// <summary>
        /// Unable to clone private member variable
        /// </summary>
        [Fact]
        public void CloneNonSerialized_Light_PrivateMember_Fails()
        {
            // Arrange
            CloneNonSerializedModel original = new CloneNonSerializedModel(DateTime.UtcNow)
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneNonSerializedModel cloned = original.Clone();

            // Assert
            Assert.NotNull(original.SomeTimeAgo);
            Assert.Null(cloned.SomeTimeAgo);
        }

        /// <summary>
        /// Clone public properties using deep cloning method will fail because the class is not Serializable
        /// </summary>
        [Fact]
        public void CloneNonSerialized_Deep_Exception()
        {
            // Arrange
            CloneNonSerializedModel original = new CloneNonSerializedModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                CloneNonSerializedModel cloned = original.Clone(true);

            });
        }

        /// <summary>
        /// Clone using deep method which will clone the private member variable will fail because the class is not Serializable
        /// </summary>
        [Fact]
        public void CloneNonSerialized_Deep_PrivateMember_Exception()
        {
            // Arrange
            CloneNonSerializedModel original = new CloneNonSerializedModel(DateTime.UtcNow)
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Assert
            Assert.Throws<ArgumentException>(() =>
            {
                // Act
                CloneNonSerializedModel cloned = original.Clone(true);

            });
        }
        #endregion

        #region Changing Parameters
        /// <summary>
        /// The copied class is just referencing the original class therefore changes in copied are also reflected in original
        /// </summary>
        [Fact]
        public void Copy_Class_ChangeValue_StaySame()
        {
            // Arrange
            CloneModel original = new CloneModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel copied = original;
            copied.IntValue = 123;

            // Assert
            Assert.Equal(original.IntValue, copied.IntValue);
        }

        /// <summary>
        /// Changes made to cloned class are not reflected in original class
        /// </summary>
        [Fact]
        public void Clone_Class_ChangeValue_NotSame()
        {
            // Arrange
            CloneModel original = new CloneModel()
            {
                Id = Guid.NewGuid(),
                Description = "Some random description",
                IntValue = 99,
                FltValue = 3.1415926f,
                Lines = new List<string>() { "Alpha", "Beta", "Gamma" }
            };

            // Act
            CloneModel cloned = original.Clone();
            cloned.IntValue = 123;

            // Assert
            Assert.NotEqual(original.IntValue, cloned.IntValue);
        }
        #endregion
    }
}

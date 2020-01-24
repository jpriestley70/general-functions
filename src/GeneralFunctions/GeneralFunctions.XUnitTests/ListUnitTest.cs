using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GeneralFunctions.Library.Extensions;
using GeneralFunctions.XUnitTests.Models;
using Xunit;

namespace GeneralFunctions.XUnitTests
{
    public class ListUnitTest
    {
        /// <summary>
        /// Append two populated lists
        /// </summary>
        [Fact]
        public void Append_Two_Lists()
        {
            // Arrange
            List<CloneModel> primary = new List<CloneModel>()
            {
                new CloneModel() { Id = new Guid(), Description = "Description 1", IntValue = 1, FltValue = 1.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 2", IntValue = 2, FltValue = 2.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 3", IntValue = 3, FltValue = 3.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 4", IntValue = 4, FltValue = 4.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 5", IntValue = 5, FltValue = 5.5f, Lines = null }
            };

            List<CloneModel> secondary = new List<CloneModel>()
            {
                new CloneModel() { Id = new Guid(), Description = "Description 6", IntValue = 6, FltValue = 6.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 7", IntValue = 7, FltValue = 7.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 8", IntValue = 8, FltValue = 8.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 9", IntValue = 9, FltValue = 9.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 10", IntValue = 10, FltValue = 10.5f, Lines = null }
            };

            // Act
            primary.AppendList(secondary);

            // Assert
            Assert.Equal(10, primary.Count());
        }

        /// <summary>
        /// Append a Null list to existing list and fail
        /// </summary>
        [Fact]
        public void Append_Null_List()
        {
            // Arrange
            List<CloneModel> primary = new List<CloneModel>()
            {
                new CloneModel() { Id = new Guid(), Description = "Description 1", IntValue = 1, FltValue = 1.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 2", IntValue = 2, FltValue = 2.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 3", IntValue = 3, FltValue = 3.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 4", IntValue = 4, FltValue = 4.5f, Lines = null },
                new CloneModel() { Id = new Guid(), Description = "Description 5", IntValue = 5, FltValue = 5.5f, Lines = null }
            };

            List<CloneModel> secondary = null;

            // Assert
            Assert.Throws<NullReferenceException>(() =>
            {
                // Act
                primary.AppendList(secondary);
            });

        }
    }
}

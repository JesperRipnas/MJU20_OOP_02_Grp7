using System;
using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MJU20_OOP_02_Grp7.UnitTests
{
    [TestClass]
    public class LevelReaderTests
    {
        [TestMethod]
        public void TestLoadingLevel()
        {
            // Arrange
            string fileName = "Level1.txt";

            // Act
            var result = LevelReader.LoadLevel(fileName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(char[,]));

            // Will not work because we try to create objects (Entities) from the file in the method
            // Need to cut down the method in smaller parts to test
        }
    }
}
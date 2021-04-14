using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MJU20_OOP_02_Grp7;

namespace MJU20_OOP_02_Grp7.UnitTests
{
    [TestClass]
    public class LevelReaderTests
    {
        [TestMethod]
        public void TestLoadingLevel()
        {
            // Arrange
            string fileName = "TestLevel.txt";

            // Act
            var result = LevelReader.LoadLevel(fileName);

            // Assert
            Assert.IsInstanceOfType(result, typeof(char[,]));
        }   
    }
}

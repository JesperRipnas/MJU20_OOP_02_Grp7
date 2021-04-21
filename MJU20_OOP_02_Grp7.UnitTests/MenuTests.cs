using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MJU20_OOP_02_Grp7.UnitTests
{
    [TestClass]
    public class Menutests
    {
        [TestMethod]
        public void Test_CheckPlayerName_ExpectReturnTrue()
        {
            // Arrange
            bool expected = true;
            List<string> listOfPlayerNames = new List<string> { "JesperRipnäs", "Linus", "Olivia", "Sebastian", "Joakim", "Björne", "EliteKiller_1337" };
            // Act
            foreach (string name in listOfPlayerNames)
            {
                expected = Menu.CheckPlayerName(name);
                if (!expected) break;
            }
            // Assert
            Assert.IsTrue(expected);
        }

        [TestMethod]
        public void Test_CheckPlayerName_ExpectReturnFalse()
        {
            // Arrange
            bool expected = false;
            List<string> listOfPlayerNames = new List<string> { "¤¤#%_Z9", "   ", " ", "@@", "(/)!!¤#" };
            // Act
            foreach (string name in listOfPlayerNames)
            {
                expected = Menu.CheckPlayerName(name);
                if (expected) break;
            }
            // Assert
            Assert.IsFalse(expected);
        }
    }
}
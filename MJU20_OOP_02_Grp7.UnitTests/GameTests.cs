using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MJU20_OOP_02_Grp7;


namespace MJU20_OOP_02_Grp7.UnitTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void Add()
        {
            // Arrange
            Game bm = new Game();

            // Act
            int expected = bm.Add(5, 5);

            // Assert
            Assert.AreEqual(expected, 10);
        }
    }
}

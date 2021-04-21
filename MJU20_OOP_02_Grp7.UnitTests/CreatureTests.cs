using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MJU20_OOP_02_Grp7.UnitTests
{
    [TestClass]
    public class CreatureTests
    {
        [TestMethod]
        public void subtractDamageFromHp()
        {
            // Arrange
            Player player = new Player("Olivia", 100, 1, new Point(0, 0), '@', ConsoleColor.Green);

            // Act
            player.Damage(10);

            // Assert
            Assert.AreEqual(player.Hp, 90);
        }

        [TestMethod]
        public void addHealToHp()
        {
            Player player = new Player("Olivia", 100, 1, new Point(0, 0), '@', ConsoleColor.Green);

            player.Heal(10);

            Assert.AreEqual(player.Hp, 110);
        }

        [TestMethod]
        public void addNewDamageToCurrentDamage()
        {
            Player player = new Player("Olivia", 100, 1, new Point(0, 0), '@', ConsoleColor.Green);

            player.SetDamage(5);

            Assert.AreEqual(player.Dmg, 6);
        }
    }
}

using MagicSquare;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTestMagicSquare
{
    [TestClass]
    public class GameEngineTest
    {
        [TestMethod]
        public void CheckMove_WhenClickOnEmptyCell_ShouldReturnFalse()
        {
            GameEngine gameEngine = new GameEngine();

            var x = gameEngine.CheckMove(5, 6, string.Empty);

            Assert.IsFalse(x);
        }
    }
}

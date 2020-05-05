using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CZT.Core;
using System.Collections.Generic;

namespace Tests
{

    [TestClass]
    public class TestLine_Should
    {
        private Game Initialize_OnePlayer()
        {
            var names = new List<string>();
            names.Add("p");
            Game game1 = new Game(names, 1, 1);
            return game1;
        }

        private Game Initialize_TwoPlayer()
        {
            var names = new List<string>();
            names.Add("p");
            names.Add("q");
            Game game1 = new Game(names, 2, 2);
            return game1;
        }

        private Game Initialize_ThreePlayer()
        {
            var names = new List<string>();
            names.Add("p");
            names.Add("q");
            names.Add("z");
            Game game1 = new Game(names, 3, 3);
            return game1;
        }

        [TestMethod]
        public void TestFirstPointCreateLine()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player.Lines.Count);
        }

        [TestMethod]
        public void TestSecondPointNotConnectLine()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(1, 2);
            Assert.AreEqual(2, player.Lines.Count);
        }
        
        [TestMethod]
        public void TestSecondPointConnectLine()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            Assert.AreEqual(2, player.Lines[0].Length);
            Assert.AreEqual(1, player.Lines.Count);
        }

        [TestMethod]
        public void TestThirdPointConnectLine()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(1, 0);
            Assert.AreEqual(3, player.Lines[0].Length);
            Assert.AreEqual(1, player.Lines.Count);
        }

        [TestMethod]
        public void TestThirdPointWhenNoLinesCorrect()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(0, 1);
            Assert.AreEqual(3, player.Lines.Count);
        }

        [TestMethod]
        public void TestDiagonalLineLengthTwo()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(2, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestDiagonalLineLengthThree()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(2, 2);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(3, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestReverseDiagonalLineLengthThree()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(2, 0);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(3, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestMultiplyLines()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(4, player.Lines.Count);
        }

        [TestMethod]
        public void TestContinueLongLineWhenLineExists()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(2, 1);
            Assert.AreEqual(4, player.Lines.Count);
        }

        [TestMethod]
        public void TestMultiplyLinesWhen4PointIsReady()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            Assert.AreEqual(7, player.Lines.Count);
        }

        [TestMethod]
        public void TestMultiplyLinesWhen5PointIsReady()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(1, 0);
            Assert.AreEqual(9, player.Lines.Count);
        }

        [TestMethod]
        public void TestFillMapFully()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            for (var x = 0; x < game1.CurrentLevel.width; x++)
                for (var y = 0; y < game1.CurrentLevel.height; y++)
                    game1.CurrentLevel.MakeMove(y, x);
            Assert.AreEqual(12, player.Lines.Count);
        }

        [TestMethod]
        public void TestBetweenTwoPointsBothGetLines()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(3, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestBetweenReverseDiagonalTwoPointsBothGetLines()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(2, 0);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(3, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestBetweenDiagonalTwoPointsBothGetLines()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(2, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player.Lines.Count);
            Assert.AreEqual(3, player.Lines[0].Length);
        }

        [TestMethod]
        public void TestBetweenTwoPointsWhenOneIncorrect()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(0, 1);
            Assert.AreEqual(3, player.Lines.Count);
        }

        [TestMethod]
        public void TestManyDiagonal()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(2, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            Assert.AreEqual(4, player.Lines.Count);
        }

        [TestMethod]
        public void TestBetweenDiagonal4PointsAllIncorrect()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 1);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(2, 1);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(6, player.Lines.Count);
        }

        [TestMethod]
        public void TestWhenBothIncorrect()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            game1.CurrentLevel.MakeMove(0, 0);
            game1.CurrentLevel.MakeMove(0, 2);
            game1.CurrentLevel.MakeMove(1, 0);
            game1.CurrentLevel.MakeMove(1, 2);
            game1.CurrentLevel.MakeMove(0, 1);
            Assert.AreEqual(5, player.Lines.Count);
        }

        [TestMethod]
        public void TestFillMapSize5()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(5, 5);
            for (var x = 0; x < game1.CurrentLevel.width; x++)
                for (var y = 0; y < game1.CurrentLevel.height; y++)
                    game1.CurrentLevel.MakeMove(y, x);
            Assert.AreEqual(24, player.Lines.Count);
        }

        [TestMethod]
        public void TestPointBetween8PointsAllIncorrect()
        {
            var game1 = Initialize_OnePlayer();
            var player = game1.Players[0];
            game1.StartLevel(3, 3);
            for (var x = 0; x < game1.CurrentLevel.width; x++)
                for (var y = 0; y < game1.CurrentLevel.height; y++)
                {
                    if (x == 1 && y == 1) continue;
                    game1.CurrentLevel.MakeMove(y, x);
                }
            game1.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(12, player.Lines.Count);
        }

        [TestMethod]
        public void TestTwoPlayersSetPointsAndLineNotConnected()
        {
            var game2 = Initialize_TwoPlayer();
            var player1 = game2.Players[0];
            var player2 = game2.Players[1];
            game2.StartLevel(3, 3);
            game2.CurrentLevel.MakeMove(0, 0);
            game2.CurrentLevel.MakeMove(1, 0);
            Assert.AreEqual(1, player1.Lines.Count);
            Assert.AreEqual(1, player2.Lines.Count);
            Assert.AreEqual(1, player1.Lines[0].Length);
            Assert.AreEqual(1, player2.Lines[0].Length);
        }

        [TestMethod]
        public void TestTwoPlayersSetLongLine()
        {
            var game2 = Initialize_TwoPlayer();
            var player1 = game2.Players[0];
            var player2 = game2.Players[1];
            game2.StartLevel(3, 3);
            game2.CurrentLevel.MakeMove(0, 0);
            game2.CurrentLevel.MakeMove(1, 0);
            game2.CurrentLevel.MakeMove(0, 1);
            game2.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(1, player1.Lines.Count);
            Assert.AreEqual(1, player2.Lines.Count);
            Assert.AreEqual(2, player1.Lines[0].Length);
            Assert.AreEqual(2, player2.Lines[0].Length);
        }

        [TestMethod]
        public void TestThreePlayersSetLongLine()
        {
            var game3 = Initialize_ThreePlayer();
            var player1 = game3.Players[0];
            var player2 = game3.Players[1];
            var player3 = game3.Players[2];
            game3.StartLevel(3, 3);
            for (var x = 0; x < game3.CurrentLevel.width; x++)
                for (var y = 0; y < game3.CurrentLevel.height; y++)
                    game3.CurrentLevel.MakeMove(y, x);

            Assert.AreEqual(1, player1.Lines.Count);
            Assert.AreEqual(1, player2.Lines.Count);
            Assert.AreEqual(1, player3.Lines.Count);
            Assert.AreEqual(3, player3.Lines[0].Length);
            Assert.AreEqual(3, player1.Lines[0].Length);
            Assert.AreEqual(3, player2.Lines[0].Length);

        }
    }
}

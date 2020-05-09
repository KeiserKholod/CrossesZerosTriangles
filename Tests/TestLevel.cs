using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CZT.Core;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MakeMapTest
    {
        private int lengthToWin = 100;
        [TestMethod]
        public void TestInitMap1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.CurrentLevel.width, 2);
            Assert.AreEqual(game.CurrentLevel.height, 3);
        }

        [TestMethod]
        public void TestInitMap2()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(1000, 100, lengthToWin);
            Assert.AreEqual(game.CurrentLevel.width, 1000);
            Assert.AreEqual(game.CurrentLevel.height, 100);
        }
    }

    [TestClass]
    public class AddPlayesrTest
    {
        private int lengthToWin = 5;
        [TestMethod]
        public void TestAddPlayer1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.Players.Count, 1);
            Assert.AreEqual(game.Players[0].Id, 1);
            Assert.AreEqual(game.Players[0].Name, "petya");
        }

        [TestMethod]
        public void TestAddTwoPlayers()
        {
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 2, 2);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.Players.Count, 2);
            Assert.AreEqual(game.Players[0].Id, 1);
            Assert.AreEqual(game.Players[0].Name, "petya");
            Assert.AreEqual(game.Players[1].Id, 2);
            Assert.AreEqual(game.Players[1].Name, "vasya");
        }

        [TestMethod]
        public void TestAddBot()
        {
            var names = new List<String>();
            names.Add("");
            var game = new Game(names, 1, 0);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.Players.Count, 1);
            Assert.AreEqual(game.Players[0].Id, 1);
            Assert.AreEqual(game.Players[0].Name, "player 1");
        }

        [TestMethod]
        public void TestAddBotAndPlayer()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 2, 1);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.Players.Count, 2);
            Assert.AreEqual(game.Players[0].Id, 1);
            Assert.AreEqual(game.Players[0].Name, "petya");
            Assert.AreEqual(game.Players[1].Id, 2);
            Assert.AreEqual(game.Players[1].Name, "player 2");

        }

        [TestMethod]
        public void TestAddTwoBotsAndTwoPlayers()
        {
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 4, 2);
            game.StartLevel(2, 3, lengthToWin);
            Assert.AreEqual(game.Players.Count, 4);
            Assert.AreEqual(game.Players[0].Id, 1);
            Assert.AreEqual(game.Players[0].Name, "petya");
            Assert.AreEqual(game.Players[1].Id, 2);
            Assert.AreEqual(game.Players[1].Name, "vasya");
            Assert.AreEqual(game.Players[2].Id, 3);
            Assert.AreEqual(game.Players[2].Name, "player 3");
            Assert.AreEqual(game.Players[3].Id, 4);
            Assert.AreEqual(game.Players[3].Name, "player 4");

        }
    }

    [TestClass]
    public class MakeMoveTest
    {
        private int lengthToWin = 5;
        [TestMethod]
        public void TestMakeMovePlayer1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3, lengthToWin);
            game.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(game.CurrentLevel.Map[1, 1], 1);
        }

        [TestMethod]
        public void TestMakeMovePlayer2()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(5, 5, lengthToWin);
            game.CurrentLevel.MakeMove(2, 3);
            Assert.AreEqual(game.CurrentLevel.Map[2, 3], 1);
        }

        [TestMethod]
        public void TestMakeTwoPlayersTwoMoves()
        {
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 2, 2);
            game.StartLevel(5, 5, lengthToWin);
            game.CurrentLevel.MakeMove(2, 3);
            game.CurrentLevel.MakeMove(3, 4);
            Assert.AreEqual(game.CurrentLevel.Map[2, 3], 1);
            Assert.AreEqual(game.CurrentLevel.Map[3, 4], 2);
        }
    }

    [TestClass]
    public class CheckWinTest
    {
        [TestMethod]
        public void TestWinFirstOfTwo()
        {
            var lengthToWin = 2;
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 2, 2);
            game.StartLevel(5, 5, lengthToWin);
            game.CurrentLevel.MakeMove(0, 0);
            game.CurrentLevel.MakeMove(2, 2);
            game.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(game.CurrentLevel.Winner.Id, 1);
            Assert.AreEqual(game.CurrentLevel.IsDraw, false);
        }

        [TestMethod]
        public void TestWinSecondOfTwo()
        {
            var lengthToWin = 2;
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 2, 2);
            game.StartLevel(5, 5, lengthToWin);
            game.CurrentLevel.MakeMove(0, 0);
            game.CurrentLevel.MakeMove(2, 2);
            game.CurrentLevel.MakeMove(1, 3);
            game.CurrentLevel.MakeMove(3, 3);
            Assert.AreEqual(game.CurrentLevel.Winner.Id, 2);
            Assert.AreEqual(game.CurrentLevel.IsDraw, false);
        }

        [TestMethod]
        public void TestWinThirdOfThree()
        {
            var lengthToWin = 2;
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            names.Add("kolya");
            var game = new Game(names, 3, 3);
            game.StartLevel(5, 5, lengthToWin);
            game.CurrentLevel.MakeMove(2, 1);
            game.CurrentLevel.MakeMove(1, 3);
            game.CurrentLevel.MakeMove(1, 1);
            game.CurrentLevel.MakeMove(3, 3);
            game.CurrentLevel.MakeMove(4, 4);
            game.CurrentLevel.MakeMove(0, 0);
            Assert.AreEqual(game.CurrentLevel.Winner.Id, 3);
            Assert.AreEqual(game.CurrentLevel.IsDraw, false);
        }

        [TestMethod]
        public void TestDraw()
        {
            var lengthToWin = 5;
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            names.Add("kolya");
            var game = new Game(names, 3, 3);
            game.StartLevel(2, 2, lengthToWin);
            game.CurrentLevel.MakeMove(0, 0);
            game.CurrentLevel.MakeMove(0, 1);
            game.CurrentLevel.MakeMove(1, 0);
            game.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(game.CurrentLevel.Winner, null);
            Assert.AreEqual(game.CurrentLevel.IsDraw, true);
        }

        [TestMethod]
        public void TestNotDrawAndNotWin()
        {
            var lengthToWin = 5;
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            names.Add("kolya");
            var game = new Game(names, 3, 3);
            game.StartLevel(2, 2, lengthToWin);
            game.CurrentLevel.MakeMove(0, 0);
            game.CurrentLevel.MakeMove(0, 1);
            game.CurrentLevel.MakeMove(1, 0);
            Assert.AreEqual(game.CurrentLevel.Winner, null);
            Assert.AreEqual(game.CurrentLevel.IsDraw, false);
        }
    }
}

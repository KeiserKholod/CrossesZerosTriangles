using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CZT.Core;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class MakeMapTest
    {
        [TestMethod]
        public void TestInitMap1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3);
            Assert.AreEqual(game.CurrentLevel.width, 2);
            Assert.AreEqual(game.CurrentLevel.height, 3);
        }

        [TestMethod]
        public void TestInitMap2()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(1000, 100);
            Assert.AreEqual(game.CurrentLevel.width, 1000);
            Assert.AreEqual(game.CurrentLevel.height, 100);
        }
    }

    [TestClass]
    public class AddPlayesrTest
    {
        [TestMethod]
        public void TestAddPlayer1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3);
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
            game.StartLevel(2, 3);
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
            game.StartLevel(2, 3);
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
            game.StartLevel(2, 3);
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
            game.StartLevel(2, 3);
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
        [TestMethod]
        public void TestMakeMovePlayer1()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(2, 3);
            game.CurrentLevel.MakeMove(1, 1);
            Assert.AreEqual(game.CurrentLevel.Map[1, 1], 1);
        }

        public void TestMakeMovePlayer2()
        {
            var names = new List<String>();
            names.Add("petya");
            var game = new Game(names, 1, 1);
            game.StartLevel(5, 5);
            game.CurrentLevel.MakeMove(2, 3);
            Assert.AreEqual(game.CurrentLevel.Map[2, 3], 1);
        }

        public void TestMakeTwoPlayersTwoMoves()
        {
            var names = new List<String>();
            names.Add("petya");
            names.Add("vasya");
            var game = new Game(names, 2, 2);
            game.StartLevel(5, 5);
            game.CurrentLevel.MakeMove(2, 3);
            game.CurrentLevel.MakeMove(4, 5);
            Assert.AreEqual(game.CurrentLevel.Map[2, 3], 1);
            Assert.AreEqual(game.CurrentLevel.Map[4, 5], 2);
        }
    }
}

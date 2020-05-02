using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    class Game
    {
        public readonly List<Player> Players;
        public readonly int height;
        public readonly int width;
        private int[,] map;

        public int[,] Map
        {
            get
            {
                return map;
            }
        }

        private int moveNum;

        private int MoveNum
        {
            get
            {
                return moveNum;
            }
        }

        public Game(int playersCount, int width, int height)
        {
            this.width = width;
            this.height = height;
            moveNum = 0;
            PreparePlayers(playersCount);
            PrepareMap();
        }

        private void PrepareMap()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    map[x, y] = 0;
        }

        private void PreparePlayers(int playersCount)
        {
            for (int i = 0; i < playersCount; i++)
            {
                var player = new Player(i);
                //var player = new Player(name, i);
                Players.Add(player);
            }
        }

        public void MakeMove()
        {
            foreach (var player in Players)
            {
                player.MakeMove(this);
            }
            var winner = GetWinner();
            if (winner != null)
                EndGame();
        }

        private void EndGame()
        {
            //something
        }

        private Player GetWinner()
        {
            //возвращаем победителя, либо null
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    class Level
    {
        private Game game;
        public readonly int height;
        public readonly int width;
        private int moveNum;
        private int[,] map;
        private int currentPlayerInd;

        public int MoveNum
        {
            get
            {
                return moveNum;
            }
            private set
            {
                moveNum = value;
            }
        }

        public int[,] Map
        {
            get
            {
                return map;
            }
            private set
            {
                map = value;
            }
        }

        public Level(Game game, int width, int height)
        {
            this.game = game;
            this.width = width;
            this.height = height;
            moveNum = 0;
            currentPlayerInd = 0;
            PrepareMap();
        }

        private void PrepareMap()
        {
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Map[x, y] = 0;
        }

        public void MakeMove(int x, int y)
        {
            game.Players[currentPlayerInd].MakeMove(this, x, y);
            var winner = GetWinner();
            if (winner != null)
                EndLevel();
        }

        private Player GetWinner()
        {
            //возвращаем победителя, либо null
            return null;
        }

        private void EndLevel()
        {
            //завершение уровня
        }
    }
}

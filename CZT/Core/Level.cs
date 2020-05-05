using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    public class Level
    {
        private Game game;
        private bool cantMove;
        public readonly int height;
        public readonly int width;
        private int moveNum;
        private int[,] map;
        private int currentPlayerInd;
        private List<List<Line>> allLines;
        public HashSet<Point> settedPoints = new HashSet<Point>();
        public List<Point> Points = new List<Point>();

        public bool CantMove { get; private set; }
        public List<List<Line>> AllLines { get; set; }

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
            PrepareAllLInes(AllLines);
            PrepareMap();
        }

        private void PrepareAllLInes(List<List<Line>> allLines)
        {
            AllLines = new List<List<Line>>();
            foreach (var player in game.Players)
                AllLines.Add(player.Lines);
        }

        private void PrepareMap()
        {
            Map = new int[width, height];
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    Map[x, y] = 0;
        }

        public void MakeMove(int x, int y)
        {
            CantMove = false;
            if (Map[x, y] != 0)
            {
                CantMove = true;
                return;
            }
            game.Players[currentPlayerInd].MakeMove(this, x, y);
            var pointToSet = new Point(x, y, game.Players[currentPlayerInd].Id);
            Points.Add(pointToSet);
            settedPoints.Add(pointToSet);
            Line.Connect(game.Players[currentPlayerInd], this, pointToSet);
            currentPlayerInd++;
            //ходим ботам после всех игроков
            //иначе не знаю пока как реализовать
            if (currentPlayerInd == game.RealPlayersCount)
            {
                for (int i = currentPlayerInd; i < game.PlayersCount; i++)
                {
                    game.Players[i].MakeMove(this);
                }
                currentPlayerInd = 0;
            }
            /* var winner = GetWinner();
             if (winner != null)
                 EndLevel();*/
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
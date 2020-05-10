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
        private int movesCount;
        private int lengthToWin;
        private bool isDraw;
        private bool cantMove;
        private Player winner;
        public readonly int height;
        public readonly int width;
        private int moveNum;
        private int[,] map;
        private int currentPlayerInd;
        private List<List<Line>> allLines;
        public HashSet<Point> settedPoints = new HashSet<Point>();
        public List<Point> Points = new List<Point>();

        public bool CantMove { get; private set; }
        public bool IsDraw { get; private set; }
        public Player Winner { get; private set; }
        public List<List<Line>> AllLines { get; set; }
        public int MoveNum { get; private set; }

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

        public Level(Game game, int width, int height, int lengthToWint)
        {
            this.game = game;
            this.width = width;
            this.height = height;
            this.lengthToWin = lengthToWint;
            IsDraw = false;
            MoveNum = 0;
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
            MoveNum++;
            currentPlayerInd++;
            //определяем победителя
            Winner = GetWinner();
            //проверяем ничью
            IsDraw = CheckDraw();
            //ходим ботам после всех игроков
            //иначе не знаю пока как реализовать
            if (currentPlayerInd == game.RealPlayersCount)
            {
                for (int i = currentPlayerInd; i < game.PlayersCount; i++)
                {
                    if ((MoveNum < height * width) && (Winner == null))
                    {
                        game.Players[i].MakeMove(this);
                        MoveNum++;
                        //определяем победителя
                        Winner = GetWinner();
                        //проверяем ничью
                        IsDraw = CheckDraw();
                    }
                }
                currentPlayerInd = 0;
            }
        }


        private Player GetWinner()
        {
            var winnersLines = AllLines.SelectMany(
                lines => lines.Select(line => line)
                .Where(line => line.Length == lengthToWin)
                ).ToList();
            var winnerId = 0;
            if (winnersLines.Count != 0)
            {
                winnerId = winnersLines[0].Id;
                return game.Players[winnerId - 1];
            }

            return null;
        }

        private bool CheckDraw()
        {
            if ((MoveNum == width * height) && Winner == null)
                return true;
            return false;
        }

        private void EndLevel()
        {
            //завершение уровня
        }
    }
}
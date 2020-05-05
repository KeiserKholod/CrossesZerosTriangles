using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZT.Core;

namespace CZT.AI
{
    class Bot : IPlayer
    {
        private int winCoef;
        private int loseCoef;
        private int neutralCoef;
        private Random rnd = new Random();

        public readonly int BotID;
        public readonly string Name;
        private Game currentGame;

        public int Score { get; set; }

        string IPlayer.Name => Name;

        public int Id => BotID;

        public Bot(Game game, string name, int id)
        {
            winCoef = 10;
            loseCoef = -10;
            neutralCoef = 1;
            BotID = id;
            Name = name;
            currentGame = game;
        }

        public Bot(Game game, int id)
        {
            winCoef = 10;
            loseCoef = -10;
            neutralCoef = 1;
            BotID = id;
            Name = "Bot " + Id;
            currentGame = game;
        }

        public void CalculateBestMove()
        {

        }

        public void RandomMove()
        {
            var x = rnd.Next(0, currentGame.CurrentLevel.width);
            var y = rnd.Next(0, currentGame.CurrentLevel.height);
            var point = new Point(x, y, BotID);
            if (!currentGame.CurrentLevel.settedPoints.Contains(point))
            {
                currentGame.CurrentLevel.Map[x, y] = BotID;
                return;
            }
            else RandomMove();
        }

        public void MakeMove(Level level)
        {
            RandomMove();
        }
    }
}
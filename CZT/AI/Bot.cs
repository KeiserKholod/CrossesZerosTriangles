using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZT.Core;

namespace CZT.AI
{
    class Bot
    {
        private int winCoef;
        private int loseCoef;
        private int neutralCoef;
        private Random rnd = new Random();
        private Player player;

        public readonly int BotID;
        public readonly string Name;
        //private Level currentLevel;

        public Bot(string name, int id)
        {
            winCoef = 10;
            loseCoef = -10;
            neutralCoef = 1;
            BotID = id;
            Name = name;
        }

        public Bot(int id, Player player)
        {
            winCoef = 10;
            loseCoef = -10;
            neutralCoef = 1;
            BotID = id;
            Name = "Bot " + id;
            this.player = player;
        }

        public void CalculateBestMove()
        {

        }

        private void RandomMove(Level level)
        {
            var x = rnd.Next(0, level.width);
            var y = rnd.Next(0, level.height);
            while (level.Map[x, y] != 0)
            {
                x = rnd.Next(0, level.width);
                y = rnd.Next(0, level.height);
            }
            var point = new Point(x, y, BotID);
            if (!level.settedPoints.Contains(point))
            {
                level.Map[x, y] = BotID;
                level.Points.Add(point);
                level.settedPoints.Add(point);
                Line.Connect(player, level, point);
                return;
            }
            else RandomMove(level);
        }

        public void MakeMove(Level level)
        {
            RandomMove(level);
        }
    }
}
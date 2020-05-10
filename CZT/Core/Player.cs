﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CZT.AI;

namespace CZT.Core
{
    public class Player : IPlayer
    {
        private readonly String name;
        private readonly int id;
        private int score = 0;
        private List<Line> lines;
        private Bot botPlayer;
        public List<Line> Lines { get; set; }

        public int Score { get; set; }
        public string Name { get { return name; } }
        public int Id { get { return id; }}

        public Player(String name, int id)
        {
            this.id = id;
            this.name = name;
            Lines = new List<Line>();
            botPlayer = null;
        }

        public Player(int id)
        {
            this.id = id;
            this.name = "player " + Id;
            Lines = new List<Line>();
            botPlayer = new Bot(id, this);
        }

        public void MakeMove(Level level, int x, int y)
        {
            //закрашиваем магически выбранную клетку в Id игрока
            //добавляем линию?
            SetPoint(level, x, y);
            level.Map[x, y] = Id;
            //something
        }

        private void SetPoint(Level level, int x, int y)
        {
            var pointToSet = new Point(x, y, Id);
            level.Points.Add(pointToSet);
            level.settedPoints.Add(pointToSet);
            Line.Connect(this, level, pointToSet);
        }
        //для бота
        public void MakeMove(Level level)
        {
            //закрашиваем магически выбранную клетку в Id игрока
            //добавляем линию?
            botPlayer.MakeMove(level);
            //something
        }
    }
}
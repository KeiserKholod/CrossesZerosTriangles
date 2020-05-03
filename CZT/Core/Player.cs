using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    public class Player
    {
        public readonly String Name;
        public readonly int Id;
        private int score = 0;
        private List<Line> lines;
        public List<Line> Lines { get; set; }

        public int Score { get; set; }

        public Player(String name, int id)
        {
            Id = id;
            Name = name;
            Lines = new List<Line>();
        }

        public Player(int id)
        {
            Id = id;
            Name = "player " + Id;
        }

        public void MakeMove(Level level, int x, int y)
        {
            //закрашиваем магически выбранную клетку в Id игрока
            //добавляем линию?
            level.Map[x, y] = Id;
            //something
        }

        //для бота
        public void MakeMove(Level level)
        {
            //закрашиваем магически выбранную клетку в Id игрока
            //добавляем линию?
            level.Map[0, 0] = Id;
            //something
        }
    }
}
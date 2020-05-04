using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    public class Player : IPlayer
    {
        private readonly String name;
        private readonly int id;
        private int score = 0;
        private List<Line> lines;
        public List<Line> Lines { get; set; }

        public int Score { get; set; }
        public string Name { get { return name; } }
        public int Id { get { return id; }}

        public Player(String name, int id)
        {
            this.id = id;
            this.name = name;
            Lines = new List<Line>();
        }

        public Player(int id)
        {
            this.id = id;
            this.name = "player " + Id;
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
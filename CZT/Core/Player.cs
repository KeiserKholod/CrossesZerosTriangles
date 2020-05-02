using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    class Player
    {
        public readonly String Name;
        public readonly int Id;

        public Player(String name, int id)
        {
            Id = id;
            Name = name;
        }

        public Player(int id)
        {
            Id = id;
            Name = "player" + Id;
        }

        public void MakeMove(Game game)
        {
            int x = 0;
            int y = 0;
            //закрашиваем магически выбранную клетку в Id игрока
            game.Map[x, y] = Id;
            //something
        }
    }
}

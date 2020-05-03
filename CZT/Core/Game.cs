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
        private List<Level> levels;

        public List<Level> Levels
        {
            get
            {
                return levels;
            }
            private set
            {
                levels = value;
            }
        }


        public Game(int playersCount, int width, int height)
        {
            levels = new List<Level>();
            Players = new List<Player>();
            PreparePlayers(playersCount);
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

        private void EndGame()
        {
            //something
        }
    }
}

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
        public readonly int RealPlayersCount;
        public readonly int PlayersCount;

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


        public Game(int playersCount, int realPlayersCount)
        {
            levels = new List<Level>();
            Players = new List<Player>();
            RealPlayersCount = realPlayersCount;
            PlayersCount = playersCount;
            PreparePlayers();


        }

        public void StartLevel(int width, int height)
        {
            var level = new Level(this, width, height);
            Levels.Add(level);
        }

        //передавать список с именами живых игроков
        private void PreparePlayers(List<String> names)
        {
            for (int i = 0; i < RealPlayersCount; i++)
            {
                var player = new Player(names[i], i + 1);
            }
            //добавляем ботов
            for (int i = RealPlayersCount + 1; i <= PlayersCount - RealPlayersCount; i++)
            {
                var player = new Player(i);
                Players.Add(player);
            }
        }


        private void EndGame()
        {
            //something
        }
    }
}

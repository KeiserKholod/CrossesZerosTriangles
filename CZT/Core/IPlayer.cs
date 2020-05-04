using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZT.Core
{
    interface IPlayer
    {
        int Score { get; set; }
        string Name { get; }
        int Id { get; }

        void MakeMove(Level level);
    }
}

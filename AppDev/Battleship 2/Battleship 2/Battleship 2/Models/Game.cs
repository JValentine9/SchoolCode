using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_2.Models
{
    DataContract
    class Game
    {
        public Player Player1 = new Player { ShipsLeft = 5};
        public Player Player2 = new Player { ShipsLeft = 5};
    }
}

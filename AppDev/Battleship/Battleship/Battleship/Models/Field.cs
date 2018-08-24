using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    enum SquareState {Water, HitShip, Miss, SafeShip};

    class Field
    {
        public Ship Battleship = new Ship { };
        public SquareState[,] PlayArea = new SquareState[10, 10];
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_2.Models
{
    class Player
    {
        public Cell[,] Field = new Cell[10, 10];

        public Ship Battleship = new Ship { Name = "Battleship", Length = 4 };
        public Ship Carrier = new Ship { Name = "Carrier", Length = 5 };
        public Ship Cruiser = new Ship { Name = "Cruiser", Length = 3 };
        public Ship Submarine = new Ship { Name = "Submarine", Length = 3 };
        public Ship Destroyer = new Ship { Name = "Destroyer", Length = 2 };

        public bool hasWon;
    }
}

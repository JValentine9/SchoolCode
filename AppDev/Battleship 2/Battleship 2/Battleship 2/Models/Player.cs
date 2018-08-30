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

        public Ship Battleship = new Ship { Name = "Battleship", Health = 4};
        public Ship Carrier = new Ship { Name = "Carrier", Health = 5};
        public Ship Cruiser = new Ship { Name = "Cruiser", Health = 3 };
        public Ship Submarine = new Ship { Name = "Submarine", Health = 3 };
        public Ship Destroyer = new Ship { Name = "Destroyer", Health = 2 };
        public int ShipsLeft { get; set; }
    }
}

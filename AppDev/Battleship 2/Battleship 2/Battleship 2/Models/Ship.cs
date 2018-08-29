using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_2.Models
{
    class Ship
    {
        public string Name { get; set; }

        public bool IsSunk { get; set; }

        public bool IsPlaced { get; set; }

        public int Health { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battleship.Models
{
    class Ship
    {
        public string Name { get; set; }

        public int Length { get; set; }

        public bool IsVertical { get; set; }

        public bool IsSunk { get; set; }

        public int Start { get; set; }

        public int End { get; set; }
    }
}

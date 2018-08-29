using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Battleship_2.Models
{
    enum CellState { Water, Ship, Hit, Miss };


    class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CellState state;
        public Ship boundShip;

        public CellState State
        {
            get { return state; }
            set
            {
                state = value;
                FieldChanged();
            }
        }

        public void FieldChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

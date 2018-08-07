using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValentineJ_Conway.Models
{
    class Cell : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isLive;
        private int livingNeighbors = 0;

        public bool IsLive
        {
            get { return isLive; }
            set
            {
                isLive = value;
                FieldChanged();
            }
        }

        public int LivingNeighbors
        {
            get { return livingNeighbors; }
            set
            {
                livingNeighbors = value;
                FieldChanged();
            }
        }

        public void Toggle()
        {
            IsLive = !IsLive;
        }

        public void FieldChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public void CanILive()
        {
            if (livingNeighbors < 2 || livingNeighbors > 3)
            {
                isLive = false;
            }
            else if (livingNeighbors == 3)
            {
                isLive = true;
            }
        }
    }
}

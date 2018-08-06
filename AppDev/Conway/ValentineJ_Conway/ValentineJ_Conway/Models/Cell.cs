using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValentineJ_Conway.Models
{
    class Cell
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isLive;

        public bool IsLive
        {
            get { return isLive; }
            set
            {
                isLive = value;
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
    }
}

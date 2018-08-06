using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ValueConverterDemo.Models
{
    class LightBulb : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private bool isOn;

        public bool IsOn
        {
            get { return isOn; }
            set
            {
                isOn = value;
                FieldChanged();
            }
        }

        public void Toggle()
        {
            IsOn = !IsOn;
        }

        public void FieldChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}

using Battleship_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace Battleship_2.Converters
{
    public class ClassStatetoBrushConverter : IValueConverter
    {
        public static SolidColorBrush water = new SolidColorBrush(Colors.Blue);
        public static SolidColorBrush hit = new SolidColorBrush(Colors.Red);
        public static SolidColorBrush miss = new SolidColorBrush(Colors.White);
        public static SolidColorBrush ship = new SolidColorBrush(Colors.Gray);

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            CellState state = (CellState)value;

            switch (state)
            {
                case CellState.Water:
                    return water;
                case CellState.Hit:
                    return hit;
                case CellState.Miss:
                    return miss;
                case CellState.Ship:
                    return ship;
                default:
                    throw new InvalidCastException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}


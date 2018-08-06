using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ValueConverterDemo.Converters
{
    public class BoolToBrushConverter : IValueConverter
    {
        private static SolidColorBrush on = new SolidColorBrush(Colors.Orange);
        private static SolidColorBrush off = new SolidColorBrush(Colors.Purple);

        public object Convert(object value, Type targetType, object parameter, string language)
        { 
            bool state = (bool)value;

            return state ? on : off;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

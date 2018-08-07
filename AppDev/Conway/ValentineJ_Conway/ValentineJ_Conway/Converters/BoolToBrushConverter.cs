using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media;

namespace ValentineJ_Conway.Converters
{
        public class BoolToBrushConverter : IValueConverter
        {
            public static SolidColorBrush live = new SolidColorBrush(Colors.Green);
            public static SolidColorBrush dead = new SolidColorBrush(Colors.Red);

            public object Convert(object value, Type targetType, object parameter, string language)
            {
                bool state = (bool)value;

                return state ? live : dead;
            }

            public object ConvertBack(object value, Type targetType, object parameter, string language)
            {
                throw new NotImplementedException();
            }
        }
 }



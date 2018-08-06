using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ValueConverterDemo.Converters;
using ValueConverterDemo.Models;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ValueConverterDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private LightBulb bulb = new LightBulb();
        private bool isFlipped = false;

        public MainPage()
        {
            this.InitializeComponent();

            LightBulbRectangle.DataContext = bulb;
            BoolToBrushConverter con = new BoolToBrushConverter();

            Binding b = new Binding();
            b.Path = new PropertyPath("IsOn");
            b.Mode = BindingMode.OneWay;
            b.Converter = con;

            LightBulbRectangle.SetBinding(Shape.FillProperty, b);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bulb.Toggle();
        }
    }
}

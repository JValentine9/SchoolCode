using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Xaml.Shapes;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace ValentineJ_ShapeCanvas
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void ClearClick(object sender, RoutedEventArgs e)
        {
            PlayArea.Children.Clear();
            
        }

        private void MakeShape(object sender, TappedRoutedEventArgs e)
        {
            Random check = new Random();
            int number = check.Next(0,1);
            var R = Convert.ToByte(check.Next(0, 255));
            var G = Convert.ToByte(check.Next(0, 255));
            var B = Convert.ToByte(check.Next(0, 255));
            int Height = check.Next(1, 400);
            int Width = check.Next(1, 400);
            int x = check.Next(1, 500);
            int y = check.Next(1, 500);

            if (number == 1)
            {
                var rectangle = new Rectangle();
                rectangle.Fill = new SolidColorBrush(Color.FromArgb(255, R, G, B));
                rectangle.Width = Width;
                rectangle.Height = Height;

                PlayArea.Children.Add(rectangle);
                Canvas.SetTop(rectangle, x);
                Canvas.SetLeft(rectangle, y);
            }
            else
            {
                var ellipse1 = new Ellipse();
                ellipse1.Fill = new SolidColorBrush(Color.FromArgb(255, R, G, B));
                ellipse1.Width = Width;
                ellipse1.Height = Height;
                
                PlayArea.Children.Add(ellipse1);
                Canvas.SetTop(ellipse1, x);
                Canvas.SetLeft(ellipse1, y);
            }
            
        }
        private void DelShape(object sender, RightTappedRoutedEventArgs e)
        {
            var result = VisualTreeHelper.FindElementsInHostCoordinates(e.GetPosition(PlayArea), PlayArea);
            PlayArea.Children.Remove(result.First());
        }




    }


}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using ValentineJ_Conway.Converters;
using ValentineJ_Conway.Models;
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

namespace ValentineJ_Conway
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private int Rows;
        private int Columns;
        private double WaitTime;

        BoolToBrushConverter con = new BoolToBrushConverter();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Input_Click(object sender, RoutedEventArgs e)
        {
            Rows = int.Parse(RowInput.Text);
            Columns = int.Parse(ColumnInput.Text);

            if (Rows < 10 || Columns < 10)
            {
                ErrorBox.Text = "Input too low, minimum input is 10";
            }
            else if (Rows > 100 || Columns > 100)
            {
                ErrorBox.Text = "Input too high, maximum input is 100";
            }
            else
            {
                CreateGrid();
            }

            //FirstGen();
        }

        private void FirstGen()
        {
            throw new NotImplementedException();
        }

        private void CreateGrid()
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    Cell cell = new Cell();
                    Rectangle rect = new Rectangle();
                    rect.AddHandler(TappedEvent, new TappedEventHandler(flipcell), true);
                    rect.DataContext = cell;
                    Binding b = new Binding();
                    b.Path = new PropertyPath("IsLive");
                    b.Mode = BindingMode.OneWay;
                    b.Converter = con;
                    rect.SetBinding(Shape.FillProperty, b);

                    PlayArea.Children.Add(rect);
                    Grid.SetColumn(rect, y);
                    Grid.SetRow(rect, x);
                }
            }
        }

        private void flipcell(object sender, TappedRoutedEventArgs e)
        {
            var model = (Cell)((FrameworkElement)sender).DataContext;
            model.Toggle();
        }
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                WaitTime = slider.Value;
            }
        }

        private void RandPop_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PlayBall_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextGen_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}

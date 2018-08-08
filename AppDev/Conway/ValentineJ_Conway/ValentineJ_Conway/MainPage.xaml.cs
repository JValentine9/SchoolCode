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
using System.Threading;
using System.Threading.Tasks;

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
        private Cell[,] myCells;
        private Random rng = new Random();
        private bool Play = false;
        private DispatcherTimer time = new DispatcherTimer();

        BoolToBrushConverter con = new BoolToBrushConverter();

        public MainPage()
        {
            this.InitializeComponent();
            time.Tick += Time_Tick;
            time.Interval = new TimeSpan(100000/((long)WaitTime +1));
        }

        private void Time_Tick(object sender, object e)
        {
            nextGen();
        }

        /// <summary>
        /// On the input click, creates a grid based on the incoming info
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        }

        /// <summary>
        /// Creates the playgrid and the codebehind MyCell to dimensional grid
        /// </summary>
        private void CreateGrid()

        {
            PlayArea.Children.Clear();
            //PlayArea.Height = Rows;
            //PlayArea.Width = Columns;
            myCells = new Cell[Rows, Columns];
            for (int x = 0; x < Rows; x++)
            {
                PlayArea.RowDefinitions.Add(new RowDefinition());
            }
            for (int y=0; y < Columns; y++)
            {
                PlayArea.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int x = 0; x < Rows; x++)
            {
                
                for (int y = 0; y < Columns; y++)
                {
                    
                    Cell cell = new Cell();
                    myCells[x, y] = cell;
                    Button Cell = new Button();
                    Cell.Tapped += flipcell;
                    //Cell.AddHandler(TappedEvent, new TappedEventHandler(flipcell), true);
                    Cell.DataContext = cell;
                    Cell.Height = 50;
                    Cell.Width = 50;
                    Cell.BorderBrush = new SolidColorBrush(Colors.Black);
                    Cell.BorderThickness = new Thickness(2);
                    Binding b = new Binding
                    {
                        Path = new PropertyPath("IsLive"),
                        Mode = BindingMode.OneWay,
                        Converter = con
                    };
                    Cell.SetBinding(Button.BackgroundProperty, b);

                    PlayArea.Children.Add(Cell);
                    Grid.SetColumn(Cell, y);
                    Grid.SetRow(Cell, x);
                }
            }
        }

        /// <summary>
        /// Flips the statee of any given cell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void flipcell(object sender, TappedRoutedEventArgs e)
        {
            //var model = (sender as Button).DataContext;
            //model.Toggle();
            myCells[Grid.GetRow((Button)sender), Grid.GetColumn((Button)sender)].Toggle();
        }

        /// <summary>
        /// Takes in the new position of the slider
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Slider_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;
            if (slider != null)
            {
                WaitTime = slider.Value;
                time.Stop();
                time.Interval = new TimeSpan(100000 / ((long)WaitTime + 1));
                time.Start();
            }
        }

        /// <summary>
        /// On clicking the random population button, Randomly generates living cells
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RandPop_Click(object sender, RoutedEventArgs e)
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    if ((rng.Next(0, 2)) == 1)
                    {
                        myCells[x, y].IsLive = true;
                    }
                }
            }
        }

        /// <summary>
        /// sets the population to randomly advance generations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayBall_Click(object sender, RoutedEventArgs e)
        {
            
            time.Start();
        }

        /// <summary>
        /// On clicking the next button, runs nextGen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NextGen_Click(object sender, RoutedEventArgs e)
        {
            nextGen();
        }

        /// <summary>
        /// Steps through to the next generation
        /// </summary>
        private void nextGen()
        {
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    myCells[x, y].LivingNeighbors = 0;
                    //upper left
                    if (x == 0 && y == 0)
                    {
                        //Down to the Right
                        if (myCells[(x + 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //Bottom Right
                    else if (x == (myCells.GetLength(0)-1) && y == (myCells.GetLength(1) -1))
                    {
                        //Up to the Left
                        if (myCells[(x - 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //Top Right
                    else if (x == (myCells.GetLength(0) -1) && y == 0)
                    {
                        //Down to the Left
                        if (myCells[(x - 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //Bottom Left
                    else if (x == 0 && y == (myCells.GetLength(1) -1))
                    {
                        //Up to the Right
                        if (myCells[(x + 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }

                    }
                    //The Left
                    else if (x == 0)
                    {
                        //Up to the Right
                        if (myCells[(x + 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Right
                        if (myCells[(x + 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //The Right
                    else if (x == (myCells.GetLength(0) -1))
                    {
                        //Up to the Left
                        if (myCells[(x - 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Left
                        if (myCells[(x - 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //The Top
                    else if (y == 0)
                    {
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Left
                        if (myCells[(x - 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Right
                        if (myCells[(x + 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //The Bottom
                    //The Right
                    else if (y == (myCells.GetLength(1) -1))
                    {
                        //Up to the Left
                        if (myCells[(x - 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Up to the Right
                        if (myCells[(x + 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                    //Generic
                    else
                    {
                        //Up to the Right
                        if (myCells[(x + 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        ////Up
                        if (myCells[(x), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Up to the Left
                        if (myCells[(x - 1), (y - 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Right
                        if (myCells[(x + 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Left
                        if (myCells[(x - 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down
                        if (myCells[(x), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //To the Left
                        if (myCells[(x - 1), (y)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                        //Down to the Right
                        if (myCells[(x + 1), (y + 1)].IsLive)
                        {
                            myCells[x, y].LivingNeighbors++;
                        }
                    }
                }
            }
            for (int x = 0; x < Rows; x++)
            {
                for (int y = 0; y < Columns; y++)
                {
                    myCells[x, y].CanILive();
                }
            }
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            time.Stop();
        }
    }

}

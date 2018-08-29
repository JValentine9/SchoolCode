using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Battleship_2.Models;
using Windows.UI;
using Battleship_2.Converters;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Battleship_2.SubPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetupPage : Page
    {
        Game game = new Game();
        int ShipsToPlace = 5;
        bool FirstClick = false;
        int FirstClickX;
        int FirstClickY;
        int SecondClickX;
        int SecondClickY;
        bool IsVert;
        ClassStatetoBrushConverter con = new ClassStatetoBrushConverter();

        public SetupPage()
        {
            this.InitializeComponent();
            MakeGrid();

        }

        private void MakeGrid()
        {
            PlayArea.Children.Clear();
            for (int x = 0; x < 10; x++)
            {

                for (int y = 0; y < 10; y++)
                {

                    Cell cell = new Cell();
                    game.Player1.Field[x, y] = cell;
                    Button Cell = new Button();
                    Cell.Tapped += SelectBoi;
                    Cell.DataContext = cell;
                    Cell.Height = 50;
                    Cell.Width = 50;
                    Cell.BorderBrush = new SolidColorBrush(Colors.Black);
                    Cell.BorderThickness = new Thickness(2);
                    Binding b = new Binding
                    {
                        Path = new PropertyPath("State"),
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

        private void SelectBoi(object sender, TappedRoutedEventArgs e)
        {
            if (!(ShipsToPlace >= 1))
            {
                var ClickedBoi = (Button)sender;
                FirstClick = !FirstClick;
                if (FirstClick)
                {
                    FirstClickX = (int)ClickedBoi.GetValue(Grid.ColumnProperty);
                    FirstClickY = (int)ClickedBoi.GetValue(Grid.RowProperty);
                    game.Player1.Field[Grid.GetRow((Button)sender), Grid.GetColumn((Button)sender)].State = CellState.Ship;
                }
                else
                {
                    SecondClickX = (int)ClickedBoi.GetValue(Grid.ColumnProperty);
                    SecondClickY = (int)ClickedBoi.GetValue(Grid.RowProperty);
                    if (SecondClickX == FirstClickX && SecondClickY == FirstClickY)
                    {
                        game.Player1.Field[Grid.GetRow((Button)sender), Grid.GetColumn((Button)sender)].State = CellState.Water;
                        FirstClick = !FirstClick;
                    }
                    else if ((SecondClickX != FirstClickX) ^ (SecondClickX != FirstClickY))
                    {
                        if (SecondClickX == FirstClickX)
                        {
                            IsVert = true;
                        }
                        else
                        {
                            IsVert = false;
                        }
                        switch(ShipsToPlace)
                        {
                            case 5: //Carrier 5
                                if(IsVert)
                                {
                                    int length = Math.Abs(SecondClickX - FirstClickX);
                                    if (length == 5)
                                    {
                                        if ((FirstClickX - SecondClickX) < 0)
                                        {
                                            for (int i = (SecondClickX - FirstClickX); i < SecondClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickX - SecondClickX); i < FirstClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                else
                                {
                                    int length = Math.Abs(SecondClickY - FirstClickY);
                                    if (length == 5)
                                    {
                                        if ((FirstClickY - SecondClickY) < 0)
                                        {
                                            for (int i = (SecondClickY - FirstClickY); i < SecondClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickY - SecondClickY); i < FirstClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                break;
                            case 4: //Battleship 4
                                if (IsVert)
                                {
                                    int length = Math.Abs(SecondClickX - FirstClickX);
                                    if (length == 4)
                                    {
                                        if ((FirstClickX - SecondClickX) < 0)
                                        {
                                            for (int i = (SecondClickX - FirstClickX); i < SecondClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickX - SecondClickX); i < FirstClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                else
                                {
                                    int length = Math.Abs(SecondClickY - FirstClickY);
                                    if (length == 4)
                                    {
                                        if ((FirstClickY - SecondClickY) < 0)
                                        {
                                            for (int i = (SecondClickY - FirstClickY); i < SecondClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickY - SecondClickY); i < FirstClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                break;
                            case 3: //Cruiser 3
                                if (IsVert)
                                {
                                    int length = Math.Abs(SecondClickX - FirstClickX);
                                    if (length == 3)
                                    {
                                        if ((FirstClickX - SecondClickX) < 0)
                                        {
                                            for (int i = (SecondClickX - FirstClickX); i < SecondClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickX - SecondClickX); i < FirstClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                else
                                {
                                    int length = Math.Abs(SecondClickY - FirstClickY);
                                    if (length == 3)
                                    {
                                        if ((FirstClickY - SecondClickY) < 0)
                                        {
                                            for (int i = (SecondClickY - FirstClickY); i < SecondClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickY - SecondClickY); i < FirstClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                break;
                            case 2: //Submarine 3
                                if (IsVert)
                                {
                                    int length = Math.Abs(SecondClickX - FirstClickX);
                                    if (length == 3)
                                    {
                                        if ((FirstClickX - SecondClickX) < 0)
                                        {
                                            for (int i = (SecondClickX - FirstClickX); i < SecondClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickX - SecondClickX); i < FirstClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                            ShipsToPlace--; 
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                else
                                {
                                    int length = Math.Abs(SecondClickY - FirstClickY);
                                    if (length == 3)
                                    {
                                        if ((FirstClickY - SecondClickY) < 0)
                                        {
                                            for (int i = (SecondClickY - FirstClickY); i < SecondClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickY - SecondClickY); i < FirstClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                break;
                            case 1: //Destroyer 2
                                if (IsVert)
                                {
                                    int length = Math.Abs(SecondClickX - FirstClickX);
                                    if (length == 2)
                                    {
                                        if ((FirstClickX - SecondClickX) < 0)
                                        {
                                            for (int i = (SecondClickX - FirstClickX); i < SecondClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickX - SecondClickX); i < FirstClickX; i++)
                                            {
                                                game.Player1.Field[i, FirstClickY].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                else
                                {
                                    int length = Math.Abs(SecondClickY - FirstClickY);
                                    if (length == 2)
                                    {
                                        if ((FirstClickY - SecondClickY) < 0)
                                        {
                                            for (int i = (SecondClickY - FirstClickY); i < SecondClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                        else
                                        {
                                            for (int i = (FirstClickY - SecondClickY); i < FirstClickY; i++)
                                            {
                                                game.Player1.Field[FirstClickX, i].State = CellState.Ship;
                                            }
                                            game.Player1.Field[SecondClickX, FirstClickY].State = CellState.Ship;
                                        }
                                    }
                                    else
                                    {
                                        game.Player1.Field[FirstClickX, FirstClickY].State = CellState.Water;
                                        FirstClick = !FirstClick;
                                    }
                                }
                                break;
                        }
                    }
                }
                
            }
            else
            {
                GenAIShips();
            }
            switch (ShipsToPlace)
            {
                case 5:
                    SetDisplay.Text = "Carrier. 5 Spaces Long";
                    break;
                case 4:
                    SetDisplay.Text = "Battleship, 4 Spaces Long";
                    break;
                case 3:
                    SetDisplay.Text = "Cruiser, 3 Spaces Long";
                    break;
                case 2:
                    SetDisplay.Text = "Submarine, 3 Spaces Long";
                    break;
                case 1:
                    SetDisplay.Text = "Destroyer, 2 Spaces Long";
                    break;
                default:
                    SetDisplay.Text = "All Done! Hit Ready to Play!";
                    break;
                   
            }
        }

        private void GenAIShips()
        {
            throw new NotImplementedException();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (ShipsToPlace == 0)
            {
                this.Frame.Navigate(typeof(SubPages.SetupPage), game);
            }
        }
    }
}

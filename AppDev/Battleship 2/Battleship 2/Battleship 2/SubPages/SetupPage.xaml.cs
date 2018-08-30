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
    enum Shiptype { Carrier, Battleship, Cruiser, Submarine, Destroyer};

    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SetupPage : Page
    {
        Game game = new Game(); //Game Object for movement of data
        int ShipsToPlace = 5; //Remaining Ships to Place for Human
        int AIShipsToPlace = 5; //Remaining Ships to Place for AI
        Shiptype slcShip;
        int x;
        int y;
        bool IsValid;
        bool IsVert;
        Random rand = new Random();
        ClassStatetoBrushConverter con = new ClassStatetoBrushConverter(); //converter for CellState to Color for the buttons
        bool Pass = true;

        public SetupPage() //Sets up the page
        {
            this.InitializeComponent(); //generates C# code from UWP Xaml document
            MakeGrid(); //Make the placement grid
            Ready.IsEnabled = false;

        }

        private void MakeGrid() //makes the grid for Ship Placement
        {
            //PlayArea.Children.Clear(); //clears the grid, just in case
            for (int x = 0; x < 10; x++) //looping 10 times x
            {

                for (int y = 0; y < 10; y++) //looping 10 times y
                {

                    Cell cell = new Cell(); //Creating cell object for binding
                    game.Player1.Field[x, y] = cell; //placing cell object in Player1's field
                    Button Cell = new Button(); //creates button
                    Cell.Tapped += SelectBoi; //adds on tap method SelectBoi
                    Cell.DataContext = cell; // sets the cell as the datacontext of the button
                    Cell.Height = 50; // i leik squares
                    Cell.Width = 50; // i leik squares
                    Cell.BorderBrush = new SolidColorBrush(Colors.Black); //give some definition
                    Cell.BorderThickness = new Thickness(2); // more of dat definition
                    Binding b = new Binding //set binding
                    {
                        Path = new PropertyPath("State"), //get that state-based binding for color
                        Mode = BindingMode.OneWay, // don't want two way communication. Communtication bad
                        Converter = con //use my converter binding boi
                    };
                    Cell.SetBinding(Button.BackgroundProperty, b); //Bind the binding to the bound button of bindingness. bind

                    PlayArea.Children.Add(Cell); //make sure the button is in the grid
                    Grid.SetColumn(Cell, y); // gitcho place boiiiii place on y
                    Grid.SetRow(Cell, x); //place on x
                }
            }
        }

        private void SelectBoi(object sender, TappedRoutedEventArgs e) //on button click within the grid, starts trying to place ships in order
        {
            var spot = (Button)sender;
            y = (int)spot.GetValue(Grid.ColumnProperty);
            x = (int)spot.GetValue(Grid.RowProperty);
            switch (slcShip)
            {
                case Shiptype.Carrier:
                    if (!game.Player1.Carrier.IsPlaced)
                    {
                        if (IsVert)
                        {
                            if (!(y + 5 > 10))
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (!(game.Player1.Field[x, y + i].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        game.Player1.Field[x, y + i].State = CellState.Ship;
                                        game.Player1.Field[x, y + i].boundShip = game.Player1.Carrier;
                                        game.Player1.Carrier.IsPlaced = true;

                                    }
                                    ShipsToPlace--;
                                    Carrier.IsEnabled = false;
                                }

                            }
                        }
                        else
                        {
                            if (!(x + 5 > 10))
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    if (!(game.Player1.Field[x + i, y].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 5; i++)
                                    {
                                        game.Player1.Field[x + i, y].State = CellState.Ship;
                                        game.Player1.Field[x + i, y].boundShip = game.Player1.Carrier;
                                        game.Player1.Carrier.IsPlaced = true;
                                    }
                                    ShipsToPlace--;
                                    Carrier.IsEnabled = false;
                                }

                            }
                        }
                    }
                    break;
                case Shiptype.Cruiser:
                    if (!game.Player1.Cruiser.IsPlaced)
                    {
                        if (IsVert)
                        {
                            if (!(y + 3 > 10))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (!(game.Player1.Field[x, y + i].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        game.Player1.Field[x, y + i].State = CellState.Ship;
                                        game.Player1.Field[x, y + i].boundShip = game.Player1.Cruiser;
                                        game.Player1.Cruiser.IsPlaced = true;
                                    }
                                    ShipsToPlace--;
                                    Cruiser.IsEnabled = false;
                                }

                            }
                        }
                        else
                        {
                            if (!(x + 3 > 10))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (!(game.Player1.Field[x + i, y].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        game.Player1.Field[x + i, y].State = CellState.Ship;
                                        game.Player1.Field[x + i, y].boundShip = game.Player1.Cruiser;
                                        game.Player1.Cruiser.IsPlaced = true;
                                    }
                                    ShipsToPlace--;
                                    Cruiser.IsEnabled = false;
                                }

                            }
                        }
                    }
                    break;
                case Shiptype.Battleship:
                    if (!game.Player1.Battleship.IsPlaced)
                    {
                        if (IsVert)
                        {
                            if (!(y + 4 > 10))
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (!(game.Player1.Field[x, y + i].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        game.Player1.Field[x, y + i].State = CellState.Ship;
                                        game.Player1.Field[x, y + i].boundShip = game.Player1.Battleship;
                                        game.Player1.Battleship.IsPlaced = true;
                                    }

                                    ShipsToPlace--;
                                    Battleship.IsEnabled = false;
                                }

                            }
                        }
                        else
                        {
                            if (!(x + 4 > 10))
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (!(game.Player1.Field[x + i, y].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 4; i++)
                                    {
                                        game.Player1.Field[x + i, y].State = CellState.Ship;
                                        game.Player1.Field[x + i, y].boundShip = game.Player1.Battleship;
                                        game.Player1.Battleship.IsPlaced = true;
                                    }
                                    ShipsToPlace--;
                                    Battleship.IsEnabled = false;

                                }

                            }
                        }
                    }
                    break;
                case Shiptype.Submarine:
                    if (!game.Player1.Submarine.IsPlaced)
                    {
                        if (IsVert)
                        {
                            if (!(y + 3 > 10))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (!(game.Player1.Field[x, y + i].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        game.Player1.Field[x, y + i].State = CellState.Ship;
                                        game.Player1.Field[x, y + i].boundShip = game.Player1.Submarine;
                                        game.Player1.Submarine.IsPlaced = true;

                                    }
                                    ShipsToPlace--;
                                    Submarine.IsEnabled = false;

                                }

                            }
                        }
                        else
                        {
                            if (!(x + 3 > 10))
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (!(game.Player1.Field[x + i, y].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 3; i++)
                                    {
                                        game.Player1.Field[x + i, y].State = CellState.Ship;
                                        game.Player1.Field[x + i, y].boundShip = game.Player1.Submarine;
                                        game.Player1.Submarine.IsPlaced = true;
                                    }

                                    ShipsToPlace--;
                                    Submarine.IsEnabled = false;
                                }

                            }
                        }
                    }
                    break;
                case Shiptype.Destroyer:
                    if (!game.Player1.Destroyer.IsPlaced)
                    {
                        if (IsVert)
                        {
                            if (!(y + 2 > 10))
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (!(game.Player1.Field[x, y + i].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        game.Player1.Field[x, y + i].State = CellState.Ship;
                                        game.Player1.Field[x, y + i].boundShip = game.Player1.Destroyer;
                                        game.Player1.Destroyer.IsPlaced = true;
                                    }

                                    ShipsToPlace--;
                                    Destroyer.IsEnabled = false;
                                }

                            }
                        }
                        else
                        {
                            if (!(x + 2 > 10))
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (!(game.Player1.Field[x + i, y].State == CellState.Ship))
                                    {
                                        IsValid = true;
                                    }
                                    else
                                    {
                                        IsValid = false;
                                        break;
                                    }

                                }
                                if (IsValid)
                                {
                                    for (int i = 0; i < 2; i++)
                                    {
                                        game.Player1.Field[x + i, y].State = CellState.Ship;
                                        game.Player1.Field[x + i, y].boundShip = game.Player1.Destroyer;
                                        game.Player1.Destroyer.IsPlaced = true;
                                    }
                                    ShipsToPlace--;
                                    Destroyer.IsEnabled = false;
                                }

                            }
                        }
                    }
                    break;
                default:
                    break;
            }

            if (ShipsToPlace == 0)
            {
                Ready.IsEnabled = true;
            }

        }

        private void GenAIShips()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    game.Player2.Field[x, y] = new Cell();
                }
            }
            Pass = false;
            do
            {
                if (rand.Next(0, 2) == 0)
                {
                    IsVert = false;
                }
                else
                {
                    IsVert = true;
                }

                x = rand.Next(0, 10);
                y = rand.Next(0, 10);
                //Carrier

                if (IsVert)
                {
                    if (!(y + 5 > 10))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (!(game.Player2.Field[x, y + i].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                game.Player2.Field[x, y + i].State = CellState.Ship;
                                game.Player2.Field[x, y + i].boundShip = game.Player2.Carrier;
                                game.Player2.Carrier.IsPlaced = true;
                            }
                        }

                    }
                }
                else
                {
                    if (!(x + 5 > 10))
                    {
                        for (int i = 0; i < 5; i++)
                        {
                            if (!(game.Player2.Field[x + i, y].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 5; i++)
                            {
                                game.Player2.Field[x + i, y].State = CellState.Ship;
                                game.Player2.Field[x + i, y].boundShip = game.Player2.Carrier;
                                game.Player2.Carrier.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
            } while (!Pass);
            //Cruiser
            Pass = false;
            do
            {
                if (rand.Next(0, 2) == 0)
                {
                    IsVert = false;
                }
                else
                {
                    IsVert = true;
                }

                x = rand.Next(0, 10);
                y = rand.Next(0, 10);

                if (IsVert)
                {
                    if (!(y + 3 > 10))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!(game.Player2.Field[x, y + i].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                game.Player2.Field[x, y + i].State = CellState.Ship;
                                game.Player2.Field[x, y + i].boundShip = game.Player2.Cruiser;
                                game.Player2.Cruiser.IsPlaced = true;
                            }
                        }

                    }
                }
                else
                {
                    if (!(x + 3 > 10))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!(game.Player2.Field[x + i, y].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                game.Player2.Field[x + i, y].State = CellState.Ship;
                                game.Player2.Field[x + i, y].boundShip = game.Player2.Cruiser;
                                game.Player2.Cruiser.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
            } while (!Pass);
            //Battleship
            Pass = false;
            do
            {
                if (rand.Next(0, 2) == 0)
                {
                    IsVert = false;
                }
                else
                {
                    IsVert = true;
                }

                x = rand.Next(0, 10);
                y = rand.Next(0, 10);

                if (IsVert)
                {
                    if (!(y + 4 > 10))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (!(game.Player2.Field[x, y + i].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                game.Player2.Field[x, y + i].State = CellState.Ship;
                                game.Player2.Field[x, y + i].boundShip = game.Player2.Battleship;
                                game.Player2.Battleship.IsPlaced = true;
                            }
                        }

                    }
                }
                else
                {
                    if (!(x + 4 > 10))
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            if (!(game.Player2.Field[x + i, y].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                game.Player2.Field[x + i, y].State = CellState.Ship;
                                game.Player2.Field[x + i, y].boundShip = game.Player2.Battleship;
                                game.Player2.Battleship.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
            } while (!Pass);
            //Submarine
            Pass = false;
            do
            {
                if (rand.Next(0, 2) == 0)
                {
                    IsVert = false;
                }
                else
                {
                    IsVert = true;
                }

                x = rand.Next(0, 10);
                y = rand.Next(0, 10);
                if (IsVert)
                {
                    if (!(y + 3 > 10))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!(game.Player2.Field[x, y + i].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                game.Player2.Field[x, y + i].State = CellState.Ship;
                                game.Player2.Field[x, y + i].boundShip = game.Player2.Submarine;
                                game.Player2.Submarine.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
                else
                {
                    if (!(x + 3 > 10))
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            if (!(game.Player2.Field[x + i, y].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 3; i++)
                            {
                                game.Player2.Field[x + i, y].State = CellState.Ship;
                                game.Player2.Field[x + i, y].boundShip = game.Player2.Submarine;
                                game.Player2.Submarine.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
            } while (!Pass);
            //Destroyer
            Pass = false;
            do
            {
                if (rand.Next(0, 2) == 0)
                {
                    IsVert = false;
                }
                else
                {
                    IsVert = true;
                }

                x = rand.Next(0, 10);
                y = rand.Next(0, 10);
                if (IsVert)
                {
                    if (!(y + 2 > 10))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (!(game.Player2.Field[x, y + i].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                game.Player2.Field[x, y + i].State = CellState.Ship;
                                game.Player2.Field[x, y + i].boundShip = game.Player2.Destroyer;
                                game.Player2.Destroyer.IsPlaced = true;
                            }
                        }

                    }
                }
                else
                {
                    if (!(x + 2 > 10))
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (!(game.Player2.Field[x + i, y].State == CellState.Ship))
                            {
                                IsValid = true;
                            }
                            else
                            {
                                IsValid = false;
                                break;
                            }

                        }
                        if (IsValid)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                game.Player2.Field[x + i, y].State = CellState.Ship;
                                game.Player2.Field[x + i, y].boundShip = game.Player2.Destroyer;
                                game.Player2.Destroyer.IsPlaced = true;
                                Pass = true;
                            }
                        }

                    }
                }
            } while (!Pass);
        }

      

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
                GenAIShips();
                this.Frame.Navigate(typeof(SubPages.GamePage), game);
            
        }

        private void Ship_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton rb = sender as RadioButton;

            if (rb != null)
            {
                string shipname = rb.Tag.ToString();
                switch (shipname)
                {
                    case "Carrier":
                        slcShip = Shiptype.Carrier;
                        break;
                    case "Cruiser":
                        slcShip = Shiptype.Cruiser;
                        break;
                    case "Battleship":
                        slcShip = Shiptype.Battleship;
                        break;
                    case "Submarine":
                        slcShip = Shiptype.Submarine;
                        break;
                    case "Destroyer":
                        slcShip = Shiptype.Destroyer;
                        break;
                }
            }
        }

        private void IsVert_Checked(object sender, RoutedEventArgs e)
        {
            IsVert = true;

        }
        private void IsVert_Unchecked(object sender, RoutedEventArgs e)
        {
            IsVert = false;

        }
    }
}

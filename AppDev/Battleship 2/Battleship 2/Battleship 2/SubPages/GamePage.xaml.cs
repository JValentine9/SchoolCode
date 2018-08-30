using Battleship_2.Converters;
using Battleship_2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Runtime.Serialization;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Battleship_2.SubPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        Game game;
        ClassStatetoBrushConverter con = new ClassStatetoBrushConverter();
        int x;
        int y;
        Random rand = new Random();

        public GamePage()
        {
            this.InitializeComponent();
            
        }

        private void CreateGrids()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    //player Field
                    Button Cell = new Button(); //creates button
                    Cell.DataContext = game.Player1.Field[x, y]; // sets the cell as the datacontext of the button
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

                    Player1Area.Children.Add(Cell); //make sure the button is in the grid
                    Grid.SetColumn(Cell, y); // gitcho place boiiiii place on y
                    Grid.SetRow(Cell, x); //place on x  

                    //AI Field
                    Button Cell2 = new Button(); //creates button
                    Cell2.Tapped += AISelectBoi; //adds on tap method SelectBoi
                    Cell2.DataContext = game.Player2.Field[x, y]; // sets the cell as the datacontext of the button
                    Cell2.Height = 50; // i leik squares
                    Cell2.Width = 50; // i leik squares
                    Cell2.BorderBrush = new SolidColorBrush(Colors.Black); //give some definition
                    Cell2.BorderThickness = new Thickness(2); // more of dat definition
                    Binding b2 = new Binding //set binding
                    {
                        Path = new PropertyPath("State"), //get that state-based binding for color
                        Mode = BindingMode.OneWay, // don't want two way communication. Communtication bad
                        Converter = con //use my converter binding boi
                    };
                    Cell2.SetBinding(Button.BackgroundProperty, b2); //Bind the binding to the bound button of bindingness. bind

                    Player2Area.Children.Add(Cell2); //make sure the button is in the grid
                    Grid.SetColumn(Cell2, y); // gitcho place boiiiii place on y
                    Grid.SetRow(Cell2, x); //place on x
                }
                                                  
            }
            
        } //TODO fix binding

        private void AISelectBoi(object sender, TappedRoutedEventArgs e)
        {
            var Click = (Button)sender;
            if (PlayerMove(Click))
            {
                AIMove();
            }
        }

        private void AIMove()
        {
            do
            {
                x = rand.Next(0, 10);
                y = rand.Next(0, 10);
            } while (game.Player1.Field[x, y].Struck == true);

            if (game.Player1.Field[x, y].State == CellState.Ship)
            {
                game.Player1.Field[x, y].State = CellState.Hit;
                game.Player1.Field[x, y].boundShip.Health--;
                if (game.Player1.Field[x, y].boundShip.Health == 0)
                {
                    game.Player1.ShipsLeft--;
                    WhoHit.Text = $"Player 2 sunk your {game.Player1.Field[x, y].boundShip.Name}";
                }
                else
                {
                    WhoHit.Text = $"Player 2 hit your {game.Player1.Field[x, y].boundShip.Name}";
                }
            }
            else if (game.Player1.Field[x, y].State == CellState.Water)
            {
                game.Player1.Field[x, y].State = CellState.Miss;
                WhoHit.Text = $"Player 2 Missed";
            }
            else
            {
                WhoHit.Text = $"Invalid Target";
            }
            if (!Hit.IsOpen) { Hit.IsOpen = true; }
            if (game.Player1.ShipsLeft == 0)
            {
                WhoHit.Text = "Player 2 Won!";
            }
        } 

        private bool PlayerMove(Button click)
        {
            bool ValidShot = false;
            y = (int)click.GetValue(Grid.ColumnProperty);
            x = (int)click.GetValue(Grid.RowProperty);
            if (game.Player2.Field[x,y].State == CellState.Ship)
            {
                game.Player2.Field[x, y].State = CellState.Hit;
                game.Player2.Field[x, y].boundShip.Health--;
                if (game.Player2.Field[x, y].boundShip.Health == 0)
                {
                    game.Player2.ShipsLeft--;
                    WhoHit.Text = $"You sunk Player 2's {game.Player2.Field[x, y].boundShip.Name}";
                    ValidShot = true;
                }
                else
                {
                    WhoHit.Text = $"You hit Player 2's {game.Player2.Field[x, y].boundShip.Name}";
                    ValidShot = true;
                }
            }
            else if (game.Player2.Field[x, y].State == CellState.Water)
            {
                game.Player2.Field[x, y].State = CellState.Miss;
                WhoHit.Text = $"You Missed";
                ValidShot = true;
            }
            else
            {
                ;
            }
            if (!Hit.IsOpen) {Hit.IsOpen = true; }
            if (game.Player2.ShipsLeft == 0)
            {
                WhoHit.Text = "You win! You sank all of Player 2's Ships!";
            }
            return ValidShot;
        }

        private void CloseHit (object sender, RoutedEventArgs e)
        {
            if (Hit.IsOpen) { Hit.IsOpen = false; }
        }

        private void SelectBoi(object sender, TappedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            game = (Game)e.Parameter;
            CreateGrids();
        }
    


    string contents;
        private async void Save_ClickAsync(object sender, RoutedEventArgs e)
        {
            var savepicker = new FileSavePicker();
            savepicker.FileTypeChoices.Add("", new List<string> { ".cont" });
            StorageFile file = await savepicker.PickSaveFileAsync();
            if (file != null)
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Game));
                contents = "";
                using (var stream = new MemoryStream())
                {
                    ser.WriteObject(stream, game);
                    stream.Seek(0, SeekOrigin.Begin);
                    using (var streamreader = new StreamReader(stream))
                    {
                        contents = streamreader.ReadToEnd();
                    }
                }
            }
            await FileIO.WriteTextAsync(file, contents);
        }
    }
}

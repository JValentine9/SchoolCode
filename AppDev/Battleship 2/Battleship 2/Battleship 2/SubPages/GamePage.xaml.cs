using Battleship_2.Converters;
using Battleship_2.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Battleship_2.SubPages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage : Page
    {
        Game game = new Game();
        ClassStatetoBrushConverter con = new ClassStatetoBrushConverter();

        public GamePage()
        {
            this.InitializeComponent();
            CreateGrids();
        }

        private void CreateGrids()
        {
            for (int x = 0; x < 10; x++)
            {
                for (int y = 0; y < 10; y++)
                {
                    //player
                    Button Cell = new Button(); //creates button
                    Cell.Tapped += SelectBoi; //adds on tap method SelectBoi
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

                    //AI
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
            
        }

        private void AISelectBoi(object sender, TappedRoutedEventArgs e)
        {
            var Click = (Button)sender;
            PlayerMove(Click);
            AIMove();
        }

        private void AIMove()
        {
            throw new NotImplementedException();
        } 

        private void PlayerMove(Button click)
        {
            throw new NotImplementedException();
        }

        private void SelectBoi(object sender, TappedRoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
        
    

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            game = (Game)e.Parameter;
        }
    }
}

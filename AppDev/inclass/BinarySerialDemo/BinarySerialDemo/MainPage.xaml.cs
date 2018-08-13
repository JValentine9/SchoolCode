using System;
using ProtoBuf;
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
using BinarySerialDemo.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace BinarySerialDemo
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //Movies movie = new Movies() { Title = "The Prestige", Year = 2006, Director = "Christopher Nolan", Runtime = 130 };
            List<Movies> movies = new List<Movies>()
            {
                new Movies() { Title = "The Prestige", Year = 2006, Director = "Christopher Nolan", Runtime = 130 },
                new Movies() { Title = "Star Wars", Year = 1977, Director = "George Lucas", Runtime = 125 },
                new Movies() { Title = "The Empire Strikes Back", Year = 1980, Director = "Irvin Kershner", Runtime = 127 },
                new Movies() { Title = "The Return of the Jedi", Year = 1983, Director = "Richard Marquand", Runtime = 136 },

            };
            String path = "test.txt";

            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                Serializer.Serialize<List<Movies>>(fs, movies);
            }

            movies.Clear();

            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                movies = Serializer.Deserialize<List<Movies>>(fs);
            }

                Console.WriteLine(movies);
             
        }
    }
}

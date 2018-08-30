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
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation; 

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Battleship_2
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        Game game;

        public MainPage()
        {
            this.InitializeComponent();
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(SubPages.SetupPage));
        }

        private void LoadClick(object sender, RoutedEventArgs e)
        {
            LoadGameAsync();
            this.Frame.Navigate(typeof(SubPages.SetupPage), game);
        }

        private async void LoadGameAsync()
        {
            var savepicker = new FileSavePicker();
            savepicker.FileTypeChoices.Add("", new List<string> { ".cont" });
            StorageFile file = await savepicker.PickSaveFileAsync();
            if (file != null)
            {
                DataContractSerializer ser = new DataContractSerializer(typeof(Game));
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
        }
    }
}

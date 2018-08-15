using Contact_Manager.Models;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Contact_Manager
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Contact> contacts = new List<Contact>();
        private List<string> eTypes = new List<string>();
        private List<string> pTypes = new List<string>();
        private string SavePath = "";
        private string OpenPath = "";
        private string CurrentContact = "";

        public MainPage()
        {
            this.InitializeComponent();

            ContactsListView.ItemsSource = contacts;

            eTypes.Add("Work");
            eTypes.Add("Personal");

            pTypes.Add("Work");
            pTypes.Add("Personal");
            pTypes.Add("Home");
        }

        private void AddContact_Click(object sender, RoutedEventArgs e)
        {
            if (!AddPopup.IsOpen) { AddPopup.IsOpen = true; }
        }

        private void AddAndSave_Click(object sender, RoutedEventArgs e)
        {
            EmailType EType = Models.EmailType.Personal;
            PhoneType PType = Models.PhoneType.Personal;
            string Pvar;
            string Evar;
            
            Pvar = PhoneType.SelectedItem as string;
            Evar = EmailType.SelectedItem as string;

            switch (Pvar)
            {
                case "Personal":
                    PType = Models.PhoneType.Personal;
                    break;
                case "Home":
                    PType = Models.PhoneType.Home;
                    break;
                case "Work":
                    PType = Models.PhoneType.Work;
                    break;
                default:
                    break;
            }

            switch (Evar)
            {
                case "Personal":
                    EType = Models.EmailType.Personal;
                    break;
                case "Work":
                    EType = Models.EmailType.Work;
                    break;
                default:
                    break;
            }

            contacts.Add(new Contact() { Name = NameInput.Text, Phone = new PhoneNumber() { Number = PhoneInput.Text, Type = PType }, EmailAddress = new Email() { Address = EmailInput.Text, Type = EType } });
            if (AddPopup.IsOpen) { AddPopup.IsOpen = false; }
            ContactsListView.ItemsSource = null;
            ContactsListView.ItemsSource = contacts;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if(SavePath == "")
            {
                if (!SaveAsPopup.IsOpen) { SaveAsPopup.IsOpen = true; }
            }
            else
            {
                Save();
            }
        }

        private void SaveAs_Click(object sender, RoutedEventArgs e)
        {
            if (!SaveAsPopup.IsOpen) { SaveAsPopup.IsOpen = true; }
        }
        private void FinalSave_Click(object sender, RoutedEventArgs e)
        {
            SavePath = SavePathInput.Text;
            Save();
            if (SaveAsPopup.IsOpen) { SaveAsPopup.IsOpen = false; }
        }
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            OpenPath = OpenPathInput.Text;
            using (FileStream fs = new FileStream(OpenPath, FileMode.Open))
            {
                contacts = Serializer.Deserialize<List<Contact>>(fs);
            }
            if (OpenPopup.IsOpen) { OpenPopup.IsOpen = false; }
        }

        private void Open_Click(object sender, RoutedEventArgs e)
        {
            if (!OpenPopup.IsOpen) { OpenPopup.IsOpen = true; }
        }

        private void Save()
        {
            using (FileStream fs = new FileStream(SavePath, FileMode.Create))
            {
                Serializer.Serialize<List<Contact>>(fs, contacts);
            }
        }

        private void DisplayContact(object sender, SelectionChangedEventArgs e)
        {
            CurrentContact = "";
            ContactDisplay.Text = ((ListView)sender).SelectedItem.ToString(); ;
        }
    }
}

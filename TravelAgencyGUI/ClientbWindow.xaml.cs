using System;
using System.Windows;
using TravelAgency;

namespace TravelAgencyGUI
{
    /// <summary>
    /// Logika interakcji dla klasy ClientbWindow.xaml
    /// </summary>
    public partial class ClientbWindow : Window
    {
        Client_booked _client = new Client_booked();
        public ClientbWindow()
        {
            InitializeComponent();
            cbStatus.ItemsSource= Enum.GetValues(typeof(Status)); ;
        }
        public ClientbWindow(Client_booked client) : this()
        {
            _client = client;
        }
        private void btConfirm_Click(object sender, RoutedEventArgs e)
        {
            if(tbFirstname.Text!="" && tbSurname.Text!=""&& cbStatus.Text!="")
            {
                _client.Firstname = tbFirstname.Text;
                _client.Surname = tbSurname.Text;
                _client.Status = (cbStatus.Text=="Adult") ? Status.Adult : Status.Child;
                this.DialogResult = true;
                this.Close();
            }
            
        }

        private void btCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            this.Close();
        }
    }
}

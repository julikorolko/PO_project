using System;
using System.Windows;
using TravelAgency;

namespace TravelAgencyGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Booking booking = new Booking();
        public MainWindow()
        {
            InitializeComponent();
			flight_type.ItemsSource = Enum.GetValues(typeof(Flight_types));
            room_type.ItemsSource = Enum.GetValues(typeof(Accomodation));
            board_type.ItemsSource = Enum.GetValues(typeof(Board_types));
        }

        private void btBrowse_Click(object sender, RoutedEventArgs e)
        {
            Offer offer = new Offer();
            OfferBrowser offerBrowser = new OfferBrowser(offer);
            offerBrowser.ShowDialog();
            if (offerBrowser.DialogResult == true)
            {
                tbofferdest.Text = offer.Destination;
                tbDeparture.Text = offer.Departure;
                tbHotel.Text = offer.Hotel;
                tbDuration.Text = offer.Days.ToString() + " days";
                tbPrice.Text = offer.Price.ToString() + " PLN";
                tbDepDate.Text = offer.Date_dep.ToShortDateString();
                tbRetDate.Text = offer.Date_arr.ToShortDateString();
            }
        }
        private void btClient_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                Client client = new Client(tbxFirstname.Text, tbxSurname.Text, tbxAdress.Text, tbxPostcode.Text,
                    tbxPhoneNum.Text, tbxEmail.Text);
                MessageBox.Show(client.Email);
            }
            catch
            {
                MessageBox.Show("Some data is missing!","Error");
            }
        }

		private void info_button_Click(object sender, RoutedEventArgs e)
		{
            if (flight_type.SelectedItem == null || room_type.SelectedItem == null || board_type.SelectedItem == null)
            {
                MessageBox.Show("Please check whether everything is selected");
            }
            else
            {
                Flight_types ft = (Flight_types)flight_type.SelectedItem;
                Accomodation ac = (Accomodation)room_type.SelectedItem;
                Board_types bt = (Board_types)board_type.SelectedItem;
                MessageBox.Show("Flight type: " + ft.ToString() + "\nRoom type: " + ac.ToString() + "\nBoard type: " + bt.ToString());
            }
        }
	}
}


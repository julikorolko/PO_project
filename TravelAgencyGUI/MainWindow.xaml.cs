using System.Windows;
using ProjektPO;

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
                tbDuration.Text = offer.Days.ToString()+" days";
                tbPrice.Text = offer.Price.ToString() + " PLN";
                tbDepDate.Text = offer.Date_dep.ToShortDateString();
                tbRetDate.Text = offer.Date_arr.ToShortDateString();

            }
        }
    }
}

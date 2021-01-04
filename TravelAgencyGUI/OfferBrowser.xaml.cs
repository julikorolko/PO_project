using System.Collections.ObjectModel;
using System.Windows;
using ProjektPO;

namespace TravelAgencyGUI
{
    /// <summary>
    /// Logika interakcji dla klasy OfferBrowser.xaml
    /// </summary>
    public partial class OfferBrowser : Window
    {
        OffersList offersList = new OffersList();
        Offer _offer;
        ObservableCollection<Offer> list;
        public OfferBrowser()
        {
            InitializeComponent();
            offersList = OffersList.OdczytajXML("offerslist.xml") as OffersList;
            if (offersList != null)
            {
                list = new ObservableCollection<Offer>(offersList.Offers);
                lbOffers.ItemsSource = list;
            }
        }
        public OfferBrowser(Offer offer):this()
        {
            _offer = offer;
        }

        private void btSelect_Click(object sender, RoutedEventArgs e)
        {
            int selected = lbOffers.SelectedIndex;
            if (selected >= 0)
            {
                _offer.Destination = offersList.Offers[selected].Destination;
                _offer.Departure = offersList.Offers[selected].Departure;
                _offer.Days = offersList.Offers[selected].Days;
                _offer.Hotel = offersList.Offers[selected].Hotel;
                _offer.Price = offersList.Offers[selected].Price;
                _offer.Date_arr = offersList.Offers[selected].Date_arr;
                _offer.Date_dep = offersList.Offers[selected].Date_dep;
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

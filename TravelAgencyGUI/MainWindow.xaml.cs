﻿using System;
using System.Collections.ObjectModel;
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
        ObservableCollection<Client_booked> list = new ObservableCollection<Client_booked>();
        public MainWindow()
        {
            InitializeComponent();
			flight_type.ItemsSource = Enum.GetValues(typeof(Flight_types));
            room_type.ItemsSource = Enum.GetValues(typeof(Accomodation));
            board_type.ItemsSource = Enum.GetValues(typeof(Board_types));

            lbClients.ItemsSource = list;
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

        private void addbt_Click(object sender, RoutedEventArgs e)
        {
            Client_booked client = new Client_booked();
            ClientbWindow clientb = new ClientbWindow(client);
            clientb.ShowDialog();
            if (clientb.DialogResult == true)
            {
                booking.Clients.Add(client);
                list.Add(client);
            }
        }

        private void deletebt_Click(object sender, RoutedEventArgs e)
        {
            int selected = lbClients.SelectedIndex;
            if (selected >=0){
                
                list.RemoveAt(selected);
                booking.Clients.RemoveAt(selected);
            }
        }
    }
}


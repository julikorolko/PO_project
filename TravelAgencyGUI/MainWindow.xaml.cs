using System;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;
using System.Windows;
using TravelAgency;
namespace TravelAgencyGUI
{
    
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

		private void btsummary_Click(object sender, RoutedEventArgs e)
		{       

            try
            {
                Client client = new Client(tbxFirstname.Text, tbxSurname.Text, tbxAdress.Text, tbxPostcode.Text,
                    tbxPhoneNum.Text, tbxEmail.Text);                
            }
            catch
            {
                MessageBox.Show("Please check personal information! Something is missing!", "Error");
            }


            if (flight_type.SelectedItem == null || room_type.SelectedItem == null || board_type.SelectedItem == null || string.IsNullOrEmpty(tbofferdest.Text))
            {
                MessageBox.Show("Please check whether everything is selected!", "Error");
            }
            else
            {
                String price_number = Regex.Match(tbPrice.Text, @"\d+").Value;                
                String people_number = lbClients.Items.Count.ToString();
                String Firstname = (tbxFirstname.Text);
                String Surname = (tbxSurname.Text);
                int final_number;
                int final_price;
                int price = Int32.Parse(price_number);

                Flight_types ft = (Flight_types)flight_type.SelectedItem;
                Accomodation ac = (Accomodation)room_type.SelectedItem;
                Board_types bt = (Board_types)board_type.SelectedItem;
               

               if(ft == Flight_types.Economy)
				{
                    price += 100;
				}
               else if(ft == Flight_types.FirstClass)
				{
                    price += 500;
				}
               else
				{
                    price += 0;
				}

               if (ac == Accomodation.Double)
                {
                    price += 50;
                }
               else if (ac == Accomodation.Extra)
                {
                    price += 100;
                }
               else
                {
                    price += 0;
                }

               if (bt == Board_types.Half)
				{
                    price += 50;
				}
               else if (bt == Board_types.Standard)
				{
                    price += 100;
                }
                else if (bt == Board_types.Full)
                {
                   price += 200;
                }
                else
                {
                    price += 0;
                }

                if (people_number == "0")
                {
                    final_number = 1;
                    final_price = price;
                }
                else
                {
                    int x = Int32.Parse(people_number);
                    final_number = 1 + x;
                    final_price = price * final_number;
                }
                richTextBox.AppendText(
                "Client: " + tbxFirstname.Text + " " + tbxSurname.Text +
                "\nOffer: " + tbofferdest.Text + " " + "(" + tbDepDate.Text + " - " + tbRetDate.Text + ")"
                + "\nBooking information: " + ft.ToString() + " flight, " + ac.ToString() + " room, " + bt.ToString() + " board" 
                + "\nNumber of people: " + final_number +  
                "\nReminder: Standard flight, Single room and None board are included in the offer price, other types will raise the price."
                + "\nFinal price: " + final_price

                );
            }
		}
        private void exit_button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}


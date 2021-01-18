using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace TravelAgency
{
    public enum Flight_types { Standard, Economy, FirstClass };
    public enum Accomodation { Single, Double, Extra };
    public enum Board_types { Half, Standard, Full, None };
    public class Booking: ICloneable
    {
        List<Client_booked> clients = new List<Client_booked>();
        Client client;
        Offer offer;
        Accomodation accomodation;
        Flight_types flight;
        Board_types board;
        bool insurance;
        public Accomodation Accomodation { get => accomodation; set => accomodation = value; }
        public Flight_types Flight { get => flight; set => flight = value; }
        public Board_types Board { get => board; set => board = value; }
        public bool Insurance { get => insurance; set => insurance = value; }
        public Client Client { get => client; set => client = value; }
        public Offer Offer { get => offer; set => offer = value; }
        public List<Client_booked> Clients { get => clients; set => clients = value; }

        public Booking()
        {

        }
        public Booking(Client client, Offer offer,
            Accomodation accomodation, Flight_types flight, Board_types board, bool insurance)
        {
            this.Client = client;
            this.Offer = offer;

            this.Accomodation = accomodation;
            this.Flight = flight;
            this.Board = board;
            this.Insurance = insurance;

        }

        public override string ToString()
        {
            string ins;
            if (Insurance == true) ins = "Yes";
            else ins = "No";

            return Client.ToString() + Offer.ToString()
                + "Accomodation: " + Accomodation + "\n"
                + "Board type: " + Board + "\n"
                + "Flight: " + Flight + "\n"
                + "Travel insurance: " + ins + "\n";
        }

        public object Clone()
        {
            Booking clone = this.MemberwiseClone() as Booking;
            clone.Clients = new List<Client_booked>(this.Clients);
            clone.offer = this.offer.Clone() as Offer;        
            clone.client = this.client.Clone() as Client;
            foreach (Client_booked client in Clients)
            {
                clone.Clients.Add(client.Clone() as Client_booked);
            }
            return clone;

        }
    }
}

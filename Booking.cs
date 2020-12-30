using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjektPO
{
    public enum Flight_types { Standard, Economy, FirstClass };
    public enum Accomodation { Single, Double, Extra };
    public enum Board_types { Half, Standard, Full, None };
    class Booking
    {
        
        Client client;
        Offer offer;
        int people_number;
        Accomodation accomodation;
        Flight_types flight;
        Board_types board;
        bool insurance;
        public int People_number { get => people_number; set => people_number = value; }
        public Accomodation Accomodation { get => accomodation; set => accomodation = value; }
        public Flight_types Flight { get => flight; set => flight = value; }
        public Board_types Board { get => board; set => board = value; }
        public bool Insurance { get => insurance; set => insurance = value; }
        internal Client Client { get => client; set => client = value; }
        internal Offer Offer { get => offer; set => offer = value; }
        public Booking(Client client, Offer offer, int people_number,  
            Accomodation accomodation, Flight_types flight, Board_types board, bool insurance)
        {
            this.Client = client;
            this.Offer = offer;
            this.People_number = people_number;
            
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
                + "Number of people: " + People_number + "\n"
                
                + "Accomodation: " + Accomodation + "\n"
                + "Board type: " + Board + "\n"
                + "Flight: " + Flight + "\n"
                + "Travel insurance: " + ins + "\n";
        }
    }
}

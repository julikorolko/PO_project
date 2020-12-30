using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ProjektPO
{
    class DestinationComparator : Comparer<Offer>
    {
        public override int Compare(Offer x, Offer y)
        {
            return y.Destination.CompareTo(x.Destination);
        }
    }
    class PriceComparator : Comparer<Offer>
    {
        public override int Compare(Offer x, Offer y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
    class PriceComparator2 : Comparer<Offer>
    {
        public override int Compare(Offer x, Offer y)
        {
            return y.Price.CompareTo(x.Price);
        }
    }
    class Offer : IComparable<Offer>
    {
        string destination;
        string departure;
        string hotel;
        int days;
        double price;
        DateTime date_dep;
        DateTime date_arr;
        public string Destination { get => destination; set => destination = value; }
        public string Departure { get => departure; set => departure = value; }
        public string Hotel { get => hotel; set => hotel = value; }
        public int Days { get => days; set => days = value; }
        public double Price { get => price; set => price = value; }
        public DateTime Date_dep { get => date_dep; set => date_dep = value; }
        public DateTime Date_arr { get => date_arr; set => date_arr = value; }

        public Offer(string destination, string departure, string hotel, int days, double price, string date_dep,string date_arr )
        {
            this.Destination = destination;
            this.Departure = departure;
            this.Hotel = hotel;
            this.Days = days;
            this.Price = price;
            Regex pattern = new Regex(@"^\d{2}-\d{2}-\d{4}$");
            if (pattern.IsMatch(date_dep))
                DateTime.TryParse(date_dep, out this.date_dep);
            if (pattern.IsMatch(date_arr))
                DateTime.TryParse(date_arr, out this.date_arr);


        }
        public int CompareTo(Offer other)
        {
            return this.Destination.CompareTo(other.Destination);
        }


        public override string ToString()
        {
            return "Destination: " + Destination + "\n" 
                + "Departure: " + Departure + "\n" 
                + "Hotel: " + Hotel + "\n" 
                + "Duration (days): " + Days + "\n" 
                + "Price per person: " + Price + " PLN\n";
        }
    }
}
